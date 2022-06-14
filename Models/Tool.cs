using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLCyclofan.Models
{
    public class Tool
    {
        private int id;
        private string type = String.Empty;
        private double size;
        private string description = String.Empty;

        public int Id { get => id; set => id = value; }
        public string Type { get => type; set => type = value; }
        public double Size { get => size; set => size = value; }
        public string Description { get => description; set => description = value; }

        public Tool()
        {
        }

        public Tool(int id, string type, double size, string description)
        {
            this.id = id;
            this.type = type;
            this.size = size;
            this.description = description;
        }
    }   
}
