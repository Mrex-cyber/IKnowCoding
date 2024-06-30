using BLL.Models.Tests.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Tests.Tests
{
    public class TestDetailModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsFree { get; set; }
        public string ImagePath { get; set; }
        public int? Result { get; set; }
        public IList<QuestionDetailModel> Questions { get; set; }

        public TestDetailModel() { }
    }
}
