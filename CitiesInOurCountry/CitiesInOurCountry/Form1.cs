using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CitiesInOurCountry.Model;
using CitiesInOurCountry.Service;
using CitiesInOurCountry.UI;

namespace CitiesInOurCountry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void btnAddState_Click(object sender, EventArgs e)
        {
            frmState frm = new frmState();
            frm.ShowDialog();

            GenerateDynamicStateTreeView(StateService.lstState, CityService.lstCity);
        }

        private void btnAddCity_Click(object sender, EventArgs e)
        {
            frmCitiy frm = new frmCitiy();
            frm.ShowDialog();

            GenerateDynamicStateTreeView(StateService.lstState, CityService.lstCity);
        }

        private void Form1_Load(object sender, EventArgs e)
        {            

        }

        private void GenerateDynamicStateTreeView(List<State> lstState, List<City> lstCity)
        {
            tvDynamic.Nodes.Clear();

            foreach (State state in lstState)
            {
                TreeNode stateNode = new TreeNode(state.Name);
                stateNode.Text = state.Name;

                foreach (City city in lstCity)
                {                    
                    if(city.StateId == state.StateId)
                    {
                        TreeNode cityNode = new TreeNode(city.Name);
                        cityNode.Text = city.Name;

                        stateNode.Nodes.Add(cityNode);
                    }
                }

                tvDynamic.Nodes.Add(stateNode);
            }
            
        }
    }
}
