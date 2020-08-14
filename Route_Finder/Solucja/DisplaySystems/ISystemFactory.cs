using BigTask2.Ui;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigTask2.DisplaySystems
{
    interface ISystemFactory
    {
        IDisplay CreateDisplay();
        IForm CreateForm();
    }

    class XMLSystemFactory : ISystemFactory
    {
        public IDisplay CreateDisplay()
        {
            return new XmlDisplaySystem();
        }

        public IForm CreateForm()
        {
            return new XmlFormSystem();
        }
    }

    class KeyValueFactory : ISystemFactory
    {
        public IDisplay CreateDisplay()
        {
            return new KeyValueDisplaySystem();
        }

        public IForm CreateForm()
        {
            return new KeyValueFormSystem();
        }
    }
}
