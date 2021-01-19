using MultipleChoiceQuestionGenerator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultipleChoiceQuestionGenerator.Service
{
    //ctrl + f
    public static class GradeService
    {
        public static List<Grade> lstGrade = new List<Grade>();

        public static string GetGradeId()
        {
            Grade sub = lstGrade.LastOrDefault();
            if (sub == null)
            {
                return "1";
            }
            else
            {
                return (sub.GradeId + 1).ToString();
            }
        }

        public static string AddGrade(Grade quest)
        {
            lstGrade.Add(quest);

            return "Add successfully";
        }

        public static void ReadData(DataGridView dgv)
        {
            dgv.Rows.Clear();
            foreach (var item in lstGrade)
            {
                string[] row = new string[]
                {
                    item.GradeId.ToString(),
                    item.Name
                };
                dgv.Rows.Add(row);
            }
        }

        public static string DeleteGrade(int GradeId)
        {
            foreach (var item in lstGrade)
            {
                if (item.GradeId == GradeId)
                {
                    lstGrade.Remove(item);
                    break;
                }
            }
            return "Deleted successfully.";
        }

        public static string EditGrade(Grade Grade)
        {
            foreach (var item in lstGrade)
            {
                if (item.GradeId == Grade.GradeId)
                {
                    if (item.Name.Trim() == Grade.Name.Trim())
                    {
                        return "Name must not be the same.";
                    }
                    else
                    {
                        lstGrade.Remove(item);
                        lstGrade.Add(Grade);

                        break;
                    }
                }
            }

            return "Edited successfully.";
        }
    }
}
