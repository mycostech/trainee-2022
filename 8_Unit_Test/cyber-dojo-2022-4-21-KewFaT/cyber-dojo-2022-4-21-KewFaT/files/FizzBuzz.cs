//ing System;

public class FizzBuzz
{
    public static string oneLine(int n)
    {
        string result = "";

        if (n%3 == 0)
        {
            result += "Fizz";
        }
        if (n%5 == 0)
        {
            result +=  "Buzz";
        }
        if (result == "")
        {
            result = n.ToString();
        }

        return result;
    }
    public static string [] Range(int start, int end)
    {
        int size = end-start+1;
        string[] result = new string[size];

        for (int i = 0; i < size; i++)
        {
            result[i] = oneLine(i+1);
        }
        return result;
    
    }
    
    public static string FizzBuzzProblem(int num)
    {
        string result = "";
        for (int i = 0; i < num; i++)
        {
            result += oneLine(i+1);
            if(i+1 != num)result += "\n";
        }
        System.Console.WriteLine(result);
        return result;
    }
}
