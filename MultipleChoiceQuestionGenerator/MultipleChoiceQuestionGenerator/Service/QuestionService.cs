using MultipleChoiceQuestionGenerator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultipleChoiceQuestionGenerator.Service
{
    public static class QuestionService
    {
        public static List<Question> lstQuestion = new List<Question>();
        

        public static string AddQuesiton(Question quest)
        {
            lstQuestion.Add(quest);

            return "Add successfully";
        }

        public static void ReadData(DataGridView dgv)
        {
            DataTable qutestDataTable = ToDataTable(lstQuestion);
            //dgv.DataSource = qutestDataTable;
        }

        public static string GetQuestionId()
        {
            Question ques = lstQuestion.LastOrDefault();
            if(ques == null)
            {
                return "1";
            }
            else
            {
                return (ques.QuestId + 1).ToString();
            }
        }

        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                var name = prop.Name;
                var dataType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
                
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;                    
                }

                table.Rows.Add(row);

            }
            return table;
        }
    }
}
