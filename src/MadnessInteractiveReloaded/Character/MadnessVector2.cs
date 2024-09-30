using System;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using Newtonsoft.Json.Serialization;
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
    //Debug mode: ON

    /// <summary>
    /// Transforms the given <see cref="Vector2"/> into a normalized version of its self, without cloning.
    /// </summary>
    /// <param name="toNormalize"></param>
    public static void SelfNormalize(ref Vector2 toNormalize)
    {
        toNormalize = toNormalize / toNormalize.Length();
    }

    /// <summary>
    /// Checks if one or both of the values of the <see cref="Vector2"/> is <see cref="float.NaN"/>,
    /// and returns true if that is so, and false if not.
    /// </summary>
    /// <param name="toCheck"> the <see cref="Vector2"/> to check.</param>
    /// <returns><see cref="bool"/></returns>
    public static bool CheckNaN(Vector2 toCheck)
    {
        if (float.IsNaN(toCheck.X) || float.IsNaN(toCheck.Y))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Checks if one or both of the values of the <see cref="Vector2"/> is <see cref="float.PositiveInfinity"/> or <see cref="float.NegativeInfinity"/>,
    /// and returns true if that is so, and false if not.
    /// </summary>
    /// <param name="toCheck"> the <see cref="Vector2"/> to check.</param>
    /// <returns><see cref="bool"/></returns>
    public static bool CheckInfinity(Vector2 toCheck)
    {
        if (float.IsInfinity(toCheck.X) || float.IsInfinity(toCheck.Y))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Returns a new normalized version of the provided <see cref="Vector2"/>, without hardware acceleration.
    /// and without changing the original <see cref="Vector2"/>. Also checks if the <see cref="Vector2"/>
    /// is NaN or Infinite.
    /// </summary>
    /// <param name="ToNormalize"> the <see cref="Vector2"/> to normalize. 0.1 if failed to normalize.</param>
    /// <returns><see cref="Vector2"/></returns>
    public static Vector2 Normalize(Vector2 ToNormalize)
    {
        Vector2 NormalizedVector = ToNormalize / ToNormalize.Length();
        return NormalizedVector;
    }

    /// <summary>
    /// A replacement for Walgelijk's built-in "GetRandomPointInCircle" method, utilising
    /// MadnessVector normalization instead.
    /// </summary>
    /// <param name="minRadius"></param>
    /// <param name="maxRadius"></param>
    /// <returns></returns>
    public static Vector2 GetRandomPointInCircle(float minRadius = 0f, float maxRadius = 1f)
    {
        return Normalize(new Vector2(Utilities.RandomFloat(-1f), Utilities.RandomFloat(-1f))) * Utilities.RandomFloat(minRadius, maxRadius);
    }
}
