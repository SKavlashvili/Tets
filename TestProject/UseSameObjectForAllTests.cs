using CalculatorLibrary;
using Xunit;

namespace TestProject
{
    public class UseSameObjectForAllTests : IClassFixture<TEST>
    {
        public static int CreationOfTestForCalculator = 0;
        public TEST _test { get; set; }
        public UseSameObjectForAllTests(TEST test)
        {
            CreationOfTestForCalculator++;
            _test = test;
        }

        [Theory]
        [InlineData(1,1)]
        [InlineData(2,1)]
        [InlineData(3,1)]
        public void TestSomeData(int Amount, int TESTCreationalAmount)
        {
            //CreationOfTestForCalculator -> ეს იზრდება => ყველა InlineData-ზე ცალკე
            // UseSameObjectForAllTests-ის ინსტანსი იქმნება, მაგრამ IClassFixture-სგან ჩაინჯექტებული TEST
            //ინსტანსის გამო, ყოველ ჯერზე ვიყენებთ, ერთსა და იმავე TEST-ის ინსტანსს

            Assert.Equal(Amount, CreationOfTestForCalculator);
            Assert.Equal(TESTCreationalAmount, TEST.creationalAmount);
        }
    }
}
