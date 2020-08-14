using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;                         // add reference System.Xml
using System.Runtime.Serialization;                     // add reference System.Runtime.Serialization
using System.Xml.Schema;
using System.Xml;

namespace ConsoleApp
{
    public static class LibraryReader
    {
        public static Library.pastures ReadLibrary(string path)
        {
            //deserializacja 
            XmlSerializer xs = new XmlSerializer(typeof(Library.pastures));
            Library.pastures output;
            FileStream fs;
            fs = new FileStream(path, FileMode.Open);

            output = (Library.pastures)xs.Deserialize(fs);
            fs.Close();
            return output;
        }


    }
}
