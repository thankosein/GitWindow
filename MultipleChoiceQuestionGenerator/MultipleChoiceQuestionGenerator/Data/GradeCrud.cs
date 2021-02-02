using MultipleChoiceQuestionGenerator.Common;
using MultipleChoiceQuestionGenerator.Model;
using MultipleChoiceQuestionGenerator.Service;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceQuestionGenerator.Data
{
    public class GradeCrud : IGenericCrudByIntegerKey<Grade>
    {        
        public void Add(Grade entity)
        {            
            //InsertQuery
            string sql = "INSERT INTO Grade (Name) VALUES ('"+ entity.Name + "');";
            object c = Com.modSetData(sql);
        }

        public void Delete(Grade entity)
        {
            string sql = "DELETE * FROM Grade WHERE GradeId=" + entity.GradeId;
            Com.modSetData(sql);
        }

        public void Edit(int id, Grade entity)
        {
            string sql = "UPDATE Grade Set Name='" + entity.Name + "' WHRER GradeId=" + id;
            Com.modSetData(sql);
        }

        public IEnumerable<Grade> GetAll()
        {
            List<Grade> lst = new List<Grade>();
            string sql = "Select GradeId, Name From Grade";
            OleDbDataReader rstauto = Com.modGetDataReader(sql);
            if (rstauto.HasRows)
            {
                rstauto.Read();
                do
                {
                    Grade grade = new Grade 
                    { 
                        GradeId = Convert.ToInt32(rstauto[0]),
                        Name = rstauto[1].ToString()
                    };
                    lst.Add(grade);
                } while (rstauto.Read());
                rstauto.Close();
            }

            return lst.ToList();
        }

        public Grade GetById(int id)
        {
            List<Grade> lstGrade = GetAll().ToList();
            Grade grade = lstGrade.Where(x => x.GradeId == id).FirstOrDefault();
            return grade;
        }

        
    }
}
