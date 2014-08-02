using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure
{
    public class MyLeet
    {
        public List<string> GenerateParentheses(int number)
        {
            List<string> results = new List<string>();

            GetParentheses(results, "", number, 0, 0);

            return results;
        }

        private void GetParentheses(List<string> results, string oneResult, int number, int leftNumber, int rightNumber)
        {

            if (leftNumber == number && rightNumber == number)
            {
                results.Add(oneResult);
                return;
            }

            if (leftNumber < number)
            {
                oneResult += "(";
                GetParentheses(results, oneResult, number, leftNumber + 1, rightNumber);
            }

            if (rightNumber < number && rightNumber < number)
            {                
                oneResult += ")";
                GetParentheses(results, oneResult, number, leftNumber, rightNumber + 1);
            }

        }
    }
}
