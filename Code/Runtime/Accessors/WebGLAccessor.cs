using System.Collections.Generic;

#if UNITY_WEBGL

#endif

namespace KDebugger.Plugins.ShizoGames.PlayerPrefsAccessor.Accessors
{
    public sealed class WebGLAccessor : PPrefsAccessorBase
    {
        public override List<PPrefsEntry> Retrieve()
        {
#if UNITY_WEBGL
            return null;
#else
            return null;
#endif
        }
    }
}