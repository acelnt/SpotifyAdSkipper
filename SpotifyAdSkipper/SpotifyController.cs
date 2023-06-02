using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Media.Control;

namespace SpotifyAdSkipper
{
    internal static class SpotifyController
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        const int WM_APPCOMMAND = 0x319;
        const int APPCOMMAND_MEDIA_PLAY = 0xE0000;
        const int APPCOMMAND_MEDIA_NEXTTRACK = 720896;

        const string PROCESS_NAME = "Spotify";

        static string _previousSong;

        /// <summary>
        /// Checks if an ad is playing and skips if it is
        /// </summary>
        /// <returns></returns>
        public static async Task SkipIfPlayingAd()
        {
            // Check if the Spotify process is currently playing an ad
            var playingAudios = await GetPlayingAudios();
            GlobalSystemMediaTransportControlsSessionMediaProperties adAudio;
            bool isAdPlaying = IsAdPlaying(playingAudios, out adAudio);

            if (isAdPlaying)
            {
                Logger.Write($"Ad detected: {adAudio.Title} - {adAudio.AlbumTitle} - {adAudio.Artist}");

                CloseAndRestart();
            } else
            {
                List<string> audioStrings = new List<string>();
                foreach (var audio in playingAudios) { audioStrings.Add($"{audio.Title} - {audio.AlbumTitle} - {audio.Artist}"); }
                string currentSong = $"No ad detected: {String.Join(",", audioStrings)}";
                if (currentSong != _previousSong)
                {
                    _previousSong = currentSong;
                    Logger.Write(currentSong);
                }
            }
        }

        /// <summary>
        /// Kills the spotify process, starts it up again and plays next track
        /// </summary>
        public static async void CloseAndRestart()
        {
            IntPtr spotifyWindowHandle = GetWindowHandle();

            // Kill the Spotify process
            Kill();

            // Wait until the spotify killed to move on
            while (IsSpotifyRunning())
            {
                await Task.Delay(25);
            }
            Logger.Write("Spotify killed");

            // Launch the Spotify process
            Launch();

            // Wait until the window appears to start playing
            while (!HasSpotifyInitialised())
            {
                await Task.Delay(25);
            }

            spotifyWindowHandle = GetWindowHandle();
            Logger.Write("Spotify Launched");

            StartPlaying(spotifyWindowHandle);

            NextTrack(spotifyWindowHandle);
            Logger.Write("Started next track");
        }

        /// <summary>
        /// Returns true if an one of the audios in the passed in list is an ad, or null if not
        /// </summary>
        /// <returns></returns>
        public static bool IsAdPlaying(List<GlobalSystemMediaTransportControlsSessionMediaProperties> audios)
        {
            return GetAdAudio(audios) != null;
        }

        /// <summary>
        /// Returns true if an one of the audios in the passed in list is an ad, or null if not. Takes
        /// an out parameter adAudio which is set to the specific audio detected to be an ad.
        /// </summary>
        /// <returns></returns>
        public static bool IsAdPlaying(List<GlobalSystemMediaTransportControlsSessionMediaProperties> audios, out GlobalSystemMediaTransportControlsSessionMediaProperties adAudio)
        {
            adAudio = GetAdAudio(audios);
            return adAudio != null;
        }

        /// <summary>
        /// Given a list of audios, returns the one detcted to be an ad, or returns null if none are
        /// </summary>
        /// <returns></returns>
        static GlobalSystemMediaTransportControlsSessionMediaProperties GetAdAudio(List<GlobalSystemMediaTransportControlsSessionMediaProperties> audios)
        {
            foreach (var audio in audios)
            {
                // Check for ad
                if (AdDetection.AdDetector.IsAd(audio))
                {
                    // This is an ad, return it
                    return audio;
                }
            }

            // No ad detcted, return null
            return null;
        }

        /// <summary>
        /// Returns a list of all the playing audios' MediaProperties as a List of 
        /// GlobalSystemMediaTransportControlsSessionMediaProperties
        /// </summary>
        /// <returns></returns>
        public static async Task<List<GlobalSystemMediaTransportControlsSessionMediaProperties>> GetPlayingAudios()
        {
            var result = new List<GlobalSystemMediaTransportControlsSessionMediaProperties>();

            // Create a GlobalSystemMediaTransportControlsSessionManager instance
            GlobalSystemMediaTransportControlsSessionManager sessionManager;
            try
            {
                sessionManager = await GlobalSystemMediaTransportControlsSessionManager.RequestAsync();
            } catch
            {
                return result;
            }
            

            // Get the current session for Spotify
            var sessions = sessionManager.GetSessions();

            foreach (var session in sessions)
            {
                if (session.SourceAppUserModelId != null &&
                    session.SourceAppUserModelId.Contains(PROCESS_NAME))
                {
                    // Get the currently playing media information
                    GlobalSystemMediaTransportControlsSessionMediaProperties mediaProperties;
                    try
                    {
                        mediaProperties = await session.TryGetMediaPropertiesAsync();
                    } catch
                    {
                        mediaProperties = null;
                    }

                    if (!(mediaProperties == null))
                    {
                        result.Add(mediaProperties);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Returns the processes which may be the spotiofy application (named the PROCESS_NAME)
        /// </summary>
        /// <returns></returns>
        static Process[] GetSpotifyProcesses()
        {
            Process[] processes = Process.GetProcessesByName(PROCESS_NAME);

            return processes;
        }

        /// <summary>
        /// Returns the handle for the spotify window
        /// </summary>
        /// <returns></returns>
        static IntPtr GetWindowHandle()
        {
            Process[] processes = GetSpotifyProcesses();
            Process windowProcess = processes.FirstOrDefault(p => p.MainWindowHandle != IntPtr.Zero);

            IntPtr handle = IntPtr.Zero;
            if (windowProcess != null)
            {
                handle = windowProcess.MainWindowHandle;
            }
            return handle;
        }

        /// <summary>
        /// Returns true if spotify is detected to be running
        /// </summary>
        /// <returns></returns>
        public static bool IsSpotifyRunning()
        {
            return GetSpotifyProcesses().Length > 0;
        }

        /// <summary>
        /// Will return true briefly after spotify is initialised and ready to take inputs.
        /// Only works for spotify free
        /// </summary>
        /// <returns></returns>
        static bool HasSpotifyInitialised()
        {
            return FindWindow(null, "Spotify Free") != IntPtr.Zero;
        }

        /// <summary>
        /// Kills every process with the process name of Spotify
        /// </summary>
        static void Kill()
        {
            // Get all Spotify processes
            Process[] processes = GetSpotifyProcesses();

            // Kill each process
            foreach (Process process in processes)
            {
                process.Kill();
            }
        }

        /// <summary>
        /// Starts spotify minimized
        /// </summary>
        static void Launch()
        {
            // Launch Spotify
            Process.Start("spotify", "--minimized");
        }

        /// <summary>
        /// Starts playing spotify audio, given the handle for the spotify window
        /// </summary>
        /// <param name="hwnd"></param>
        static void StartPlaying(IntPtr hwnd)
        {
            // Send the play command to the Spotify window
            SendMessage(hwnd, WM_APPCOMMAND, IntPtr.Zero, (IntPtr)APPCOMMAND_MEDIA_PLAY);
        }

        /// <summary>
        /// Starts playing spotify audio
        /// </summary>
        static void StartPlaying()
        {
            IntPtr hwnd = GetWindowHandle();

            // Send the play command to the Spotify window
            SendMessage(hwnd, WM_APPCOMMAND, IntPtr.Zero, (IntPtr)APPCOMMAND_MEDIA_PLAY);
        }

        /// <summary>
        /// Skips to the next track on spotify, given the spotify window handle
        /// </summary>
        /// <param name="hwnd"></param>
        static void NextTrack(IntPtr hwnd)
        {
            // Send the skip command to the Spotify window
            SendMessage(hwnd, WM_APPCOMMAND, IntPtr.Zero, (IntPtr)APPCOMMAND_MEDIA_NEXTTRACK);
        }

        /// <summary>
        /// Skips to the next track on spotify
        /// </summary>
        static void NextTrack()
        {
            IntPtr hwnd = GetWindowHandle();

            // Send the skip command to the Spotify window
            SendMessage(hwnd, WM_APPCOMMAND, IntPtr.Zero, (IntPtr)APPCOMMAND_MEDIA_NEXTTRACK);
        }
    }
}
