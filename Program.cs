using System;
using System.Collections.Generic;
using System.Xml;
using XMLCyclofan.Models;
using XMLCyclofan.XmlUtils;

namespace XMLCyclofan
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "../../../XmlFile/example_1.xml";
            var xmlReader = XmlReader.Create(path);
            var doc = new XmlDocument();
            doc.Load(xmlReader);

            var workspace = XmlCyclofanReader.ReadCyclofanWorkSpace(doc);

            
            // Removendo o parafuso
            var parafuso = workspace.Device.GetPartById("1ac3d");
            var chavePhilips = workspace.GetToolById("30cvw");
            var resultadoParafusoPhilips = workspace.RemovePart(parafuso, chavePhilips);

            Console.WriteLine();
            Console.WriteLine($"Operação: {resultadoParafusoPhilips.reply}   Mensagem: {resultadoParafusoPhilips.message}");


            // Removendo a arruela
            var arruela = workspace.Device.GetPartById("dfb43");
            var mao = workspace.GetToolById("afwe2");
            var resultadoArruelaMao = workspace.RemovePart(arruela, mao);

            Console.WriteLine();
            Console.WriteLine($"Operação: {resultadoArruelaMao.reply}   Mensagem: {resultadoArruelaMao.message}");


            // Removendo a eixo
            var eixo = workspace.Device.GetPartById("1ecs4");
            var mao_b = workspace.GetToolById("afwe2");
            var resultadoEixoMao = workspace.RemovePart(eixo, mao_b);

            Console.WriteLine();
            Console.WriteLine($"Operação: {resultadoEixoMao.reply}   Mensagem: {resultadoEixoMao.message}");
        }
    }
}
