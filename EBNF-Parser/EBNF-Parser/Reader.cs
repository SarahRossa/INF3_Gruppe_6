using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBNF_Parser
{
    public class Reader
    {
        static StreamReader sr;
        static Parser p = new Parser();
        static bool isClosed = false;
        static bool done = false;

        public Reader(string s)
        {
            sr = new StreamReader(s);
        }

        public void parseDocument(Object stateInfo)
        {
            string s = "";
            while (!done)
            {
                if (!isClosed)
                {
                    if ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(p.parse(s) + " : " + s);
                    }
                    else
                    {
                        sr.Close();
                        isClosed = true;
                        done = true;
                    }
                }

            }
        }

        static string getLine()
        {
            string res = null;
            string s;
            if (!isClosed)
            {
                if ((s = sr.ReadLine()) != null)
                {
                    res = s;
                }
                else
                {
                    sr.Close();
                    isClosed = true;
                    done = true;
                }
            }

            return res;
        }
    }

}
