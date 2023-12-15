namespace GlitchedPolygons.GlitchEd25519.BlazorWebApp;

public static class Constants
{
    public static class Bool
    {
        public const string TRUE = "true";
        public const string FALSE = "false";
    }
    
    public static class PreferenceIds
    {
        public const string DARK_THEME = "DarkTheme";
    }

    public static class Ed25519
    {
        public const int SHARED_SECRET_SIZE_BYTES = 32;
        public const int SIGNATURE_SIZE_BYTES = 64;
    }

    public static class AesGcm
    {
        public const int NONCE_SIZE_BYTES = 12;
        public const int MAC_SIZE_BYTES = 16;
        public const int TAG_SIZE_BYTES = 16;
        public const int KEY_SIZE_BYTES = 32;
    }
}