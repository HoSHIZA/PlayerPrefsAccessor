using System.Collections.Generic;

#if UNITY_STANDALONE_OSX
using System;
using KDebugger.Plugins.ShizoGames.PlayerPrefsAccessor.Utility;
using System.IO;
using UnityEngine;
#endif

namespace KDebugger.Plugins.ShizoGames.PlayerPrefsAccessor.Accessors
{
    public sealed class OSXAccessor : PPrefsAccessorBase
    {
        public override List<PPrefsEntry> Retrieve()
        {
#if UNITY_STANDALONE_OSX
            var path = Path.Combine(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Library/Preferences"), 
                $"unity.{Application.companyName}.{Application.productName}.plist");

            var parsed = Plist.readPlist(path) as Dictionary<string, object>;

            if (parsed == null) return null;

            var playerPrefsEntries = new List<PPrefsEntry>(parsed.Count);

            foreach (var pair in parsed)
            {
                switch (pair.Value)
                {
                    case double value:
                    {
                        playerPrefsEntries.Add(
                            new PPrefsEntry(PlayerPrefsType.Float, pair.Key, ((float) value).ToString()));
                        
                        break;
                    }
                    default:
                    {
                        playerPrefsEntries.Add(
                            new PPrefsEntry(PlayerPrefsType.Float, pair.Key, pair.Value.ToString()));
                        
                        break;
                    }
                }
            }

            return playerPrefsEntries;
#else
            return null;
#endif
        }
    }
}