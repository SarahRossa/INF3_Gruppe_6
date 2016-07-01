using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace EBNF_Parser
{
    class Parser
    {
        private bool result;
        private String expr;
        private ManualResetEvent doneEvent;

        public bool getResult { get { return result; } }
        public String getText { get { return expr; } }

        // Constructor of Parser
        // Parameters are the Expression to parse
        public Parser(String inputExpr, ManualResetEvent inputdoneEvent)
        {
            expr = inputExpr;
            doneEvent = inputdoneEvent;

        }
        // Method of the threadpool which parses the expression and gives a signal that it's done 
        public void ThreadPoolCallback(Object threadContext)
        {
            int threadIndex = (int)threadContext;
            Console.WriteLine("thread {0} started...", threadIndex);
            result = parse(expr);
            Console.WriteLine("thread {0} result calculated...", threadIndex);
            doneEvent.Set();
        }

        // Checks if the expression has clamps and  proves them. If their right, then it makes substrings. if not it parses the expression directly
        // The methods returns the result of the expression
        private bool parse(String input)
        {
            bool result = true;
            int counterLeft = 0;
            int counterRight = 0;

            if (input.Contains("(") || input.Contains(")"))
            {
                for (int right = 0; right < input.Length; right++)
                {
                    if (input[right] == '(')
                    {
                        counterLeft++;
                    }
                    if (input[right] == ')')
                    {
                        counterRight++;
                    }


                }
            }
            if (counterLeft == counterRight)
            {
                if (input.Contains("("))
                {
                    int left = 0;
                    for (int right = 0; right < input.Length; right++)
                    {
                        if (input[right] == '(')
                        {
                            left = right + 1;
                        }
                        else if (input[right] == ')')
                        {
                            String substringOfInput = input.Substring(left, right - left);
                            bool subExpression = parseExpression(substringOfInput);

                            if (subExpression)
                            {
                                input = input.Substring(0, left - 1) + "1" + input.Substring(right + 1);
                                result = parse(input);
                            }
                            else
                            {
                                result = false;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                result = false;
            }

            if (result)
            {
                result = parseExpression(input);
            }
            return result;
        }

        // Exppression function to parse an expression. Splitting the expression to terms and return the boolean result
        private bool parseExpression(String expression)
        {

            bool exp = false;
            if (expression == null)
            {
                throw new System.ArgumentException("There is no input, give me imput");
            }
            else
            {
                if (expression.Contains("+"))
                {

                    foreach (String term in expression.Split('+'))
                    {

                        exp = parseTerm(term);
                    }
                }
                else if (expression.Contains("-"))
                {
                    foreach (String term in expression.Split('-'))
                    {
                        exp = parseTerm(term);
                    }


                }
                else { exp = parseTerm(expression); }

                return exp;
            }




        }
        //cheking if its a right term and splitting it into factors
        // This returns the boolean result
        private bool parseTerm(String term)
        {
            bool exp = false;
            if (term == null)
            {
                throw new System.ArgumentException("Term is null");
            }
            else
            {
                if (term.Contains("*"))
                {

                    foreach (String factor in term.Split('*'))
                    {

                        exp = parseFactor(factor);
                    }
                }
                else if (term.Contains("/"))
                {
                    foreach (String factor in term.Split('/'))
                    {
                        exp = parseFactor(factor);

                    }


                }
                else { exp = parseFactor(term); }

            }

            return exp;


        }
        // This method proves if the factor is a variable or an constant 
        // This returns the boolean result
        private bool parseFactor(String factor)
        {
            bool result = false;

            if (parseVariable(factor))
            {
                result = true;
            }
            else
            {
                result = parseConstant(factor);

            }

            return result;
        }

        // This method checks if the input is an 'x','X','y','Y' 
        // This returns the boolean result
        private bool parseVariable(String variable)
        {
            bool result = false;
            if (variable.Equals("X") || variable.Equals("x") || variable.Equals("Y") || variable.Equals("y") || variable.Equals("Z") || variable.Equals("z"))
            {
                result = true;
            }

            return result;
        }
        // This method checks if every char of the String is a digit
        // This returns the boolean result

        private bool parseConstant(String constant)
        {
            bool exp = false;
            StringReader reader = new StringReader(constant);
            while (reader.Peek() != -1)
            {
                var digit = (char)reader.Read();
                if (isDigit(digit))
                {
                    exp = true;
                }
                else
                {
                    exp = false;
                    break;
                }

            }
            reader.Close();
            return exp;
        }

        // This method proves if the input char is a digit 
        // This returns the boolean result


        private bool isDigit(Char c)
        {
            return Char.IsDigit(c);
        }
    }
}