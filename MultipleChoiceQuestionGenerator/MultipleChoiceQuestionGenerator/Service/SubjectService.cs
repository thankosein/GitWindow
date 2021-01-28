using MultipleChoiceQuestionGenerator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultipleChoiceQuestionGenerator.Model;
namespace MultipleChoiceQuestionGenerator.Service
{
    public static class SubjectService
    {   
        public static SubjectValidationService service;

        static SubjectService()
        {
            service = new SubjectValidationService(new SubjectData());
        }

        public static string GetSubjectId()
        {
            List<Subject> lstSubject = service.GetAll().ToList();
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

        public static void ReadData(System.Windows.Forms.DataGridView dgv)
        {
            dgv.Rows.Clear();
            List<Subject> lstSubject = SubjectService.service.GetAll().ToList();
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
    }
}
