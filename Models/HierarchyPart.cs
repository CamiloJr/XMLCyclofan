using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLCyclofan.Models
{
    public class HierarchyPart
    {
        private int id;
        private List<HierarchyPart> hierarchyParts = new List<HierarchyPart>();

        public int Id { get => id; set => id = value; }
        public List<HierarchyPart> HierarchyParts { get => hierarchyParts; set => hierarchyParts = value; }

        public HierarchyPart()
        {
        }

        public HierarchyPart(int id, List<HierarchyPart> hierarchyParts)
        {
            this.id = id;
            this.hierarchyParts = hierarchyParts;
        }

        
    }
}
