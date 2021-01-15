using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Model
{
    public class BaseEntity
    {
        /// <summary>
        /// 编号
        /// </summary>
        public Guid ID { get; set; } = Guid.NewGuid();

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
        
        /// <summary>
        /// 是否被删除
        /// </summary>
        public bool IsRemoved { get; set; }
    }
}
