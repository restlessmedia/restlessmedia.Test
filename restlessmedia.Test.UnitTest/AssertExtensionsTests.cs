using System;
using Xunit;

namespace restlessmedia.Test.UnitTest
{
  public class AssertExtensionsTests
  {
    [Fact]
    public void MustBeLike()
    {
      "foo".MustBeLike("foo");
    }

    [Fact]
    public void MustNotBeLike()
    {
      "foo".MustNotBeLike("bar");
    }

    [Fact]
    public void MustBeNull()
    {
      ((string)null).MustBeNull();
    }

    [Fact]
    public void MustNotBeNull()
    {
      "foo".MustNotBeNull();
      DateTime.Now.MustNotBeNull();
    }

    [Fact]
    public void Fail()
    {
      Assert.Throws<Exception>(() => AssertExtensions.Fail(""));
    }

    [Fact]
    public void MustContain()
    {
      new[] { "foo", "bar" }.MustContain("foo", "bar");
    }

    [Fact]
    public void MustNotContain()
    {
      new[] { "foo", "bar" }.MustNotContain("one", "two");
    }

    [Fact]
    public void MustBeTrue()
    {
      true.MustBeTrue();
    }

    [Fact]
    public void MustBeFalse()
    {
      false.MustBeFalse();
    }

    [Fact]
    public void MustBeA()
    {
      DateTime.Now.MustBeA<DateTime>();
    }

    [Fact]
    public void MustBeA_type()
    {
      typeof(DateTime).MustBeA<DateTime>();
    }

    [Fact]
    public void MustNotThrow()
    {
      new Action(() => { }).MustNotThrow();
    }

    [Fact]
    public void MustThrow()
    {
      new Action(() => throw new Exception()).MustThrow();
    }

    [Fact]
    public void MustMatch()
    {
      typeof(DateTime).MustMatch<DateTime>();
    }
  }
}