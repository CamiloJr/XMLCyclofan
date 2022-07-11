using System;
using System.Collections.Generic;
using System.Xml;
using XMLCyclofan.Models;

namespace XMLCyclofan.XmlUtils
{
    public abstract class XmlCyclofanReader
    {
        public static Workspace ReadCyclofanWorkSpace(XmlDocument doc)
        {
            var device = new Device();
            var workspace = new Workspace();

            try
            {
                var rootNode = doc.DocumentElement;

                //Adicionando ferramentas
                foreach (XmlNode objNode in rootNode.GetElementsByTagName("tool"))
                {
                    var tool = new Tool();
                    tool.Id = objNode.Attributes["id"].Value;
                    tool.Type = objNode.Attributes["type"].Value;
                    double size = 0d;
                    var reply = double.TryParse(objNode.Attributes["size"].Value, out size);
                    if (reply)
                        tool.Size = size;
                    else
                        tool.Size = 0d;


                    tool.Description = objNode.Attributes["description"].Value;
                    workspace.Tools.Add(tool);
                }

                Console.WriteLine("\nQuantidade de ferramentas: " + workspace.Tools.Count);
                foreach (var tool in workspace.Tools)
                {
                    Console.WriteLine($" - ID: {tool.Id}  Tipo: {tool.Type}  Tamanho: {tool.Size}");
                }

                //Lendo e adicionando peças na classe
                foreach (XmlNode objNode in rootNode.GetElementsByTagName("part"))
                {
                    var part = new Part();
                    part.Id = objNode.Attributes["id"].Value;
                    part.Type = objNode.Attributes["type"].Value;
                    var torque = objNode.Attributes["torque"].Value;
                    if (torque.Length > 0)
                        part.Torque = double.Parse(torque);
                    else
                        part.Torque = 0d;

                    if (objNode.Attributes["flag"].Value.Equals("true"))
                        part.Flag = true;
                    else
                        part.Flag = false;

                    part.FactoryInfo = objNode.SelectSingleNode("factory-info").InnerText.Replace("\n", "").Replace("   ", "");
                    part.Description = objNode.SelectSingleNode("description").InnerText.Replace("\n", "").Replace("   ", "");

                    var nodesTool = objNode.SelectNodes("part-tools/part-tool");
                    foreach (XmlNode tool in nodesTool)
                    {
                        var toolId = tool.Attributes["id"].Value;

                        var newTool = workspace.Tools.Find(item => item.Id.Equals(toolId));
                        if(newTool != null)
                            part.Tools.Add(newTool);
                    }
                    device.Parts.Add(part);
                }

                workspace.Device = device;

                Console.WriteLine("\nQuantidade de peças: " + device.Parts.Count);
                foreach (var part in device.Parts)
                {
                    Console.WriteLine($" - ID: {part.Id}  Tipo: {part.Type}  Torque: {part.Torque}");
                    Console.WriteLine("     Tools:");
                    foreach (var tool in part.Tools)
                    {
                        Console.WriteLine($"         - {tool.Type}  Tamanho: {tool.Size}");
                    }
                }

                // Adicionando hierarquia
                //Adicionando ferramentas
                foreach (XmlNode objNode in rootNode.GetElementsByTagName("hrule"))
                {
                    var hrule = new HierarchyRule();
                    hrule.PartId = objNode.Attributes["part-id"].Value;
                    hrule.Depend = objNode.Attributes["depend"].Value;

                    workspace.Device.HierarchyRules.Add(hrule);
                }

                Console.WriteLine("\nQuantidade de regras de hierarquia: " + workspace.Device.HierarchyRules.Count);
                foreach (var hrule in workspace.Device.HierarchyRules)
                {
                    Console.WriteLine($" - Peça: {workspace.Device.Parts.Find(item => item.Id.Equals(hrule.PartId)).Type}  Depende de: {workspace.Device.Parts.Find(item => item.Id.Equals(hrule.Depend)).Type}");
                }
            }
            catch (XmlException ex)
            {
                Console.WriteLine("Erro ao ler arquivo! " + ex.Message);
            }

            return workspace;
        }
    }
}
