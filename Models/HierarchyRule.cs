using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLCyclofan.Models
{
    public class HierarchyRule
    {
        private string partId = string.Empty;
        private string depend = string.Empty;

        public string PartId { get => partId; set => partId = value; }
        public string Depend { get => depend; set => depend = value; }
    }
}
