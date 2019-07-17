using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace restlessmedia.Test
{
  public static class AssertExtensions
  {
    /// <summary>
    /// Throws exception with given message.
    /// </summary>
    /// <param name="message"></param>
    public static void Fail(string message)
    {
      throw new Exception($"Assert failed with {message}");
    }

    /// <summary>
    /// Values are equal.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="actual"></param>
    /// <param name="expected"></param>
    public static void MustBe<T>(this T actual, T expected)
    {
      Assert.Equal(expected, actual);
    }

    /// <summary>
    /// Value isn't null.
    /// </summary>
    /// <param name="actual"></param>
    public static void MustNotBeNull(this object actual)
    {
      Assert.NotNull(actual);
    }

    /// <summary>
    /// The string does equal given the provided <see cref="StringComparison"/>.
    /// </summary>
    /// <param name="actual"></param>
    /// <param name="expected"></param>
    /// <param name="stringComparison"></param>
    public static void MustBeLike(this string actual, string expected, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
    {
      MustBeTrue(string.Equals(actual, expected, stringComparison));
    }

    /// <summary>
    /// The string does not equal given the provided <see cref="StringComparison"/>.
    /// </summary>
    /// <param name="actual"></param>
    /// <param name="expected"></param>
    /// <param name="stringComparison"></param>
    public static void MustNotBeLike(this string actual, string expected, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
    {
      MustBeFalse(string.Equals(actual, expected, stringComparison));
    }

    /// <summary>
    /// Value must be null.
    /// </summary>
    /// <param name="actual"></param>
    public static void MustBeNull(this object actual)
    {
      Assert.Null(actual);
    }

    /// <summary>
    /// The list does contain the expected values.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="actual"></param>
    /// <param name="expected"></param>
    public static void MustContain<T>(this IEnumerable<T> actual, params T[] expected)
    {
      Assert.False(actual.Except(expected).Any());
    }

    /// <summary>
    /// The list does not contain the expected values.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="actual"></param>
    /// <param name="expected"></param>
    public static void MustNotContain<T>(this IEnumerable<T> actual, params T[] expected)
    {
      Assert.False(actual.Intersect(expected).Any());
    }

    /// <summary>
    /// The value is true.
    /// </summary>
    /// <param name="actual"></param>
    public static void MustBeTrue(this bool actual)
    {
      Assert.True(actual);
    }

    /// <summary>
    /// The value is false.
    /// </summary>
    /// <param name="actual"></param>
    public static void MustBeFalse(this bool actual)
    {
      Assert.False(actual);
    }

    /// <summary>
    /// The type is assignable from <see cref="T"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type"></param>
    public static void MustBeA<T>(this Type type)
    {
      Assert.True(typeof(T).IsAssignableFrom(type));
    }

    /// <summary>
    /// Obj is assignable from <see cref="T"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    public static void MustBeA<T>(this object obj)
    {
      MustBeA<T>(obj.GetType());
    }

    /// <summary>
    /// The action does not throw.
    /// </summary>
    /// <param name="action"></param>
    public static void MustNotThrow(this Action action)
    {
      Exception exception = null;

      try
      {
        action();
      }
      catch (Exception e)
      {
        exception = e;
      }

      exception.MustBeNull();
    }

    /// <summary>
    /// The action throws <see cref="T"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="action"></param>
    public static void MustThrow<T>(this Action action)
      where T : Exception
    {
      Exception exception = null;

      try
      {
        action();
      }
      catch (T e)
      {
        exception = e;
      }

      exception.MustNotBeNull();
    }

    /// <summary>
    /// The action throws.
    /// </summary>
    /// <param name="action"></param>
    public static void MustThrow(this Action action)
    {
      MustThrow<Exception>(action);
    }

    /// <summary>
    /// The types equals <see cref="T"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type"></param>
    public static void MustMatch<T>(this Type type)
    {
      MustBe(typeof(T), type);
    }
  }
}