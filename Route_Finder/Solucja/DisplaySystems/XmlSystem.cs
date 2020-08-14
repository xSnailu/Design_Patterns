using BigTask2.Api;
using BigTask2.Ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BigTask2.DisplaySystems
{
    class XMLSystem : ISystem
    {
        IForm form = new XmlFormSystem();
        IDisplay display = new XmlDisplaySystem();
        public IForm Form => form;

        public IDisplay Display => display;
    }

    class XmlDisplaySystem : IDisplay
    {
        public void Print(IEnumerable<Route> routes)
        {
            if (routes == null || routes.Count() == 0)
                return;

            double totalTime = 0;
            double totalCost = 0;
            foreach(Route route in routes)
            {
                City city = route.From;
                Console.WriteLine("<City/>");
                Console.WriteLine("<{0}>{1}<{2}>", "Name", city.Name, "Name");
                Console.WriteLine("<{0}>{1}<{2}>", "Population", city.Population, "Population");
                Console.WriteLine("<{0}>{1}<{2}>", "HasRestaurant", city.HasRestaurant, "HasRestaurant");
                Console.WriteLine();
                Console.WriteLine("<Route/>");
                Console.WriteLine("<{0}>{1}<{2}>", "Vehicle", route.VehicleType, "Vehicle");
                Console.WriteLine("<{0}>{1}<{2}>", "Cost", route.Cost, "Cost");
                Console.WriteLine("<{0}>{1}<{2}>", "TravelTime", route.TravelTime, "TravelTime");
                Console.WriteLine();
                totalCost = totalCost + route.Cost;
                totalTime = totalTime + route.TravelTime;

            }


            City lastCity = routes.Last().To;
            Console.WriteLine("<City/>");
            Console.WriteLine("<{0}>{1}<{2}>", "Name", lastCity.Name, "Name");
            Console.WriteLine("<{0}>{1}<{2}>", "Population", lastCity.Population, "Population");
            Console.WriteLine("<{0}>{1}<{2}>", "HasRestaurant", lastCity.HasRestaurant, "HasRestaurant");
            Console.WriteLine();
            Console.WriteLine("<{0}>{1}<{2}>", "TotalTime", Math.Round(totalTime, 2), "TotalTime");
            Console.WriteLine("<{0}>{1}<{2}>", "TotalCost", Math.Round(totalCost, 2), "TotalCost");

        }
    }

    class XmlFormSystem : IForm
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
            string[] firstsplit = command.Split("<");
            string[] secsplit = firstsplit[1].Split(">");

            //dodać sprawdzanie
            if (dict.ContainsKey(secsplit[0]))
                dict.Remove(secsplit[0]);

            dict.Add(secsplit[0], secsplit[1]);

        }
    }

}
