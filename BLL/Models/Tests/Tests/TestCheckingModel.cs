using BLL.Models.Tests.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Tests.Tests
{
    public class TestCheckingModel : BaseModel
    {
        public int UserId { get; set; }
        public ICollection<int> AnswerIds { get; set; }
    }
}
