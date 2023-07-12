using System.Collections.Generic;

#if !UNITY_ANDROID
using System.IO;
using System.Net;
using System.Xml;
using UnityEngine;
#endif

namespace ShizoGames.PlayerPrefsAccessor.Accessors
{
    public sealed class AndroidAccessor : PPrefsAccessorBase
    {
        public override List<PPrefsEntry> Retrieve()
        {
#if UNITY_ANDROID
            var playerPrefsEntries = new List<PPrefsEntry>();

            var path = $"/data/data/{Application.identifier}/shared_prefs/{Application.identifier}.v2.playerprefs.xml";

            var xmlDoc = new XmlDocument();
            var xmlText = string.Empty;

            using (var file = File.Open(path, FileMode.Open))
            {
                using (var reader = new StreamReader(file))
                {
                    string line = null;
                    
                    do
                    {
                        line = reader.ReadLine();
                        xmlText += line + "\n";
                    } while (line != null);
                }
            }

            xmlDoc.LoadXml(xmlText);
            var baseNode = xmlDoc.DocumentElement;

            if (baseNode == null) return playerPrefsEntries;

            foreach (XmlNode node in baseNode.ChildNodes)
            {
                var key = WebUtility.UrlDecode(node.Attributes?["name"].Value);

                switch (node.Name)
                {
                    case "string":
                        var stringValue = PlayerPrefs.GetString(key);
                        
                        playerPrefsEntries.Add(new PPrefsEntry(PlayerPrefsType.String, key, stringValue));
                        break;
                    case "float":
                        var floatValue = PlayerPrefs.GetFloat(key).ToString();
                        
                        playerPrefsEntries.Add(new PPrefsEntry(PlayerPrefsType.Float, key, floatValue));
                        break;
                    case "int":
                        var intValue = PlayerPrefs.GetInt(key).ToString();
                        
                        playerPrefsEntries.Add(new PPrefsEntry(PlayerPrefsType.Int, key, intValue));
                        break;
                }
            }

            return playerPrefsEntries;
#else
            return null;
#endif
        }
    }
}