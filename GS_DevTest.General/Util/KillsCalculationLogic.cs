using GS_DevTest.General.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_DevTest.General.Util
{
    public class KillsCalculationLogic
    {

        public static int CountOfDeath(int age, int year)
        {
            int countf = 0;
            int yearf = 0;
            int bornyear = year - age;

            List<RulesModel> ListRules = new List<RulesModel>();

            if (bornyear < 0)
            {
                countf = -1;
            }
            else
            {

                for (int i = 0; i < bornyear; i++)
                {
                    RulesModel model = new RulesModel();

                    if (i == 0)
                    {
                        countf += 1;
                    }
                    else
                    {
                        countf += i;
                    }
                    yearf++;
                    model.year = yearf;
                    model.countofdeath = countf;
                    ListRules.Add(model);

                }

                var getdata = ListRules.Where(x => x.year == bornyear).FirstOrDefault();
                countf = getdata != null ? getdata.countofdeath : -1;
            }

            return countf;

        }
    }



}

