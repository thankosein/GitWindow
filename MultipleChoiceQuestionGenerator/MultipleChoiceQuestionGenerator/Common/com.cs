using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultipleChoiceQuestionGenerator.Common
{
    static class Com
    {
        public static OleDbConnection conn;
        private const string DBNAME = "MultipleChoiceQuestionGenerator";

        public static void MODopenDB()
        {
            conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBNAME + ".mdb;Jet OLEDB:Database Password=admin;Persist Security Info=True");
            conn.Open();
        }

        public static OleDbDataReader modGetDataReader(string strSQl)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand(strSQl, conn);
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Report to Software Company! " + ex.Message);
            }
            return null;
        }

        public static OleDbDataAdapter modGetDataAdapter(string strSQl)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand(strSQl, conn);
                return new OleDbDataAdapter(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Report to Software Company! " + ex.Message);
            }
            return null;
        }

        public static string modGetMatchData(string strSQL)
        {
            try
            {
                object strReturn = new OleDbCommand(strSQL, conn).ExecuteScalar();
                return (strReturn == DBNull.Value) ? "" : Convert.ToString(strReturn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(("Report to Software Company! " + ex.Message));
            }
            return null;
        }

        public static object modSetData(string strSQL)
        {
            try
            {
                int c = new OleDbCommand(strSQL, conn).ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return strSQL.Substring(0, 6) == "INSERT" ? "New Record Added!" : "Record Updated!";
        }

        public static void autofill(string strSql, TextBox txt)
        {
            AutoCompleteStringCollection authors = new AutoCompleteStringCollection();
            OleDbDataReader rstauto = Com.modGetDataReader(strSql);
            if (rstauto.HasRows)
            {
                rstauto.Read();
                do
                {
                    authors.Add(Convert.ToString(rstauto[0]));
                } while (rstauto.Read());
                rstauto.Close();
            }
            txt.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt.AutoCompleteCustomSource = authors;
        }

        public static void comboFill(string strSql, ComboBox cbo)
        {
            cbo.Items.Clear();
            OleDbDataReader rstCombo = Com.modGetDataReader(strSql);
            if (rstCombo.HasRows)
            {
                while (rstCombo.Read())
                {
                    cbo.Items.Add(rstCombo[0]);
                }
            }
        }

        public static void comboFillWithKey(string strSql, ComboBox cbo)
        {
            cbo.Items.Clear();
            OleDbDataReader rstCombo = Com.modGetDataReader(strSql);
            if (rstCombo.HasRows)
            {
                cbo.ValueMember = "Value";
                cbo.DisplayMember = "Text";

                while (rstCombo.Read())
                {
                    cbo.Items.Add(new { Text = rstCombo[1], Value = rstCombo[0] });
                }

                cbo.DataSource = cbo.Items;

                cbo.SelectedIndex = 0;
            }
        }
    }
}
