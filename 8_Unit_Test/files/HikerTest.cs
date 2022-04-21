using NUnit.Framework;
using System;

[TestFixture]
public class HikerTest
{
    [Test]
    public void test_balance()
    { 
        String c = "{{)(}}";
        
        String ans = Hiker.Balance(c);
        
        Assert.AreEqual(c+" is not balanced", ans);
    }
    
    public void test2_balance()
    { 
        String c = "[({})]";
        
        String ans = Hiker.Balance(c);
        
        Assert.AreEqual(c+" is balanced", ans);
    }
    public void test3_balance()
    { 
        String c = "{}([])";
        
        String ans = Hiker.Balance(c);
        
        Assert.AreEqual(c+" is balanced", ans);
    }
     public void test4_balance()
    { 
        String c = "{()}[[{}]]";
        
        String ans = Hiker.Balance(c);
        
        Assert.AreEqual(c+" is balanced", ans);
    }
}
