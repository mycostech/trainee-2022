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
            List<string> expected = new List<string>() { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz", "16", "17", "Fizz", "19", "Buzz", "Fizz", "22", "23", "Fizz", "Buzz", "26", "Fizz", "28", "29", "FizzBuzz", "31", "32", "Fizz", "34", "Buzz", "Fizz", "37", "38", "Fizz", "Buzz", "41", "Fizz", "43", "44", "FizzBuzz", "46", "47", "Fizz", "49", "Buzz", "Fizz", "52", "53", "Fizz", "Buzz", "56", "Fizz", "58", "59", "FizzBuzz", "61", "62", "Fizz", "64", "Buzz", "Fizz", "67", "68", "Fizz", "Buzz", "71", "Fizz", "73", "74", "FizzBuzz", "76", "77", "Fizz", "79", "Buzz", "Fizz", "82", "83", "Fizz", "Buzz", "86", "Fizz", "88", "89", "FizzBuzz", "91", "92", "Fizz", "94", "Buzz", "Fizz", "97", "98", "Fizz", "Buzz" };
            List<string> actual = new List<string>();
            // Act
            for (int i = 1; i <= 100; i++)
            {
                actual.Add(FizzBuzz.FizzBuzzer(i));
            }
            // Assert
            Assert.Equal(expected, actual);
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