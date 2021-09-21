using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_DevTest.General.Model
{
    public class ListVillageViewModel
    {
        public decimal average { get; set; }

        public IList<VillagerModel> VillageList { get; set; }
    }
}
