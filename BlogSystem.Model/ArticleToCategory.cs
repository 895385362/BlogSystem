using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Model
{
    public class ArticleToCategory:BaseEntity
    {
        [ForeignKey(nameof(BlogCategory))]
        public Guid CategoryID { get; set; }

        public BlogCategory BlogCategory { get; set; }

        [ForeignKey(nameof(Article))]
        public Guid ArticleID { get; set; }

        public Article Article { get; set; }
    }
}
