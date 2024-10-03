using System;
using System.Diagnostics;
using System.Numerics;
using Walgelijk;

namespace MIR;
/// <summary>
/// Includes methods for manual <see cref="Vector2"/> manipulation.
/// and old cpu supported methods instead of Walgelijk's utilities.
/// It also has some additional methods if you want to use it, I will use this
/// as an argument in my pull request reasoning
/// </summary>
public class MadnessVector2
{
    /// <summary>
    /// Returns a new normalized version of the provided <see cref="Vector2"/>, without hardware acceleration.
    /// and without changing the original <see cref="Vector2"/>. Also checks if the <see cref="Vector2"/>
    /// is NaN or Infinite.
    /// </summary>
    /// <param name="ToNormalize"> the <see cref="Vector2"/> to normalize.</param>
    /// <returns><see cref="Vector2"/></returns>
    public static Vector2 Normalize(Vector2 ToNormalize)
    {
        return ToNormalize / ToNormalize.Length();
    }

    /// <summary>
    /// A replacement for Walgelijk's built-in "GetRandomPointInCircle" method, utilising
    /// MadnessVector normalization instead.
    /// </summary>
    /// <param name="minRadius"></param>
    /// <param name="maxRadius"></param>
    /// <returns></returns>
    public static Vector2 RandomPointInCircle(float minRadius = 0f, float maxRadius = 1f)
    {
        return Normalize(new Vector2(Utilities.RandomFloat(-1f), Utilities.RandomFloat(-1f))) * Utilities.RandomFloat(minRadius, maxRadius);
    }
}
