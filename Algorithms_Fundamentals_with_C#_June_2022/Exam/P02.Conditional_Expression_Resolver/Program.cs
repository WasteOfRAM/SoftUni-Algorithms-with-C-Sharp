using System;
using System.Linq;

namespace P02.Conditional_Expression_Resolver
{
    internal class Program
    {
        static void Main()
        {
            string expression = Console.ReadLine();

            int result = ConditionalExpressionResolver(expression);

            Console.WriteLine(result);
        }

        private static int ConditionalExpressionResolver(string expression)
        {
            int result = 0;

            if (int.TryParse(expression.Trim(), out result))
                return result;

            string[] expressionSplit = expression.Split("?", 2).ToArray();

            if (expressionSplit[0].Trim() == "t")
            {
                string[] subExpresionSplit = expressionSplit[1].Split(":").ToArray();
                result = ConditionalExpressionResolver(subExpresionSplit[0].Trim());
            }
            else if (expressionSplit[0].Trim() == "f")
            {
                //string[] subExpresionSplit = expressionSplit[1].Split(":").ToArray();
                int index = expressionSplit[1].LastIndexOf(":");
                
                result = ConditionalExpressionResolver(expressionSplit[1].Substring(index + 1).Trim());
            }

            return result;
        }
    }
}


// f ? 4 : t ? 2 : 1      2

// f ? f ? f ? 4 : 1 : 2 : 3     3

// t ? t ? f ? 4 : 1 : 2 : 3     1

// (t ? (f ? (t ? 4 : 1) : 2) : 3)