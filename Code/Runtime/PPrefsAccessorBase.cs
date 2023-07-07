using System.Collections.Generic;

namespace ShizoGames.PlayerPrefsAccessor
{
    public abstract class PPrefsAccessorBase
    {
        public abstract List<PPrefsEntry> Retrieve();
    }
}