using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

///Created on 24.06.2016
///@author: Group 6
namespace EBNF_Parser
{
    class Program
    {
        // Main method and Inizialisation of the Threadpool
        static void Main(string[] args)
        {


           

            var reader = new Reader(@"../expressions.txt");

            ThreadPool.SetMaxThreads(3, 3);
            ThreadPool.SetMinThreads(3, 3);

            System.Threading.ThreadPool.QueueUserWorkItem(reader.parseDocument);

            Console.ReadKey();

        }
    }
}