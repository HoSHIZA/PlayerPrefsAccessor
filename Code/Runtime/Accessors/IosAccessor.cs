using System.Collections.Generic;

#if UNITY_IOS

#endif

namespace ShizoGames.PlayerPrefsAccessor.Accessors
{
    public sealed class IosAccessor : PPrefsAccessorBase
    {
        public override List<PPrefsEntry> Retrieve()
        {
#if UNITY_IOS
            return null;
#else
            return null;
#endif
        }
    }
}