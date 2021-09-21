using GS_DevTest.General.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_DevTest.Service.Interface
{
    public interface IVillagerManager
    {
        IList<VillagerModel> GetAllData();
        VillagerModel GetDataById(int Id);
        VillagerModel Create(VillagerModel model);
        VillagerModel Update(VillagerModel model);
        void Delete(int Id);
        VillagerModel GetAverageKills();

    }
}
