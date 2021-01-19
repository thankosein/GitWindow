using MultipleChoiceQuestionGenerator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultipleChoiceQuestionGenerator.Service
{
    public static class GenericSubjectService
    {
        public static List<Subject> lstSubject = new List<Subject>();
        static GenericClass<Subject> _genericObj = new GenericClass<Subject>(lstSubject);

        public static string AddSubject(Subject Subject)
        {
            return _genericObj.AddGeneric(Subject);
        }

        public static string DeleteSubject(int id)
        {
            foreach (var item in lstSubject)
            {
                if (item.SubjectId == id)
                {
                    return _genericObj.RemoveGeneric(item);
                }
            }

            return "No Subject record found.";
        }

        public static string EditGrid(Subject newSubject)
        {
            foreach (var item in lstSubject)
            {
                if (item.SubjectId == newSubject.SubjectId)
                {
                    if (item.Name == newSubject.Name)
                    {
                        return "Name must not be the same.";
                    }
                    else
                    {
                        return _genericObj.EditGeneric(item, newSubject);
                    }
                }
            }

            return "No Subject records founds.";
        }

        public static void ReadData(DataGridView dgv)
        {
            dgv.Rows.Clear();
            foreach (var item in lstSubject)
            {
                string[] row = new string[]
                {
                    item.SubjectId.ToString(),
                    item.Name,
                    item.Remarks
                };
                dgv.Rows.Add(row);
            }
        }

        public static string GetSubjectId()
        {
            Subject Subject = lstSubject.LastOrDefault();
            if (Subject == null)
            {
                return "1";
            }
            else
            {
                return (Subject.SubjectId + 1).ToString();
            }
        }
    }
}
