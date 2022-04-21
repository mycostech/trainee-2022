using NUnit.Framework;

[TestFixture]
public class FizzBuzzTest
{
    [Test]
    public void FizzBuzz_One_One()
    {
        Assert.AreEqual("1", FizzBuzz.oneLine(1));
    }

    [Test]
    public void FizzBuzz_Three_Fizz()
    {
        Assert.AreEqual("Fizz", FizzBuzz.oneLine(3));
    }

    [Test]
    public void FizzBuzz_Five_Buzz()
    {
        Assert.AreEqual("Buzz", FizzBuzz.oneLine(5));
    }
    [Test]
    public void FizzBuzz_FiveTeen_FizzBuzz()
    {
        Assert.AreEqual("FizzBuzz", FizzBuzz.oneLine(15));
    }
    
    [Test]
    public void FizzBuzz_Thirty_FizzBuzz()
    {
        Assert.AreEqual("FizzBuzz", FizzBuzz.oneLine(30));
    }
    [Test]
    public void FizzBuzz_OneToTen_FizzBuzz()
    {
        Assert.AreEqual("1\n2\nFizz\n4", FizzBuzz.FizzBuzzProblem(4));
    }
    
}
