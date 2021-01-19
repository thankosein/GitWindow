using MultipleChoiceQuestionGenerator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultipleChoiceQuestionGenerator.Service
{
    public static class SubjectService
    {
        public static List<Subject> lstSubject = new List<Subject>();

        public static string GetGradeId()
        {
            Subject sub = lstSubject.LastOrDefault();
            if (sub == null)
            {
                return "1";
            }
            else
            {
                return (sub.SubjectId + 1).ToString();
            }
        }

        public static string AddSubject(Subject quest)
        {
            lstSubject.Add(quest);

            return "Add successfully";
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

        public static string DeleteSubject(int subjectId)
        {
            foreach (var item in lstSubject)
            {
                if (item.SubjectId == subjectId)
                {
                    lstSubject.Remove(item);
                    break;
                }
            }
            return "Deleted successfully.";
        }

        public static string EditSubject(Subject subject)
        {
            foreach (var item in lstSubject)
            {
                if (item.SubjectId == subject.SubjectId)
                {
                    if (item.Name.Trim() == subject.Name.Trim() && item.Remarks.Trim() == subject.Remarks.Trim())
                    {
                        return "Name and Remarks must not be the same.";
                    }
                    else
                    {
                        lstSubject.Remove(item);
                        lstSubject.Add(subject);

                        break;
                    }
                }
            }

            return "Edited successfully.";
        }
    }
}
//ctrl + m + o