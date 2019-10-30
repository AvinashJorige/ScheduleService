
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Students
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string ContactEmail { get; set; }
        public decimal ContactMobile { get; set; }
        public string AdditionalComments { get; set; }
        public bool IsResgistered { get; set; }
        public DateTime ResgisteredDate { get; set; }
        public bool IsActive { get; set; }
        public bool PasswordGenerated { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
