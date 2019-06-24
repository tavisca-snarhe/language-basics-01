using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            string num1 = equation.Split("*")[0];
            string num2 = equation.Split("*")[1].Split("=")[0];
            string ans = equation.Split("=")[1];
            string res;
            int index;

            if (num1.Contains("?"))
            {
                if (Int32.Parse(ans) % Int32.Parse(num2) == 0)
                {
                    res = (Int32.Parse(ans) / Int32.Parse(num2)).ToString();
                    index = num1.IndexOf("?");
                    if (string.Equals(res, num1.Replace('?', res[index])))
                        return Int32.Parse(res[index].ToString());
                }
            }
            else if (num2.Contains("?"))
            {
                if (Int32.Parse(ans) % Int32.Parse(num1) == 0)
                {
                    res = (Int32.Parse(ans) / Int32.Parse(num1)).ToString();
                    index = num2.IndexOf("?");
                    if (string.Equals(res, num2.Replace('?', res[index])))
                        return Int32.Parse(res[index].ToString());
                }
            }
            else if (ans.Contains("?"))
            {
                res = (Int32.Parse(num1) * Int32.Parse(num2)).ToString();
                index = ans.IndexOf("?");
                if (string.Equals(res, ans.Replace('?', res[index])))
                    return Int32.Parse(res[index].ToString());
            }

            return -1;
        }
    }
}
