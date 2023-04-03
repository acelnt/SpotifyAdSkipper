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
    /// adjust the properties it checks for and how they are checked by changing the detection features.
    /// </summary>
    static class AdDetector
    {
        const string FILEPATH = "adFeatures.txt";

        static AdDetectionFeatureCollection _detectionFeatures = new AdDetectionFeatureCollection();

        public static void UseDefaultAdDetectionFeatures()
        {
            _detectionFeatures.Add(AudioProperty.Title, DetectionStrength.Contains, "spotify");
            _detectionFeatures.Add(AudioProperty.Title, DetectionStrength.Contains, "advertisement");
            _detectionFeatures.Add(AudioProperty.Album, DetectionStrength.Contains, "advertisement");
        }

        /// <summary>
        /// Loads ad detection features from the file it is stored in, using them for ad detection
        /// </summary>
        public static void LoadAdDetectionFeaturesFromFile()
        {
            try
            {
                string dataInFile = File.ReadAllText(FILEPATH);
                _detectionFeatures.Deserialize(dataInFile);
                Logger.Write($"Loaded ad detection filters from {FILEPATH}");
            } catch (FileNotFoundException)
            {
                UseDefaultAdDetectionFeatures();
                Logger.Write("Could not find file to load filters from. Assigned default filters.");
                StoreAdDetectionFeaturesInFile();
                
            }
        }

        /// <summary>
        /// serializes and stores the ad detection features in a file
        /// </summary>
        public static void StoreAdDetectionFeaturesInFile()
        {
            File.WriteAllText(FILEPATH, _detectionFeatures.Serialize());
            Logger.Write($"Stored ad detection filters in file {FILEPATH}");
        }

        /// <summary>
        /// Adds a new ad detection feature to the collection. audioProperty is the property to be examined
        /// (e.g title or album name), matchValue is the value which you are comparing the property to to 
        /// see if it indicates an ad and detectionStrength is how closely propertyMatch needs to match in
        /// order to indicate an ad (exact or contains)
        /// </summary>
        /// <param name="audioProperty"></param>
        /// <param name="detectionStrength"></param>
        /// <param name="match"></param>
        public static void AddAdDetectionFeature(AudioProperty audioProperty, DetectionStrength detectionStrength, string matchValue)
        {
            _detectionFeatures.Add(audioProperty, detectionStrength, matchValue);
            Logger.Write($"Added new ad detection filter matchValue:{matchValue}, audioProperty:{audioProperty.ToString()}, matchStrength:{detectionStrength.ToString()}");
        }

        /// <summary>
        /// Removes an ad detection feature from the collection
        /// </summary>
        /// <param name="audioProperty"></param>
        /// <param name="detectionStrength"></param>
        /// <param name="matchValue"></param>
        public static void RemoveAdDetectionFeature(AudioProperty audioProperty, DetectionStrength detectionStrength, string matchValue)
        {
            _detectionFeatures.Remove(audioProperty, detectionStrength, matchValue);
            Logger.Write($"Removed ad detection filter matchValue:{matchValue}, audioProperty:{audioProperty.ToString()}, matchStrength:{detectionStrength.ToString()}");
        }

        public static List<string> GetMatchValues(AudioProperty audioProperty, DetectionStrength detectionStrength)
        {
            return _detectionFeatures.GetMatchValues(audioProperty, detectionStrength);
        }

        public static Dictionary<DetectionStrength, List<string>> GetMatchValuesForProperty(AudioProperty audioProperty)
        {
            return _detectionFeatures.GetMatchValuesForProperty(audioProperty);
        }

        /// <summary>
        /// Given a media, returns true if it is an ad based on the Ad detection features the class holds, and false if not
        /// </summary>
        /// <param name="media"></param>
        /// <returns></returns>
        public static bool IsAd(GlobalSystemMediaTransportControlsSessionMediaProperties media)
        {
            foreach (AudioProperty audioProperty in Enum.GetValues(typeof(AudioProperty)))
            {
                foreach (DetectionStrength detectionStrength in Enum.GetValues(typeof(DetectionStrength)))
                { 
                    foreach (string matchValue in _detectionFeatures.GetMatchValues(audioProperty, detectionStrength))
                    {
                        string property = GetAudioProperty(media, audioProperty);
                        if (ComparePropertyToMatch(property, matchValue, detectionStrength))
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
        /// Compares the property to the matchValue. Using detectionStrength as the measure of how close they should
        /// match, return true if there is a match and false if there is not. Will convert matchValue and property
        /// to lowercase
        /// </summary>
        /// <param name="property"></param>
        /// <param name="matchValue"></param>
        /// <param name="detectionStrength"></param>
        /// <returns></returns>
        static bool ComparePropertyToMatch(string property, string matchValue, DetectionStrength detectionStrength)
        {
            string lowercaseMatchValue = matchValue.ToLower();
            string lowercaseproperty = property.ToLower();
            bool isMatch;
            // Different comparisons are used based on the value of detectionStrength
            switch (detectionStrength)
            {
                case DetectionStrength.Exact:
                    isMatch = lowercaseproperty == lowercaseMatchValue;
                    break;
                case DetectionStrength.Contains:
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
