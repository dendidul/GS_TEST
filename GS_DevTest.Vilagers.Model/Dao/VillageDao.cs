using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using GS_DevTest.General.Model;
using GS_DevTest.General.Util;

namespace GS_DevTest.Vilagers.Model.Dao
{
    public class VillageDao
    {

        private readonly IConfiguration _config;
        


        public VillageDao(IConfiguration config)
        {

            this._config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DbConnection"));
            }
        }

        public IList<VillagerModel> GetAllData()
        {
            var data = new List<VillagerModel>();

            try
            {
                using (IDbConnection conn = Connection)
                {
                    var param = new DynamicParameters();



                    data = conn.Query<VillagerModel>(
                                               @"SELECT [Id]
                                                  ,[VilagerName]
                                                  ,[AgeOfDeath]
                                                  ,[YearOfDeath]
                                                  ,[CountOfDeath]
                                              FROM [Villagers]").ToList();



                }

            }
            catch (Exception ex)
            {

                throw ex;

            }
            return data;

        }


        public VillagerModel GetAverageKills()
        {
            var data = new VillagerModel();

            try
            {
                using (IDbConnection conn = Connection)
                {
                    var param = new DynamicParameters();



                    data = conn.Query<VillagerModel>(
                                               @"select cast(cast(sum(CountOfDeath) as decimal)/cast(count(Id) as decimal(18,2)) as decimal(18,2)) as average from Villagers"

                                               ).FirstOrDefault();



                }

            }
            catch (Exception ex)
            {

                throw ex;

            }
            return data;

        }

        public VillagerModel GetDataById(int Id)
        {
            var data = new VillagerModel();

            try
            {
                using (IDbConnection conn = Connection)
                {
                    var param = new DynamicParameters();



                    data = conn.Query<VillagerModel>(
                                               @"SELECT [Id]
                                                  ,[VilagerName]
                                                  ,[AgeOfDeath]
                                                  ,[YearOfDeath]
                                                  ,[CountOfDeath]
                                              FROM [Villagers] where Id = @Id", new
                                               {
                                                   @Id = Id
                                               }
                                               ).FirstOrDefault();



                }

            }
            catch (Exception ex)
            {

                throw ex;

            }
            return data;

        }


        public VillagerModel Create(VillagerModel model)
        {
            var data = new VillagerModel();

            try
            {
                using (IDbConnection conn = Connection)
                {

                   model.CountOfDeath = KillsCalculationLogic.CountOfDeath(model.AgeOfDeath.Value, model.YearOfDeath.Value);

                   data = conn.Query<VillagerModel>(
                                        @"INSERT INTO [dbo].[Villagers]
                                           ([VilagerName]
                                           ,[AgeOfDeath]
                                           ,[YearOfDeath]
                                           ,[CountOfDeath])
                                     VALUES
                                           (@VilagerName
                                           ,@AgeOfDeath
                                           ,@YearOfDeath
                                           ,@CountOfDeath)
                                                    ", new
                                        {
                                            VilagerName = model.VilagerName,
                                            AgeOfDeath = model.AgeOfDeath,
                                            YearOfDeath = model.YearOfDeath,
                                            CountOfDeath = model.CountOfDeath,
                                        }).FirstOrDefault();



                }

            }
            catch (Exception ex)
            {

                throw ex;

            }
            return data;

        }

        public VillagerModel Update(VillagerModel model)
        {
            var data = new VillagerModel();

            try
            {
                using (IDbConnection conn = Connection)
                {


                    data.CountOfDeath = KillsCalculationLogic.CountOfDeath(model.AgeOfDeath.Value, model.YearOfDeath.Value);

                    data = conn.Query<VillagerModel>(
                                                @"UPDATE [dbo].[Villagers]
                                                   SET [VilagerName] = @VilagerName
                                                      ,[AgeOfDeath] = @AgeOfDeath
                                                      ,[YearOfDeath] = @YearOfDeath
                                                      ,[CountOfDeath] = @CountOfDeath
                                                 WHERE ID = @id
                                                    ", new
                                                {
                                                    id = model.Id,
                                                    VilagerName = model.VilagerName,
                                                    AgeOfDeath = model.AgeOfDeath,
                                                    YearOfDeath = model.YearOfDeath,
                                                    CountOfDeath = model.CountOfDeath

                                                }).FirstOrDefault();



                }

            }
            catch (Exception ex)
            {

                throw ex;

            }
            return data;

        }

        public void Delete(int Id)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Execute("delete from Villagers where Id = @id",
                                new
                                {
                                    @id = Id
                                });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
