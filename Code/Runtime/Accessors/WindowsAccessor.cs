using System.Collections.Generic;

#if !(UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN) && !(NET_STANDARD || NET_STANDARD_2_0 || NET_STANDARD_2_1)
#else
using UnityEngine;
#endif

namespace ShizoGames.PlayerPrefsAccessor.Accessors
{
    public sealed class WindowsAccessor : PPrefsAccessorBase
    {
        public override List<PPrefsEntry> Retrieve()
        {
#if !(UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN) && !(NET_STANDARD || NET_STANDARD_2_0 || NET_STANDARD_2_1)

#if UNITY_EDITOR_WIN
            var registryKey = Microsoft.Win32.Registry.CurrentUser
                .OpenSubKey($"Software\\Unity\\UnityEditor\\{Application.companyName}\\{Application.productName}", true);
#else
            var registryKey = Microsoft.Win32.Registry.CurrentUser
                .OpenSubKey($"Software\\{Application.companyName}\\{Application.productName}", true);
#endif

            if (registryKey == null) return null;

            var valueNames = registryKey.GetValueNames();

            var playerPrefsEntries = new List<PPrefsEntry>();

            foreach (var key in valueNames)
            {
                var index = key.LastIndexOf('_');
                var keyName = index == -1 ? key : key.Remove(index, key.Length - index);

                switch (registryKey.GetValue(key))
                {
                    case int:
                    case long:
                    {
                        if (PlayerPrefs.GetInt(keyName, -1) == -1 && PlayerPrefs.GetInt(keyName, 0) == 0)
                        {
                            var value = PlayerPrefs.GetFloat(keyName).ToString();
                            
                            playerPrefsEntries.Add(new PPrefsEntry(PlayerPrefsType.Float, keyName, value));
                        }
                        else if (PlayerPrefs.GetFloat(keyName, -1) == -1 && PlayerPrefs.GetFloat(keyName, 0) == 0)
                        {
                            var value = PlayerPrefs.GetInt(keyName).ToString();
                            
                            playerPrefsEntries.Add(new PPrefsEntry(PlayerPrefsType.Int, keyName, value));
                        }

                        break;
                    }
                    case byte[]:
                    {
                        var value = PlayerPrefs.GetString(keyName);
                        
                        playerPrefsEntries.Add(new PPrefsEntry(PlayerPrefsType.String, keyName, value));

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