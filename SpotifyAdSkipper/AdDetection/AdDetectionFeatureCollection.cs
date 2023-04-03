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
    /// Holds a collection of features of an audio which would indicate it being an ad. Each feature
    /// has a property to be examined (e.g Title, album name), a value to match the property with
    /// and a strength for how closely the property and match value should match (e.g exact or contains)
    /// </summary>
    internal class AdDetectionFeatureCollection
    {
        Dictionary<AudioProperty, Dictionary<DetectionStrength, List<string>>> _detectionFeatures = 
            new Dictionary<AudioProperty, Dictionary<DetectionStrength, List<string>>>();

        /// <summary>
        /// initializes an AdDetectorFeatureCollection to with no features stored in it
        /// </summary>
        public AdDetectionFeatureCollection()
        {
            foreach (AudioProperty audioproperty in Enum.GetValues(typeof(AudioProperty)))
            {
                _detectionFeatures.Add(audioproperty, new Dictionary<DetectionStrength, List<string>>());
                foreach (DetectionStrength detectionStrength in Enum.GetValues(typeof(DetectionStrength)))
                {
                    _detectionFeatures[audioproperty].Add(detectionStrength, new List<string>());
                }
            }
        }

        /// <summary>
        /// Convert data to string
        /// </summary>
        /// <returns></returns>
        public string Serialize()
        {
            return JsonSerializer.Serialize(_detectionFeatures);
        }

        /// <summary>
        /// Takes serialized data, deserializes it and sets the detection features the object holds to it
        /// </summary>
        /// <param name="json"></param>
        public void Deserialize(string json)
        {
            _detectionFeatures = JsonSerializer.Deserialize<Dictionary<AudioProperty, Dictionary<DetectionStrength, List<string>>>>(json);
        }

        /// <summary>
        /// Adds a new ad detection feature to the collection. audioProperty is the property to be examined
        /// (e.g title or album name), matchValue is the value which you are comparing the property to to 
        /// see if it indicates an ad and detectionStrength is how closely propertyMatch needs to match in
        /// order to indicate an ad (exact or contains)
        /// </summary>
        public void Add(AudioProperty audioProperty, DetectionStrength detectionStrength, string matchValue)
        {
            _detectionFeatures[audioProperty][detectionStrength].Add(matchValue);
        }

        /// <summary>
        /// Removes an ad detection feature from the collection
        /// </summary>
        /// <param name="audioProperty"></param>
        /// <param name="detectionStrength"></param>
        /// <param name="matchValue"></param>
        public void Remove(AudioProperty audioProperty, DetectionStrength detectionStrength, string matchValue)
        {
            _detectionFeatures[audioProperty][detectionStrength].Remove(matchValue);
        }

        /// <summary>
        /// gets a list of match values for a given audioProperty and DetectionStrength. A match value is a
        /// value which, if it matches the audioProperty with the given detectionStrength, would indicate that
        /// an ad is playing
        /// </summary>
        public List<string> GetMatchValues(AudioProperty audioProperty, DetectionStrength detectionStrength)
        {
            return _detectionFeatures[audioProperty][detectionStrength];
        }

        public Dictionary<DetectionStrength, List<string>> GetMatchValuesForProperty(AudioProperty audioProperty)
        {
            return _detectionFeatures[audioProperty];
        }
    }
}
