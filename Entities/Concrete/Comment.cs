using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment : IEntity
    {
        [Key]
        public int CommentID { get; set; }
        public string CommentUserName { get; set; } = string.Empty;
        public string CommentTitle { get; set; } = string.Empty;
        public string CommentContent { get; set; } = string.Empty;
        public DateTime CommentDate { get; set; }
        public int BlogRaytingScore { get; set; }
        public bool CommentStatus { get; set; } = false;
        public int BlogID { get; set; }
        public Blog? Blog { get; set; }
    }
}
