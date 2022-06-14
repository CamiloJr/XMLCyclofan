using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLCyclofan.Models
{
    public class Project
    {
        private List<Part> parts;
        private List<Tool> tools;
        private Hierarchy hierarchy;

        internal List<Part> Parts { get => parts; set => parts = value; }
        internal Hierarchy Hierarchy { get => hierarchy; set => hierarchy = value; }
        internal List<Tool> Tools { get => tools; set => tools = value; }

        public Part SelectPartById(int id)
        {
            return parts.Find(iten => iten.Id.Equals(id));
        }

        public bool PermitidoRetirada(int id)
        {
            // Varedura

            return false;
        }
        
    }
}
