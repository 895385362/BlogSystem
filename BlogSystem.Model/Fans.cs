using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Model
{
    public class Fans:BaseEntity
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        [ForeignKey(nameof(User))]
        public Guid UserID { get; set; }

        public UserModel User { get; set; }

        /// <summary>
        /// 关注的用户编号
        /// </summary>
        [ForeignKey(nameof(FocusUser))]
        public Guid FocusUserID { get; set; }

        public UserModel FocusUser { get; set; }
    }
}
