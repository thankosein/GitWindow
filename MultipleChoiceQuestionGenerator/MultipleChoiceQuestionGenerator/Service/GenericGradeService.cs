using MultipleChoiceQuestionGenerator.Data;
using MultipleChoiceQuestionGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultipleChoiceQuestionGenerator.Service
{
    public static class GenericGradeService
    {
        public static List<Grade> lstGrade = new List<Grade>();
        static GenericClass<Grade> _genericObj = new GenericClass<Grade>(lstGrade);

        public static string AddGrade(Grade grade)
        {
            return _genericObj.AddGeneric(grade);
        }

        public static string DeleteGrade(int id)
        {
            foreach (var item in lstGrade)
            {
                if(item.GradeId == id)
                {
                    return _genericObj.RemoveGeneric(item);
                }
            }

            return "No grade record found.";
        }

        public static string EditGrid(Grade newGrade)
        {
            foreach (var item in lstGrade)
            {
                if(item.GradeId == newGrade.GradeId)
                {
                    if(item.Name == newGrade.Name)
                    {
                        return "Name must not be the same.";
                    }
                    else
                    {
                        return _genericObj.EditGeneric(item, newGrade);
                    }
                }
            }

            return "No grade records founds.";
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

        public static string GetGradeId()
        {
            Grade grade = lstGrade.LastOrDefault();
            if (grade == null)
            {
                return "1";
            }
            else
            {
                return (grade.GradeId + 1).ToString();
            }
        }
    }
}
