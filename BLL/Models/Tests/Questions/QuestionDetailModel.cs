using BLL.Models.Tests.Answers;
using BLL.Models.Tests.Tests;
using DAL.Models.Entities.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Tests.Questions
{
    public class QuestionDetailModel
    {
        public string Text { get; set; }
        public TestDetailModel? Test { get; set; }
        public IList<AnswerVariantModel> Answers { get; set; }

        public QuestionDetailModel() { }
    }
}
