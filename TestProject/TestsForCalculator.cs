using CalculatorLibrary;
using Xunit;

namespace TestProject
{

    //ყველა ტესტ მეთოდი ეშვება საკუტარ TestsForCalculator ინსტანსზე => ყველა ტესტისატვის _calc ობიექტი
    //იქნება განსხვავებული და ეს მეთოდები, ანუ ტესტები, ერთმანეთს არ შეეხებიან.
    public class TestsForCalculator
    {
        public static int CreationOfTestForCalculator = 0;
        private readonly Calculator _calc;

        public TestsForCalculator()
        {
            _calc = new Calculator();
        }


        //Fact არის ტესტი, რომელსაც ბევრ case-ს არ ვუწერთ
        [Fact]
        public void AddTwoNumbersTest()//AAA Principle
        {
            //Arrage (creating variables)
            int number1 = 3;
            int number2 = 12;
            int realResult = 15;

            //Act (act the scenario)
            int actResult = _calc.Add(number1, number2);

            //Assert (compare real result to actual result)
            Assert.Equal(realResult, actResult);
        }


        //Theory არის ტესტი, რომელსაც ბევრ case-ს ვუწერთ გასატესტად და ამას ვაკეთებთ Theory ატრიბუტის
        //მეშვეობით
        [Theory]
        [InlineData(1,2,3)]
        [InlineData(0,0,0)]
        [InlineData(2,12,14)]
        [InlineData(2,4,6)]
        [InlineData(1,2,12)]//ამ ტესტზე გაასხავს, რადგან 1 + 2 ზე კალკულატორი დააბრუნებს 12-ს.
        public void AddTwoNumbersTheory(int number1, int number2, decimal expected)//AAA Principle
        {
            //Arrage (creating variables)

            //Act (act the scenario)
            int actResult = _calc.Add(number1, number2);

            //Assert (compare real result to actual result)
            Assert.Equal(expected, actResult);
        }

        [Theory]
        [MemberData(nameof(Cases))]
        public void AddTwoNumbersTheoryWithCollection(decimal expected, params int[] numbers)//AAA Principle
        {
            //Arrage (creating variables)

            //Act (act the scenario)
            int actResult = 0;
            foreach(int number in numbers)
            {
                actResult = _calc.Add(actResult, number);
            }

            //Assert (compare real result to actual result)
            Assert.Equal(expected, actResult);
        }

        public static IEnumerable<object[]> Cases()
        {
            yield return new object[] { 15, new int[] { 1, 2, 3, 4, 5 } };
            yield return new object[] { 37, new int[] { 23, 2, 3, 4, 5 } };
            yield return new object[] { 0, new int[] { 1, -1, 3, -3, 0 } };
        }

    }
}
