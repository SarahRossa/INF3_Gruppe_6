using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EBNF_Parser
{
    class Program
    {
        // Main method and Inizialisation of the Threadpool
        static void Main(string[] args)
        {
            string[] exp = System.IO.File.ReadAllLines("C:/expressions1.txt");

            int Expressions = exp.Length;

            // Every event is for each Parserobject
            ManualResetEvent[] doneEvents = new ManualResetEvent[Expressions];
            Parser[] parsArray = new Parser[Expressions];

            // Starting the Threads with a Threadpool
            Console.WriteLine("launching {0} tasks...", Expressions);
            for (int i = 0; i < Expressions; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);
                Parser pars = new Parser(exp[i], doneEvents[i]);
                parsArray[i] = pars;
                ThreadPool.QueueUserWorkItem(pars.ThreadPoolCallback, i);

            }

            // Wait until all ParserEvents are done
            WaitHandle.WaitAll(doneEvents);
            Console.WriteLine("All Expressions are parsed");

            // Output of the results
            for (int i = 0; i < Expressions; i++)
            {
                Parser p = parsArray[i];
                Console.WriteLine("Expression({0}) = {1}", p.getText, p.getResult);
            }
            Console.ReadKey();

        }


    }
}
