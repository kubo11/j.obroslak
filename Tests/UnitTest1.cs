namespace Tests
{
    public class UnitTest1
    {
        private readonly StringCalculator calc = new StringCalculator();
        [Fact]
        public void WhenEmptyStringProided_ShouldReturnZero()
        {
            Assert.Equal(0, calc.Add(""));
        }
        [Theory]
        [InlineData("342", 342)]
        [InlineData("12", 12)]
        [InlineData("0", 0)]
        public void WhenSingleNumberProvided_ShouldReturnThisNumber(string input, int output)
        {
            Assert.Equal(output, calc.Add(input));
        }
        [Theory]
        [InlineData("2,2", 4)]
        [InlineData("0,0", 0)]
        [InlineData("123,23", 146)]
        public void WhenTwoNumbersSeparatedBySemicolonProvided_ShouldReturnTheirSum(string input, int output)
        {
            Assert.Equal(output, calc.Add(input));
        }
        [Theory]
        [InlineData("2\n2", 4)]
        [InlineData("0\n0", 0)]
        [InlineData("123\n23", 146)]
        public void WhenTwoNumbersSeparatedByNewlineProvided_ShouldReturnTheirSum(string input, int output)
        {
            Assert.Equal(output, calc.Add(input));
        }
        [Theory]
        [InlineData("2\n2,2", 6)]
        [InlineData("0\n0\n0", 0)]
        [InlineData("123,23\n100", 246)]
        public void WhenThreeNumbersSeparatedByNewlineProvided_ShouldReturnTheirSum(string input, int output)
        {
            Assert.Equal(output, calc.Add(input));
        }
        [Theory]
        [InlineData("abc")]
        [InlineData("-2d,2s,1a")]
        [InlineData("a0d\n0ss\nasd0")]
        [InlineData("123,-23\n100")]
        public void WhenSuppliedNumbersAreInvalid_ThrowArgumentException(string input)
        {
            Assert.Throws<ArgumentException>(() => calc.Add(input));
        }
        [Theory]
        [InlineData("-2")]
        [InlineData("-1")]
        [InlineData("-1000")]
        public void WhenSuppliedNumbersAreNegative_ThrowArgumentOutOfRange(string input)
        {
            Assert.Throws<ArgumentException>(() => calc.Add(input));
        }
        [Theory]
        [InlineData("2000,2,2", 4)]
        [InlineData("1001", 0)]
        [InlineData("1234,123,321", 444)]
        public void WhenNumberGreaterThanOneThousandProvided_ShouldBeIgnored(string input, int output)
        {
            Assert.Equal(output, calc.Add(input));
        }
    }
}