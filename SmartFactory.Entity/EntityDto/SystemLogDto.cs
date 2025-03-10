using System;
using System.Linq;
using System.Text;

namespace SmartFactory.Entity.EntityMap
{
    ///<summary>
    ///
    ///</summary>
    public partial class SystemLogDto
    {

        public int Id { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime Date { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
       
        public string? DateStr
        {
            get
            {
                return this.Date.ToString("yyyy年MM月dd日 HH:mm:ss");
            }
        }
        public string Logger { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Message { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Exception { get; set; }

    }
}
