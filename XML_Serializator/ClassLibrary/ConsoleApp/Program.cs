using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            string path;
            if (args.Length==1) path = args[0];
            else path = "XMLFile1.xml";

            




            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += ValidationHandler;



            

            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.Schemas.Add("http://example.org/jk/pastures", "..\\..\\..\\ClassLibrary\\XMLFile1.xsd");


            XmlReader reader = XmlReader.Create(path, settings);

                     
                while (reader.Read())
                {
                //wyswietlanie xml
                
                /*switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        Console.Write("<{0}>", reader.Name);
                        break;
                    case XmlNodeType.Text:
                        Console.Write(reader.Value);
                        break;
                    case XmlNodeType.CDATA:
                        Console.Write("<![CDATA[{0}]]>", reader.Value);
                        break;
                    case XmlNodeType.ProcessingInstruction:
                        Console.Write("<?{0} {1}?>", reader.Name, reader.Value);
                        break;
                    case XmlNodeType.Comment:
                        Console.Write("<!--{0}-->", reader.Value);
                        break;
                    case XmlNodeType.XmlDeclaration:
                        Console.Write("<?xml version='1.0'?>");
                        break;
                    case XmlNodeType.Document:
                        break;
                    case XmlNodeType.DocumentType:
                        Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
                        break;
                    case XmlNodeType.EntityReference:
                        Console.Write(reader.Name);
                        break;
                    case XmlNodeType.EndElement:
                        Console.Write("</{0}>", reader.Name);
                        break;
                    }*/



                }

            reader.Close();
            Console.Write("Plik XML jest poprawny.");
            //Library.pastures pastwisko;
            //pastwisko = LibraryReader.ReadLibrary(path);





            Console.WriteLine("koniec");
        }

        private static void ValidationHandler(Object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
            {
                Console.WriteLine("Warning: {0}", args.Message);
            }
            else
            {
                Console.Write("Plik XML nie jest poprawny. Zamykanie programu.");
                Console.WriteLine("Error: {0}", args.Message);
                System.Environment.Exit(1);
            }
                

        }
    }
}
