using System;
using System.Collections.Generic;
using Xunit;

namespace hw
{
    public class UnitTest1
    {
        /* 
        Write a program that prints the numbers from 1 to 100. 
        But for multiples of three print "Fizz" instead of the number and for the multiples of five print "Buzz".
        For numbers which are multiples of both three and five print "FizzBuzz".
        */

        // Test for any number that is a multiple of 3 only
        [Fact]
        public void FizzBuzz_AnyNumberThatIsMultipleOfOnly3_ReturnFizz()
        {
            // Arrange
            List<int> number = new List<int>();
            for(int i = 1; i <= 100; i++)
            {
                if(i % 3 == 0 && i % 5 != 0)
                {
                    number.Add(i);
                }
            }
            string expected = "Fizz";

            // Act
            for(int i = 0; i < number.Count; i++)
            {
                string actual = FizzBuzz.FizzBuzzer(number[i]);

                // Assert
                Assert.Equal(expected, actual);
            }
        }

        // Test for any number that is a multiple of 5 only
        [Fact]
        public void FizzBuzz_AnyNumberThatIsMultipleOfOnly5_ReturnBuzz()
        {
            // Arrange
            List<int> number = new List<int>();
            for(int i = 1; i <= 100; i++)
            {
                if(i % 5 == 0 && i % 3 != 0)
                {
                    number.Add(i);
                }
            }
            string expected = "Buzz";

            // Act
            for(int i = 0; i < number.Count; i++)
            {
                string actual = FizzBuzz.FizzBuzzer(number[i]);

                // Assert
                Assert.Equal(expected, actual);
            }
        }

        // Test for any number that is multiple of 3 and 5
        [Fact]
        public void FizzBuzz_AnyNumberFrom1to100_ReturnValueAccordingToFizzBuzzPrinciple()
        {
            // Arrange
            List<int> numbers = new List<int>();
            for(int i = 0; i < 100; i++)
            {
                numbers.Add(i + 1);
            }
            while(numbers.Count > 0)
            {
                int number = numbers[0];
                numbers.RemoveAt(0);
                if(number % 3 == 0 && number % 5 == 0)
                {
                    string expected = "FizzBuzz";
                    string actual = FizzBuzz.FizzBuzzer(number);

                    // Assert
                    Assert.Equal(expected, actual);
                }
                else if(number % 3 == 0)
                {
                    string expected = "Fizz";
                    string actual = FizzBuzz.FizzBuzzer(number);

                    // Assert
                    Assert.Equal(expected, actual);
                }
                else if(number % 5 == 0)
                {
                    string expected = "Buzz";
                    string actual = FizzBuzz.FizzBuzzer(number);

                    // Assert
                    Assert.Equal(expected, actual);
                }
            }
        }
    }

    public class FizzBuzz
    {
        public static string FizzBuzzer(int number)
        {
          if (number % 3 == 0 && number % 5 == 0)
          {
              return "FizzBuzz";
          }
          else if (number % 3 == 0)
          {
              return "Fizz";
          }
          else if (number % 5 == 0)
          {
              return "Buzz";
          }
          else
          {
              return number.ToString();
          }
        }
    }
}