using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Dto
{
    /// <summary>
    /// 这个页面的内容是给用户看的
    /// !!!不能有对象
    /// </summary>
    public class ArticleDto
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

        public string Email { get; set; }

        public int GoodCount { get; set; }

        public int BadCount { get; set; }

        public string ImagePath { get; set; }

        public string[] CategoryNames { get; set; }

        public Guid[] CategoryIDs { get; set; }
    }
}
