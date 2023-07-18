namespace KDebugger.Plugins.ShizoGames.PlayerPrefsAccessor
{
    public readonly struct PPrefsEntry
    {
        public readonly PlayerPrefsType Type;
        public readonly string Key;
        public readonly string Value;

        public PPrefsEntry(PlayerPrefsType type, string key, string value)
        {
            Type = type;
            Key = key;
            Value = value;
        }
    }

    public enum PlayerPrefsType
    {
        String,
        Float,
        Int,
    }
}