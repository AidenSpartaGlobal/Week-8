using CalculatorLib;
using System;
using TechTalk.SpecFlow;
using System.Linq;

namespace Calculator_BDD
{
    public class TableExtensions
    {
        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        public static List<int> ToList(Table table)
        {
            var list = new List<int>();
            foreach (var item in table.Rows)
            {
                list.Add(Int32.Parse(item[0]));
            }
            return list;
        }
    }

        [Binding]
    public class CalculatorStepDefinitions
    {
        private Calculator _calculator;
        private int _result;
        private Exception _stringResult;
        private List<int> _numList = new List<int>();

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator()
        {
            //throw new PendingStepException();
            _calculator = new Calculator();
        }

        [Given(@"I enter (.*) and (.*) into the calculator")]
        public void GivenIEnterAndIntoTheCalculator(int num1, int num2)
        {
            //throw new PendingStepException();
            _calculator.Num1 = num1;
            _calculator.Num2 = num2;
        }

        [Given(@"I enter the numbers below to a list")]
        public void GivenIEnterTheNumbersBelowToAList(Table table)
        {
            //throw new PendingStepException();
            _numList = TableExtensions.ToList(table);
            //_numList = table.Rows.Select(row => int.Parse(row["nums"])).ToList();

        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            //throw new PendingStepException();
            _result = _calculator.ADD();
        }

        [When(@"I press subtract")]
        public void WhenIPressSubtract()
        {
            //throw new PendingStepException();
            _result = _calculator.Subtract();
        }

        [When(@"I press multiply")]
        public void WhenIPressMultiply()
        {
            //throw new PendingStepException();
            _result = _calculator.Multiply();
        }

        [When(@"I press divide")]
        public void WhenIPressDivide()
        {
            //throw new PendingStepException();
            try
            {
                _result = _calculator.Divide();
            }
            catch(Exception exception)
            {
                _stringResult = exception;
            }

        }
        

        [When(@"I iterate through the list to add all the even numbers")]
        public void WhenIIterateThroughTheListToAddAllTheEvenNumbers()
        {
            _result = _calculator.SumOfNumbersDivisibleBy2(_numList);
        }


        [Then(@"a DivideByZero Exception should a DivideByZeroException when I press divide")]
        public void ThenADivideByZeroExceptionShouldADivideByZeroExceptionWhenIPressDivide()
        {
            //throw new PendingStepException();
            Assert.That(_stringResult, Is.TypeOf<DivideByZeroException>());
        }

        [Then(@"the exception should have the message ""([^""]*)""")]
        public void ThenTheExceptionShouldHaveTheMessage(string expected)
        {
            //throw new PendingStepException();
            Assert.That(_stringResult.Message, Is.EqualTo(expected));
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expected)
        {
            //throw new PendingStepException();
            Assert.That(_result, Is.EqualTo(expected));
        }
    }
}
