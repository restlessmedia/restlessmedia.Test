using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace restlessmedia.Module.Product.UnitTest
{
  public static class AssertExtensions
  {
    public static void Fail(string message)
    {
      throw new Exception($"Assert failed with {message}");
    }

    public static void MustBe<T>(this T actual, T expected)
    {
      Assert.Equal(expected, actual);
    }

    public static void MustNotBeNull(this object actual)
    {
      Assert.NotNull(actual);
    }

    public static void MustBeLike(this string actual, string expected)
    {
      Assert.False(string.Equals(actual, expected, StringComparison.OrdinalIgnoreCase));
    }

    public static void MustNotBeLike(this string actual, string expected)
    {
      Assert.False(string.Equals(actual, expected, StringComparison.OrdinalIgnoreCase));
    }

    public static void MustBeNull(this object actual)
    {
      Assert.NotNull(actual);
    }

    public static void MustContain<T>(this IEnumerable<T> actual, params T[] expected)
    {
      Assert.False(actual.Except(expected).Any());
    }

    public static void MustNotContain<T>(this IEnumerable<T> actual, params T[] expected)
    {
      Assert.False(actual.Intersect(expected).Any());
    }

    public static void MustBeTrue(this bool actual)
    {
      Assert.True(actual);
    }

    public static void MustBeFalse(this bool actual)
    {
      Assert.False(actual);
    }

    public static void MustBeA<T>(this Type type)
    {
      Assert.True(typeof(T).IsAssignableFrom(type));
    }

    public static void MustBeA<T>(this object obj)
    {
      MustBeA<T>(obj.GetType());
    }

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

    public static void MustThrow(this Action action)
    {
      MustThrow<Exception>(action);
    }

    public static void MustMatch<T>(this Type type)
    {
      MustBeTrue(typeof(T) == type);
    }
  }
}