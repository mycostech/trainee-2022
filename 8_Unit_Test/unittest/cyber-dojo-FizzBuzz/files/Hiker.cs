public class Hiker
{
    public static string Answer(int num)
    {
        string res = "";
        if(num%3 == 0){
            res += "Fizz";
        }
        if(num%5 == 0){
            res += "Buzz";
        }
        if(num%3 != 0 && num%5 != 0){
            res = num.ToString();
        }
        return res;
    }
}
