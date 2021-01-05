using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CitiesInOurCountry.Model;

namespace CitiesInOurCountry.Service
{
    public static class StateService
    {
        public static List<State> lstState = new List<State>();

        public static void ReadData(DataGridView dgv)
        {
            dgv.Rows.Clear();

            foreach (var item in lstState)
            {
                string[] row = new string[] 
                { 
                    item.StateId.ToString(),
                    item.Name
                };

                dgv.Rows.Add(row);
            }
        }

        public static string AddState(byte stateId, string name)
        {
            State objState = new State();
            objState.StateId = stateId;
            objState.Name = name;
            //State state = new State{ StateId = stateId, Name = name };

            lstState.Add(objState);

            return "Successfully Added.";
        }

        public static string Remove(byte stateId)
        {
            //State objState = lstState.Where(x => x.StateId == stateId).FirstOrDefault();

            foreach (State item in lstState)
            {
                if(item.StateId == stateId)
                {
                    lstState.Remove(item);
                    break;
                }
            }

            return "Successfully Deleted.";
        }

        public static byte GetStateId()
        {
            if(lstState.Count > 0)
            {
                State objState = lstState.LastOrDefault();
                return Convert.ToByte(objState.StateId + 1);
            }
            else
            {
                return 1;
            }
        }

    }
}
