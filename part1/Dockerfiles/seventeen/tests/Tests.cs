using Xunit;

namespace TestSpace
{
    public class Tests 
    {

      [Fact]
      public void Passing()
      {
        Assert.Equal(4, Add(2, 2));
      }

      [Fact]
      public void Failing() 
      {
        Assert.Equal(5, Add(2, 2));
      }

      int Add(int x, int y) 
      {
        return x + y;
      }
    }
}