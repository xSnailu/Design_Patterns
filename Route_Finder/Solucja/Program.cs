using BigTask2.AlgorithmExecuteChain;
using BigTask2.Algorithms;
using BigTask2.Api;
using BigTask2.Data;
using BigTask2.DisplaySystems;
using BigTask2.RequestAnalyseChain;
using BigTask2.Ui;
using System;
using System.Collections.Generic;
using System.IO;

namespace BigTask2
{
	class Program
	{
        static IEnumerable<Route> ServeRequest(Request request)
        {
            (IGraphDatabase cars, IGraphDatabase trains) = MockData.InitDatabases();
            /*
			 *
			 * Add request handling here and return calculated route
			 *
			 */
            IEnumerable<Route> output = RequestExecuteChainClass.ExecuteRequest(request, cars, trains, null);

            return output;

        }
		static void Main(string[] args)
		{
            Console.WriteLine("---- Xml Interface ----");
            /*
			 * Create XML System Here
             * and execute prepared strings
			 */
            ISystemFactory XMLFactory = new XMLSystemFactory();
            ISystem xmlSystem = CreateSystem(XMLFactory);
            Execute(xmlSystem, "xml_input.txt");
            Console.WriteLine();

            Console.WriteLine("---- KeyValue Interface ----");
            /*
			 * Create INI System Here
             * and execute prepared strings
			 */
            ISystemFactory KeyValueFactory = new KeyValueFactory();
            ISystem keyValueSystem = CreateSystem(KeyValueFactory);
            Execute(keyValueSystem, "key_value_input.txt");
            Console.WriteLine();
        }

        /* Prepare method Create System here (add return, arguments and body)*/
        static ISystem CreateSystem(ISystemFactory systemFactory) 
        {
            return new SpecyficSystem(systemFactory.CreateForm(),systemFactory.CreateDisplay());	
        }

        static void Execute(ISystem system, string path)
        {
            IEnumerable<IEnumerable<string>> allInputs = ReadInputs(path);
            foreach (var inputs in allInputs)
            {
                foreach (string input in inputs)
                {
                    system.Form.Insert(input);
                }
                var request = RequestMapper.Map(system.Form);
                var result = ServeRequest(request);
                system.Display.Print(result);
                Console.WriteLine("==============================================================");
            }
        }

        private static IEnumerable<IEnumerable<string>> ReadInputs(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                List<List<string>> allInputs = new List<List<string>>();
                while (!file.EndOfStream)
                {
                    string line = file.ReadLine();
                    List<string> inputs = new List<string>();
                    while (!string.IsNullOrEmpty(line))
                    {
                        inputs.Add(line);
                        line = file.ReadLine();
                    }
                    if (inputs.Count > 0)
                    {
                        allInputs.Add(inputs);
                    }
                }
                return allInputs;
            }
        }
    }
}
