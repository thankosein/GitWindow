using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultipleChoiceQuestionGenerator.Common;
using MultipleChoiceQuestionGenerator.Model;

namespace MultipleChoiceQuestionGenerator.Service
{
    public class SubjectValidationService : GenericCrudByIntegerKey<Subject>
    {
        public SubjectValidationService(IGenericCrudByIntegerKey<Subject> tks)
            : base(tks)
        {

        }

        public override void BeforeAdd(Subject entity)
        {
            
        }

        public override void AfterAdd(Subject entity)
        {
            
        }
    }
}
