using Api;

namespace TestProject1
{
    public class UtilsTests
    {
        [Fact]
        public void ShouldBeTrueIfAGreaterThanB()
        {
            int a = 2;
            int b = 1;

            bool sut = Utils.greaterThan(a, b);

            Assert.True(sut);
            Assert.IsType<bool>(sut);
        }

        [Fact]
        public void ShouldBeFalseIfBGreaterThanA()
        {
            int a = 1;
            int b = 2;

            bool sut = Utils.greaterThan(a, b);

            Assert.False(sut);
            Assert.IsType<bool>(sut);
        }

        [Fact]
        public void ShouldBeFalseIfAEqualsB()
        {
            int a = 2;
            int b = 2;

            bool sut = Utils.greaterThan(a, b);

            Assert.False(sut);
            Assert.IsType<bool>(sut);
        }

        [Fact]
        public void ShouldBeTrueIfAgreaterThanBAndBisNegative()
        {
            int a = 0;
            int b = -1;

            bool sut = Utils.greaterThan(a, b);

            Assert.True(sut);
            Assert.IsType<bool>(sut);
        }

        [Fact]
        public void ShouldBeTrueIfAgreaterThanBAndBothisNegative()
        {
            int a = -1;
            int b = -3;

            bool sut = Utils.greaterThan(a, b);

            Assert.True(sut);
            Assert.IsType<bool>(sut);
        }
    }
}