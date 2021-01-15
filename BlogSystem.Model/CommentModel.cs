using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Model
{
    public class CommentModel : BaseEntity
    {
        [ForeignKey(nameof(User))]
        public Guid UserID { get; set; }

        public UserModel User { get; set; }

        [Required]
        [StringLength(800)]
        public string Content { get; set; }

        [ForeignKey(nameof(Article))]
        public Guid ArticleID { get; set; }

        public Article Article { get; set; }
    }
}
