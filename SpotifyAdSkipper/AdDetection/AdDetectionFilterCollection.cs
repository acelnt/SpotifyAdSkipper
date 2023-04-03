using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpotifyAdSkipper.AdDetection
{
    /// <summary>
    /// Holds a collection of filters which indicate an ad. Each filter has a property to be examined 
    /// (e.g Title, album name), a value to match the property with and a strength for how closely the 
    /// property and match value should match (e.g exact or contains)
    /// </summary>
    internal class AdDetectionFilterCollection
    {
        Dictionary<AudioProperty, Dictionary<MatchStrength, List<string>>> _detectionFilters = 
            new Dictionary<AudioProperty, Dictionary<MatchStrength, List<string>>>();

        /// <summary>
        /// initializes an AdDetectorFilterCollection to with no filters stored in it
        /// </summary>
        public AdDetectionFilterCollection()
        {
            foreach (AudioProperty audioproperty in Enum.GetValues(typeof(AudioProperty)))
            {
                _detectionFilters.Add(audioproperty, new Dictionary<MatchStrength, List<string>>());
                foreach (MatchStrength matchStrength in Enum.GetValues(typeof(MatchStrength)))
                {
                    _detectionFilters[audioproperty].Add(matchStrength, new List<string>());
                }
            }
        }

        /// <summary>
        /// Convert data to string
        /// </summary>
        /// <returns></returns>
        public string Serialize()
        {
            return JsonSerializer.Serialize(_detectionFilters);
        }

        /// <summary>
        /// Takes serialized data, deserializes it and sets the detection filters the object holds to it
        /// </summary>
        /// <param name="json"></param>
        public void Deserialize(string json)
        {
            _detectionFilters = JsonSerializer.Deserialize<Dictionary<AudioProperty, Dictionary<MatchStrength, List<string>>>>(json);
        }

        /// <summary>
        /// Adds a new ad detection filter to the collection. audioProperty is the property to be examined
        /// (e.g title or album name), matchValue is the value which you are comparing the property to to 
        /// see if it indicates an ad and matchStrength is how closely the property and matchValue needs to match in
        /// order to indicate an ad (exact or contains)
        /// </summary>
        public void Add(AudioProperty audioProperty, MatchStrength matchStrength, string matchValue)
        {
            if (!(_detectionFilters.ContainsKey(audioProperty)) ||
                !(_detectionFilters[audioProperty].ContainsKey(matchStrength)))
            {
                AddMatchStrengthKeyForAudioPropertyKey(audioProperty, matchStrength);
            }
            _detectionFilters[audioProperty][matchStrength].Add(matchValue);
        }

        /// <summary>
        /// Removes an ad detection filter from the collection
        /// </summary>
        /// <param name="audioProperty"></param>
        /// <param name="matchStrength"></param>
        /// <param name="matchValue"></param>
        public void Remove(AudioProperty audioProperty, MatchStrength matchStrength, string matchValue)
        {
            if (!(_detectionFilters.ContainsKey(audioProperty)) ||
                !(_detectionFilters[audioProperty].ContainsKey(matchStrength)))
            {
                AddMatchStrengthKeyForAudioPropertyKey(audioProperty, matchStrength);
            }

            _detectionFilters[audioProperty][matchStrength].Remove(matchValue);
        }

        /// <summary>
        /// gets a list of match values for a given audioProperty and MatchStrength. A match value is a
        /// value which, if it matches the audioProperty with the given matchStrength, would indicate that
        /// an ad is playing
        /// </summary>
        public List<string> GetMatchValuesForPropertyAndStrength(AudioProperty audioProperty, MatchStrength matchStrength)
        {
            if (!(_detectionFilters.ContainsKey(audioProperty)) ||
                !(_detectionFilters[audioProperty].ContainsKey(matchStrength)))
            {
                AddMatchStrengthKeyForAudioPropertyKey(audioProperty, matchStrength);
            }

            return _detectionFilters[audioProperty][matchStrength];
        }

        public Dictionary<MatchStrength, List<string>> GetMatchValuesForProperty(AudioProperty audioProperty)
        {
            if (!(_detectionFilters.ContainsKey(audioProperty)))
            {
                AddAudioPropertyKey(audioProperty);
            }

            return _detectionFilters[audioProperty];
        }

        /// <summary>
        /// If the passed in audioProperty is not a key in the detection filters dictionary, adds the key
        /// </summary>
        /// <param name="audioProperty"></param>
        private void AddAudioPropertyKey(AudioProperty audioProperty)
        {
            if (!(_detectionFilters.ContainsKey(audioProperty))) {
                _detectionFilters.Add(audioProperty, new Dictionary<MatchStrength, List<string>>());
                foreach (MatchStrength strength in Enum.GetValues(typeof(MatchStrength)))
                {
                    _detectionFilters[audioProperty].Add(strength, new List<string>());
                }
            }
        }
        
        /// <summary>
        /// If the matchStrength key does not exist for the audioProperty, adds it with an empty list of
        /// match values. if the audioProperty key does not exist, adds that as well
        /// </summary>
        /// <param name="audioProperty"></param>
        /// <param name="matchStrength"></param>
        private void AddMatchStrengthKeyForAudioPropertyKey(AudioProperty audioProperty, MatchStrength matchStrength)
        {
            try
            {
                if (!(_detectionFilters[audioProperty].ContainsKey(matchStrength)))
                {
                    _detectionFilters[audioProperty].Add(matchStrength, new List<string>());
                }
            }
            catch (KeyNotFoundException)
            {
                AddAudioPropertyKey(audioProperty);
            }
        }
    }
}
