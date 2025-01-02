namespace GlitchedPolygons.GlitchEd25519.BlazorWebApp.Models;

/// <summary>
/// Ed25519 user data instance.
/// </summary>
public class UserData
{
    /// <summary>
    /// Empty (default) <see cref="UserData"/> instance.
    /// </summary>
    public static readonly UserData Empty = new();
    
    public Dictionary<string, string> Keyring { get; set; } = new();
}