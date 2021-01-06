using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CitiesInOurCountry.Model;

namespace CitiesInOurCountry.Service
{
    public static class CityService
    {
        public static List<City> lstCity = new List<City>();

        public static void FillStateComboBox(ComboBox cbo, List<State> lstState)
        {
            if(lstState.Count > 0)
            {
                Dictionary<byte, string> cboSource = new Dictionary<byte, string>();
                foreach (State item in lstState)
                {
                    cboSource.Add(item.StateId, item.Name);
                }

                cbo.DataSource = new BindingSource(cboSource, null);
                cbo.DisplayMember = "Value";
                cbo.ValueMember = "Key";
            }
        }

        public static string AddCity(City objCity)
        {
            lstCity.Add(objCity);

            return "Added Sussessfully!";
        }

        public static void ReadData(DataGridView dgv)
        {
            dgv.Rows.Clear();

            foreach (City item in lstCity)
            {
                string[] row = new string[]
                {
                    item.CityId.ToString(),
                    item.Name,
                    GetStateName((byte)item.StateId)
                    //item.StateId.ToString()
                };

                dgv.Rows.Add(row);
            }
        }

        public static int GetCityId()
        {
            if (lstCity.Count > 0)
            {
                City objCity = lstCity.LastOrDefault();
                return Convert.ToInt32(objCity.CityId + 1);
            }
            else
            {
                return 1;
            }
        }

        private static string GetStateName(byte stateId)
        {
            if(StateService.lstState.Count > 0)
            {
                foreach (State item in StateService.lstState)
                {
                    if (item.StateId == stateId)
                    {
                        return item.Name;
                    }
                }

                //return StateService.lstState.Where(item => item.StateId == stateId).FirstOrDefault().Name;
            }
            return "";
        }
    }
}
