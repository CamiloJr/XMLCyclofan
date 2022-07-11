using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLCyclofan.Models
{
    public class Part
    {
        private string id = String.Empty;
        private string type = String.Empty;
        private double torque;
        private bool flag = false;
        private string factoryInfo = String.Empty;
        private string description = String.Empty;
        private List<Tool> tools = new List<Tool>();

        public string Id { get => id; set => id = value; }
        public string Type { get => type; set => type = value; }
        public double Torque { get => torque; set => torque = value; }
        public bool Flag { get => flag; set => flag = value; }
        public string FactoryInfo { get => factoryInfo; set => factoryInfo = value; }
        public List<Tool> Tools { get => tools; set => tools = value; }
        public string Description { get => description; set => description = value; }
        

        public Part()
        { }

        public Part(string id, string type, double torque, bool flag, string factoryInfo, string description, List<Tool> tools)
        {
            this.id = id;
            this.type = type;
            this.torque = torque;
            this.flag = flag;
            this.factoryInfo = factoryInfo;
            this.description = description;
            this.tools = tools;
        }

        public bool Assembled()
        {
            return this.flag;
        }

        public void Assembled(bool assembled = true)
        {
            this.flag = assembled;
        }

        public bool CorrectTool(Tool tool)
        {
            return this.tools.Contains(tool);
        }

        public bool CorrectTorque(double torque)
        {
            return this.torque == torque;
        }
    }
}
