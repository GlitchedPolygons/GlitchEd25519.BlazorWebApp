using GlitchedPolygons.ExtensionMethods;

namespace GlitchedPolygons.GlitchEd25519.BlazorWebApp.ExtensionMethods;

/// <summary>
/// CRC-32 extension methods.
/// </summary>
public static class CRC32ExtensionMethod
{
    /// <summary>
    /// Compute CRC-32 of a <see cref="String"/>.
    /// </summary>
    /// <param name="string"><see cref="String"/> to feed into CRC-32.</param>
    /// <returns>CRC32 of the passed parameter (positive integer number).</returns>
    public static uint CRC32(this string @string)
    {
        return CRC32(@string.UTF8GetBytes());
    }
    
    /// <summary>
    /// Compute CRC-32 of some binary data.
    /// </summary>
    /// <param name="bytes">Binary data to feed into CRC-32.</param>
    /// <returns>CRC32 of the passed parameter (positive integer number).</returns>
    public static uint CRC32(this ReadOnlySpan<byte> bytes)
    {
        return System.IO.Hashing.Crc32.HashToUInt32(bytes);
    }
}