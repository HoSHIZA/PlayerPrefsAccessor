using System.Collections.Generic;

namespace KDebugger.Plugins.ShizoGames.PlayerPrefsAccessor
{
    public abstract class PPrefsAccessorBase
    {
        public abstract List<PPrefsEntry> Retrieve();
    }
}