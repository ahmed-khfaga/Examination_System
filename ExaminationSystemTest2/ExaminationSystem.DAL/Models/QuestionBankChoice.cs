using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.DAL.Models
{
    public class QuestionBankChoice
    {
        public int QuestionId { get; set; }
        public string Choice { get; set; } = null!;
        public virtual QuestionBank Question { get; set; } = null!;



    }
}
