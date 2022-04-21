using NUnit.Framework;

[TestFixture]
public class HikerTest
{
    [Test]
    public void life_the_universe_and_everything()
    {
        // a simple example to start you off
        Assert.AreEqual("1", Hiker.Answer(1));
        Assert.AreEqual("2", Hiker.Answer(2));
        Assert.AreEqual("Fizz", Hiker.Answer(3));
        Assert.AreEqual("4", Hiker.Answer(4));
        Assert.AreEqual("Buzz", Hiker.Answer(5));
        Assert.AreEqual("Fizz", Hiker.Answer(6));
        Assert.AreEqual("7", Hiker.Answer(7));
        Assert.AreEqual("8", Hiker.Answer(8));
        Assert.AreEqual("Fizz", Hiker.Answer(9));
        Assert.AreEqual("Buzz", Hiker.Answer(10));
        Assert.AreEqual("11", Hiker.Answer(11));
        Assert.AreEqual("Fizz", Hiker.Answer(12));
        Assert.AreEqual("13", Hiker.Answer(13));
        Assert.AreEqual("14", Hiker.Answer(14));
        Assert.AreEqual("FizzBuzz", Hiker.Answer(15));
        Assert.AreEqual("16", Hiker.Answer(16));
        Assert.AreEqual("17", Hiker.Answer(17));
        Assert.AreEqual("Fizz", Hiker.Answer(18));
        Assert.AreEqual("19", Hiker.Answer(19));
        Assert.AreEqual("Buzz", Hiker.Answer(20));
        Assert.AreEqual("Fizz", Hiker.Answer(21));

        
    }
}
