using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLCyclofan.Models
{
    public class Device
    {
        private List<Part> parts = new List<Part>();
        private List<HierarchyRule> hierarchyRules = new List<HierarchyRule>();

        public List<Part> Parts { get => parts; set => parts = value; }
        public List<HierarchyRule> HierarchyRules { get => hierarchyRules; set => hierarchyRules = value; }

        public Part GetPartById(string partId)
        {
            var part = parts.Find(part => part.Id.Equals(partId));
            return part;
        }

        public (bool reply, List<Part> parts) PartAllowedToBeRemoved(Part part)
        {
            var id = part.Id;

            var rulesRoot = hierarchyRules.FindAll(p => p.PartId.Equals(id));
            var impedimentsDetected = rulesRoot.Where(x => GetPartById(x.Depend).Assembled() == true).ToList();

            var partDepends = new List<Part>();
            foreach(var imp in impedimentsDetected)
            {
                partDepends.Add(GetPartById(imp.PartId));
            }

            if (partDepends.Count > 0)
                return (false, partDepends);
            else
                return (true, partDepends);
        }
    }
}
