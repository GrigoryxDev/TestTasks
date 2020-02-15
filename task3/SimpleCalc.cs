using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace SimpleCalc
{
    class SimpleCalc
    {
        static void Main(string[] args)
        {
            WriteLine(Calc(ReadLine()));
        }
        static string Calc(string res)
        {
            string[] inputValues = res.Split(' ');
            string[] operators = new string[] { "+", "-", "*", "/" };
            Stack<int> stack = new Stack<int>();
            int operand;
            for (int i = 0; i < inputValues.Length; i++)
            {
                if (!operators.Contains(inputValues[i]))
                {
                    stack.Push(int.Parse(inputValues[i]));
                }
                else //if char is operator
                {
                    {
                        switch (inputValues[i])
                        {
                            case "+":
                                stack.Push(stack.Pop() + stack.Pop());
                                break;
                            case "-":
                                operand = stack.Pop();
                                stack.Push(stack.Pop() - operand);
                                break;
                            case "*":
                                stack.Push(stack.Pop() * stack.Pop());
                                break;
                            case "/":
                                operand = stack.Pop();
                                if (operand != 0)
                                {
                                    stack.Push(stack.Pop() / operand);
                                }
                                else
                                {
                                    return "0";
                                }
                                break;
                        }
                    }
                }
            }
            return stack.Pop().ToString();
        }
    }
}
