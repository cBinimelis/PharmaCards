using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCards.Library
{
    public class MedicamentsModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Action { get; set; }
        public string MOA { get; set; }
        public string Administration { get; set; }
        public string ClinicalUse { get; set; }
        public string AdverseEffects { get; set; }
    }
}
