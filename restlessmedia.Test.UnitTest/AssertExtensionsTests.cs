using Xunit;

namespace restlessmedia.Test.UnitTest
{
  public class AssertExtensionsTests
  {
    [Fact]
    public void MustBeLike()
    {
      "foo".MustBeLike("bar");
    }
  }
}
