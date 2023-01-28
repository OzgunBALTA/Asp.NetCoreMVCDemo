using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Contact : IEntity
    {
        [Key]
        public int ContactID { get; set; }
        public string ContactUserName { get; set; } = string.Empty;
        public string ContactUserMail { get; set; } = string.Empty;
        public string ContactTitle { get; set; } = string.Empty;
        public string ContactMessage { get; set; } = string.Empty;
        public DateTime ContectDate { get; set; }
        public bool ContectStatus { get; set; }

    }
}
