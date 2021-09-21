using GS_DevTest.General.Model;
using GS_DevTest.Service.Interface;
using GS_DevTest.Vilagers.Model.Dao;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_DevTest.Service.Manager
{
    public class VillagerManager : IVillagerManager
    {
        private readonly VillageDao VillageDao;

        public VillagerManager(IConfiguration _config)
        {
            this.VillageDao = new VillageDao(_config);
        }

        public VillagerModel Create(VillagerModel model)
        {
            var data = new VillagerModel();

            try
            {
                data = VillageDao.Create(model);


            }
            catch (Exception ex)
            {
                // _logger.WriteFunctionLog(DestinationLogFolder(), "", "CreateTalent", ex.Message, "Service");

            }

            return data;
        }

        public void Delete(int Id)
        {
            try
            {
                VillageDao.Delete(Id);



            }
            catch (Exception ex)
            {
                //_logger.WriteFunctionLog(DestinationLogFolder(), "", "DeleteTalentCategoryById", ex.Message, "Service");

            }
        }

        public IList<VillagerModel> GetAllData()
        {
            IList<VillagerModel> data = new List<VillagerModel>();

            try
            {
                data = VillageDao.GetAllData();
            }
            catch (Exception ex)
            {
                //_logger.WriteFunctionLog(DestinationLogFolder(), "", "GetAllBank", ex.Message, "Service");

            }

            return data;
        }

        public VillagerModel GetAverageKills()
        {
            var data = new VillagerModel();

            try
            {
                data = VillageDao.GetAverageKills();


            }
            catch (Exception ex)
            {
                // _logger.WriteFunctionLog(DestinationLogFolder(), "", "CreateTalent", ex.Message, "Service");

            }

            return data;
        }

        public VillagerModel GetDataById(int Id)
        {
            var data = new VillagerModel();

            try
            {
                data = VillageDao.GetDataById(Id);


            }
            catch (Exception ex)
            {
               // _logger.WriteFunctionLog(DestinationLogFolder(), "", "CreateTalent", ex.Message, "Service");

            }

            return data;
        }

        public VillagerModel Update(VillagerModel model)
        {
            var data = new VillagerModel();

            try
            {
                data = VillageDao.Update(model);


            }
            catch (Exception ex)
            {
                // _logger.WriteFunctionLog(DestinationLogFolder(), "", "CreateTalent", ex.Message, "Service");

            }

            return data;
        }
    }
}
