using MultipleChoiceQuestionGenerator.Common;
using MultipleChoiceQuestionGenerator.Data;
using MultipleChoiceQuestionGenerator.Model;
using System.Collections.Generic;
using System.Linq;

namespace MultipleChoiceQuestionGenerator.Service
{
    public static class GradeServiceTwo
    {
        public static GenericCrudByIntegerKey<Grade> service;
        public static ValidateGrid validateService;
        static GradeServiceTwo()
        {
            service = new GenericCrudByIntegerKey<Grade>(new GradeCrud());
            validateService = new ValidateGrid(new GradeCrud());
        }
        
    }

    public class ValidateGrid : GenericCrudByIntegerKey<Grade>
    {
        public ValidateGrid(IGenericCrudByIntegerKey<Grade> crud) 
            : base(crud) 
        { }

        public override void BeforeAdd(Grade g)
        {
            string msg = "";
            try
            {
                List<Grade> lstGrades = GradeServiceTwo.service.GetAll().ToList();
                foreach (var item in lstGrades)
                {
                    if (item.Name == g.Name)
                    {
                        msg = "Name has already existed.";
                        throw new System.Exception("Name has already existed.");
                        // System.Windows.Forms.MessageBox.Show("Name already exist.");
                    }
                }
            }
            catch (System.Exception ex)
            {
                msg = ex.ToString();
                ex.ToString();
            }
            finally
            {
                if(msg != "")
                {
                    System.Windows.Forms.MessageBox.Show(msg);

                    throw new System.Exception(msg);
                }
            }
            
        }
    }
}
