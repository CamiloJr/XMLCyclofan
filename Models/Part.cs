using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLCyclofan.Models
{
    public class Part
    {
        private int id;
        private string type = String.Empty;
        private double torque;
        private bool flag;
        private string factoryInfo = String.Empty;
        List<Tool> tools = new List<Tool>();

        public int Id { get => id; set => id = value; }
        public string Type { get => type; set => type = value; }
        public double Torque { get => torque; set => torque = value; }
        public bool Flag { get => flag; set => flag = value; }
        public string FactoryInfo { get => factoryInfo; set => factoryInfo = value; }
        public List<Tool> Tools { get => tools; set => tools = value; }

        public Part()
        {
        }

        public Part(int id, string type, double torque, bool flag, string factoryInfo, List<Tool> tools)
        {
            this.id = id;
            this.type = type;
            this.torque = torque;
            this.flag = flag;
            this.factoryInfo = factoryInfo;
            this.tools = tools;
        }

       
    }
}
