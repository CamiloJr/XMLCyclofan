using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLCyclofan.Models
{
    public class Hierarchy
    {
        private List<HierarchyPart> hierarchyParts = new List<HierarchyPart>();
        public List<HierarchyPart> HierarchyParts { get => hierarchyParts; set => hierarchyParts = value; }

        public Hierarchy()
        {

        }
    }
}
