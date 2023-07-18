using System.Collections.Generic;

#if UNITY_STANDALONE_LINUX

#endif

namespace KDebugger.Plugins.ShizoGames.PlayerPrefsAccessor.Accessors
{
    public sealed class LinuxAccessor : PPrefsAccessorBase
    {
        public override List<PPrefsEntry> Retrieve()
        {
#if UNITY_STANDALONE_LINUX
            return null;
#else
            return null;
#endif
        }
    }
}