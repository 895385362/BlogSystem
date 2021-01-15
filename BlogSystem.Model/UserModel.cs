using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Model
{
    public class UserModel:BaseEntity
    {
        [Required,StringLength(40),Column(TypeName = "varchar")]
        public string Email { get; set; }

        [Required,StringLength(30),Column(TypeName = "varchar")]
        public string Password { get; set; }

        [Required,StringLength(300),Column(TypeName = "varchar")]
        public string ImagePath { get; set; }


        /// <summary>
        /// 粉丝数
        /// </summary>
        public int FunsCount { get; set; }

        /// <summary>
        /// 关注数
        /// </summary>
        public int FocusCount { get; set; }

        /// <summary>
        /// 网站名
        /// </summary>
        public string SiteName { get; set; }
    }
}
