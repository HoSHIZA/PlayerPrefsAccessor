using System.Collections.Generic;

#if UNITY_WSA

#endif

namespace ShizoGames.PlayerPrefsAccessor.Accessors
{
    public sealed class WsaAccessor : PPrefsAccessorBase
    {
        public override List<PPrefsEntry> Retrieve()
        {
#if UNITY_WSA
            return null;
#else
            return null;
#endif
        }
    }
}