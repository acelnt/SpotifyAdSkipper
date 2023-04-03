using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Windows.Devices.PointOfService;
using System.IO;
using Windows.Media.AppBroadcasting;
using System.Runtime.InteropServices.ComTypes;
using Windows.Media.Control;
using System.Windows.Forms;

namespace SpotifyAdSkipper.AdDetection
{
    /// <summary>
    /// Class which allows you to check if a given audio is an ad based on its properties. You can
    /// adjust the properties it checks for and how they are checked by changing the detection filters.
    /// </summary>
    static class AdDetector
    {
        const string FILEPATH = "adFeatures.txt";

        static AdDetectionFilterCollection _detectionFilters = new AdDetectionFilterCollection();

        public static void UseDefaultAdDetectionFilters()
        {
            _detectionFilters.Add(AudioProperty.Title, MatchStrength.Contains, "spotify");
            _detectionFilters.Add(AudioProperty.Title, MatchStrength.Contains, "advertisement");
            _detectionFilters.Add(AudioProperty.Album, MatchStrength.Contains, "advertisement");
        }

        /// <summary>
        /// Loads ad detection filters from the file it is stored in, using them for ad detection
        /// </summary>
        public static void LoadAdDetectionFiltersFromFile()
        {
            try
            {
                string dataInFile = File.ReadAllText(FILEPATH);
                _detectionFilters.Deserialize(dataInFile);
                Logger.Write($"Loaded ad detection filters from {FILEPATH}");
            } catch (FileNotFoundException)
            {
                UseDefaultAdDetectionFilters();
                Logger.Write("Could not find file to load filters from. Assigned default filters.");
                StoreAdDetectionFiltersInFile();
                
            }
        }

        /// <summary>
        /// serializes and stores the ad detection filters in a file
        /// </summary>
        public static void StoreAdDetectionFiltersInFile()
        {
            File.WriteAllText(FILEPATH, _detectionFilters.Serialize());
            Logger.Write($"Stored ad detection filters in file {FILEPATH}");
        }

        /// <summary>
        /// Adds a new ad detection filter to the collection. audioProperty is the property to be examined
        /// (e.g title or album name), matchValue is the value which you are comparing the property to to 
        /// see if it indicates an ad and matchStrength is how closely the property and match needs to match in
        /// order to indicate an ad (exact or contains)
        /// </summary>
        /// <param name="audioProperty"></param>
        /// <param name="matchStrength"></param>
        /// <param name="match"></param>
        public static void AddAdDetectionFilter(AudioProperty audioProperty, MatchStrength matchStrength, string matchValue)
        {
            _detectionFilters.Add(audioProperty, matchStrength, matchValue);
            Logger.Write($"Added new ad detection filter matchValue:{matchValue}, audioProperty:{audioProperty.ToString()}, matchStrength:{matchStrength.ToString()}");
        }

        /// <summary>
        /// Removes an ad detection filter from the collection
        /// </summary>
        /// <param name="audioProperty"></param>
        /// <param name="matchStrength"></param>
        /// <param name="matchValue"></param>
        public static void RemoveAdDetectionFilter(AudioProperty audioProperty, MatchStrength matchStrength, string matchValue)
        {
            _detectionFilters.Remove(audioProperty, matchStrength, matchValue);
            Logger.Write($"Removed ad detection filter matchValue:{matchValue}, audioProperty:{audioProperty.ToString()}, matchStrength:{matchStrength.ToString()}");
        }

        /// <summary>
        /// Returns a list of match values for filters for audioProperty and matchStrength
        /// </summary>
        /// <param name="audioProperty"></param>
        /// <param name="matchStrength"></param>
        /// <returns></returns>
        public static List<string> GetMatchValues(AudioProperty audioProperty, MatchStrength matchStrength)
        {
            return _detectionFilters.GetMatchValues(audioProperty, matchStrength);
        }

        /// <summary>
        /// Returns the match strength and match values for the filters which are for the property audioProperty
        /// </summary>
        /// <param name="audioProperty"></param>
        /// <returns></returns>
        public static Dictionary<MatchStrength, List<string>> GetMatchValuesForProperty(AudioProperty audioProperty)
        {
            return _detectionFilters.GetMatchValuesForProperty(audioProperty);
        }

        /// <summary>
        /// Given a media, returns true if it is an ad based on the Ad detection filters the class holds, and false if not
        /// </summary>
        /// <param name="media"></param>
        /// <returns></returns>
        public static bool IsAd(GlobalSystemMediaTransportControlsSessionMediaProperties media)
        {
            foreach (AudioProperty audioProperty in Enum.GetValues(typeof(AudioProperty)))
            {
                foreach (MatchStrength matchStrength in Enum.GetValues(typeof(MatchStrength)))
                { 
                    foreach (string matchValue in _detectionFilters.GetMatchValues(audioProperty, matchStrength))
                    {
                        string property = GetAudioProperty(media, audioProperty);
                        if (ComparePropertyToMatch(property, matchValue, matchStrength))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Returns the value of the audioProperty for the given media, where audioPropety is a value of enum AudioProperty
        /// </summary>
        /// <param name="media"></param>
        /// <param name="audioProperty"></param>
        static string GetAudioProperty(GlobalSystemMediaTransportControlsSessionMediaProperties media, AudioProperty audioProperty)
        {
            string property;
            // Selects the correct property from the MediaProperties object based on audioProperty
            switch (audioProperty) {
                case AudioProperty.Title:
                    property = media.Title;
                    break;
                case AudioProperty.Album:
                    property = media.AlbumTitle;
                    break;
                default:
                    property = null;
                    break;
            }
            return property;
        }

        /// <summary>
        /// Compares the property to the matchValue. Using matchStrength as the measure of how close they should
        /// match, return true if there is a match and false if there is not. Will convert matchValue and property
        /// to lowercase
        /// </summary>
        /// <param name="property"></param>
        /// <param name="matchValue"></param>
        /// <param name="matchStrength"></param>
        /// <returns></returns>
        static bool ComparePropertyToMatch(string property, string matchValue, MatchStrength matchStrength)
        {
            string lowercaseMatchValue = matchValue.ToLower();
            string lowercaseproperty = property.ToLower();
            bool isMatch;
            // Different comparisons are used based on the value of matchStrength
            switch (matchStrength)
            {
                case MatchStrength.Exact:
                    isMatch = lowercaseproperty == lowercaseMatchValue;
                    break;
                case MatchStrength.Contains:
                    isMatch = lowercaseproperty.Contains(lowercaseMatchValue);
                    break;
                default:
                    isMatch = false;
                    break;
            }
            return isMatch;
        }
    }
}
