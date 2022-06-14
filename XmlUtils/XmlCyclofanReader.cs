using System;
using System.Xml;
using XMLCyclofan.Models;

namespace XMLCyclofan.XmlUtils
{
    public abstract class XmlCyclofanReader
    {
        public static Project XmlParserTest(XmlDocument doc)
        {
            var project = new Project();
            try
            {
                var rootNode = doc.DocumentElement;

                //Adicionando peças
                foreach (XmlNode objNode in rootNode.GetElementsByTagName("part"))
                {
                    var part = new Part();
                    part.Id = int.Parse(objNode.Attributes["id"].Value);
                    part.Type = objNode.Attributes["type"].Value;
                    part.Torque = double.Parse(objNode.Attributes["torque"].Value);

                    if (objNode.Attributes["flag"].Value.Equals("true"))
                        part.Flag = true;

                    part.FactoryInfo = objNode.SelectSingleNode("factory-info").Attributes[0].Value;
                    // completar...


                    project.Parts.Add(part);
                }

                //Adicionando ferramentas
                foreach (XmlNode objNode in rootNode.GetElementsByTagName("tool"))
                {
                    var tool = new Tool();
                    tool.Id = int.Parse(objNode.Attributes["id"].Value);
                    tool.Type = objNode.Attributes["type"].Value;
                    // completar...

                    project.Tools.Add(tool);
                }

                // Adicionando hierarquia
                foreach (XmlNode objNode in rootNode.GetElementsByTagName("hie...."))
                {
                    // completar...
                }

                return project;
            }
            catch (XmlException ex)
            {
                Console.WriteLine("Erro ao ler arquivo! " + ex.Message);
            }

            return project;
        }
    }
}
