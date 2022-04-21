public class RomanChanger
{
    public static int roman_to_int(string str1)
        {
            var num = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                if (i > 0 && find_value(str1[i]) > find_value(str1[i - 1]))
                {
                    num += find_value(str1[i]) - find_value(str1[i - 1]) * 2;
                }
                else
                {
                    num += find_value(str1[i]);
                }
            }

            return num;
        }
    public static int find_value(char chr)
        {
            switch (chr)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                default: return 0;
            }
        }
    
  
}
