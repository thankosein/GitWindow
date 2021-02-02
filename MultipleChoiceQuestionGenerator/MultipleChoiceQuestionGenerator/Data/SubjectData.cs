using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultipleChoiceQuestionGenerator.Common;
using MultipleChoiceQuestionGenerator.Model;

namespace MultipleChoiceQuestionGenerator.Data
{
    public class SubjectData : IGenericCrudByIntegerKey<Subject>
    {
        public void Add(Subject entity)
        {
            string insertQuery = "INSERT INTO Subject (Name, Remarks) VALUES ('" + entity.Name + "','" + entity.Remarks + "');";
            Com.modSetData(insertQuery);
        }

        public void Delete(Subject entity)
        {
            string deleteQuery = "DELETE * FROM Subject WHERE SubjectID=" + entity.SubjectId;
            Com.modSetData(deleteQuery);
        }

        public void Edit(int id, Subject entity)
        {
            string updateQuery = "UPDATE [Subject] SET Name='" + entity.Name + "', Remarks='" + entity.Remarks + "' WHERE SubjectId=" + entity.SubjectId + ";";
            Com.modSetData(updateQuery);
        }

        public IEnumerable<Subject> GetAll()
        {
            List<Subject> lstSubject = new List<Subject>();
            string selectQuery = "SELECT * FROM Subject;";
            OleDbDataReader reader = Com.modGetDataReader(selectQuery);
            if (reader.HasRows)
            {
                reader.Read();
                do
                {
                    Subject objSubject = new Subject();
                    objSubject.SubjectId = Convert.ToInt32(reader["SubjectId"]);
                    objSubject.Name = reader["Name"].ToString();
                    objSubject.Remarks = reader["Remarks"].ToString();
                    lstSubject.Add(objSubject);
                } while (reader.Read());
            }

            return lstSubject.ToList();
        }

        public Subject GetById(int id)
        {
            string selectQuery = "SELECT * FROM Subject Where SubjectId="+id+";";
            OleDbDataReader reader = Com.modGetDataReader(selectQuery);
            if (reader.HasRows)
            {
                reader.Read();
                Subject objSubject = new Subject
                {
                    SubjectId = Convert.ToInt32(reader["SubjectId"]),
                    Name = reader["Name"].ToString(),
                    Remarks = reader["Remarks"].ToString()
                };

                return objSubject;
            }

            return null;
        }
    }
}
