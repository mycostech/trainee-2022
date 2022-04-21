using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

public class Hiker
{
    public static string Balance(String check)
    {
        Stack<char> stack = new Stack<char>();
         for (int i = 0; i < check.Length; i++){
            char character = check[i];
            if (character == '[' || character == '{' || character == '(') stack.Push(character);
            else if (character == ']' || character == '}' || character == ')'){
                if (!stack.Any()) return check+" is not balanced";;
                switch (character)
                {
                    case ']':
                        if (stack.Pop() != '[')
                            return check+" is not balanced";
                        break;
                    case '}':
                        if (stack.Pop() != '{')
                            return check+" is not balanced";
                        break;
                    case ')':
                        if (stack.Pop() != '(')
                            return check+" is not balanced";
                        break;
                    default:
                        break;
                }
               }
            }
        if (!stack.Any())
            return check+" is balanced";
        return check+" is not balanced";
    }
}
