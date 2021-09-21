using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_DevTest.General.Model
{
    public class VillagerModel
    {
        public int Id { get; set; }

        public string VilagerName { get; set; }

        public int? AgeOfDeath { get; set; }

        public int? YearOfDeath { get; set; }

        public int? CountOfDeath { get; set; }

        public decimal? average { get; set; }
    }
}
