using BigTask2.Api;
using BigTask2.Ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigTask2.DisplaySystems
{
    class KeyValueSystem : ISystem
    {
        IForm form = new KeyValueFormSystem();
        IDisplay display = new KeyValueDisplaySystem();
        public IForm Form => form;

        public IDisplay Display => display;
    }
    class KeyValueDisplaySystem : IDisplay
    {
        public void Print(IEnumerable<Route> routes)
        {
            double totalTime = 0;
            double totalCost = 0;

            if (routes == null || routes.Count() == 0)
                return;

            foreach (Route route in routes)
            {
                City startCity = route.From;
                Console.WriteLine("=City=");
                Console.WriteLine("Name={0}", startCity.Name);
                Console.WriteLine("Population={0}", startCity.Population);
                Console.WriteLine("HasRestaurant={0}", startCity.HasRestaurant);
                Console.WriteLine();
                Console.WriteLine("=Route=");
                Console.WriteLine("{0}={1}", "Vehicle", route.VehicleType);
                Console.WriteLine("{0}={1}", "Cost", route.Cost);
                Console.WriteLine("{0}={1}", "TravelTime", route.TravelTime);
                Console.WriteLine();

                totalCost = totalCost + route.Cost;
                totalTime = totalTime + route.TravelTime;
            }

            City lastCity = routes.Last().To;
            Console.WriteLine("=City=");
            Console.WriteLine("Name={0}", lastCity.Name);
            Console.WriteLine("Population={0}", lastCity.Population);
            Console.WriteLine("HasRestaurant={0}", lastCity.HasRestaurant);
            Console.WriteLine();

            Console.WriteLine("{0}={1}", "TotalTime", Math.Round(totalTime, 2));
            Console.WriteLine("{0}={1}", "TotalCost", Math.Round(totalCost, 2));
        }
    }

    class KeyValueFormSystem : IForm
    {
        private readonly Dictionary<string, string> dict = new Dictionary<string, string>();

        public bool GetBoolValue(string name)
        {
            return bool.Parse(dict[name]);
        }

        public int GetNumericValue(string name)
        {
            return Int32.Parse(dict[name]);
        }

        public string GetTextValue(string name)
        {
            return dict[name];
        }

        public void Insert(string command)
        {
            string[] firstsplit = command.Split("=");
            
            //dodać sprawdzanie
            if (dict.ContainsKey(firstsplit[0]))
                dict.Remove(firstsplit[0]);

            dict.Add(firstsplit[0], firstsplit[1]);

        }
    }
}
