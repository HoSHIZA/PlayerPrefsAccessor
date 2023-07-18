using System.Collections.Generic;
using KDebugger.Plugins.ShizoGames.PlayerPrefsAccessor.Accessors;

namespace KDebugger.Plugins.ShizoGames.PlayerPrefsAccessor
{
    public static class PPrefsAccessor
    {
        private static readonly PPrefsAccessorBase _accessor;
        
        private static bool? _isSupportedOnCurrentPlatform;
        public static bool IsSupportedOnCurrentPlatform => 
            _isSupportedOnCurrentPlatform ?? (bool) (_isSupportedOnCurrentPlatform = CheckSupportOnCurrentPlatform());
        
        static PPrefsAccessor()
        {
            _accessor =
#if UNITY_EDITOR_WIN || (UNITY_STANDALONE_WIN && (!UNITY_EDITOR_OSX && !UNITY_EDITOR_LINUX))
                new WindowsAccessor();
#elif UNITY_EDITOR_OSX || (UNITY_STANDALONE_OSX && (!UNITY_EDITOR_WIN && !UNITY_EDITOR_LINUX))
                new OSXAccessor();
#elif UNITY_EDITOR_LINUX || (UNITY_STANDALONE_LINUX && (!UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX))
                new LinuxAccessor();
#elif UNITY_ANDROID
                new AndroidAccessor();
#elif UNITY_IOS
                new IosAccessor();
#elif UNITY_WEBGL
                new WebGLAccessor();
#elif UNITY_WSA
                new WsaAccessor();
#else
                null;
#endif
        }
        
        public static List<PPrefsEntry> RetrieveUsingCurrentPlatformAccessor()
        {
            return _accessor?.Retrieve();
        }
        
        private static bool CheckSupportOnCurrentPlatform()
        {
            return RetrieveUsingCurrentPlatformAccessor() != null;
        }
    }
}