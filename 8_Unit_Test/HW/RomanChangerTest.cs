using NUnit.Framework;
using System;
[TestFixture]
public class RomanChangerTest
{
    //Funtional Test
    [Test]
    public void RomanToIntTest()
    {
        Assert.AreEqual(8, RomanChanger.roman_to_int("VIII"));
        Assert.AreEqual(9, RomanChanger.roman_to_int("IX"));
        Assert.AreEqual(20, RomanChanger.roman_to_int("XX"));
        Assert.AreEqual(40, RomanChanger.roman_to_int("XL"));
        Assert.AreEqual(90, RomanChanger.roman_to_int("XC"));
        Assert.AreEqual(800, RomanChanger.roman_to_int("DCCC"));
        Assert.AreEqual(2000, RomanChanger.roman_to_int("MM"));
        Assert.AreEqual(2008, RomanChanger.roman_to_int("MMVIII"));
    }
    
    [Test]
    public void findValueTest()
    {
        Assert.AreEqual(1, RomanChanger.roman_to_int("I"));
        Assert.AreEqual(5, RomanChanger.roman_to_int("V"));
        Assert.AreEqual(10, RomanChanger.roman_to_int("X"));
        Assert.AreEqual(50, RomanChanger.roman_to_int("L"));
        Assert.AreEqual(100, RomanChanger.roman_to_int("C"));
        Assert.AreEqual(500, RomanChanger.roman_to_int("D"));
        Assert.AreEqual(1000, RomanChanger.roman_to_int("M"));
    }
    
    //Type Exceptions
    [Test]
    public void RomanToIntNullTest()
    {
        Assert.Throws<NullReferenceException>(() => RomanChanger.roman_to_int(null));
    }
}
