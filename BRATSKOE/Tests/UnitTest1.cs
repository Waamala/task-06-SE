using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1_AlwaysTrue()
        {
            Assert.True(true);
        }

        [Fact]
        public void Test2_MathCheck()
        {
            Assert.Equal(4, 2 + 2);
        }

        [Fact]
        public void Test3_StringTest()
        {
            string test = "Hello";
            Assert.Equal(5, test.Length);
        }


        [Fact]
        public void Test4_FalseAssertion()
        {
            Assert.False(1 == 2);
        }
    }
}
