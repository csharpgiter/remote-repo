using System;
using System.Linq;
using System.Text;
using Zhaoxi.SmartFactory.Common.EntityEnum;

namespace SmartFactory.Entity.EntityMap
{
    ///<summary>
    ///
    ///</summary>
    public partial class UserDto
    {
          
                        /// <summary>
            /// Desc:
            /// Default:
            /// Nullable:False
            /// </summary>           
            
            public int Id { get; set; }

            /// <summary>
            /// Desc:
            /// Default:
            /// Nullable:False
            /// </summary>           
            public string UserName { get; set; }

            /// <summary>
            /// Desc:
            /// Default:
            /// Nullable:False
            /// </summary>           

            /// <summary>
            /// Desc:
            /// Default:
            /// Nullable:False
            /// </summary>           
            public int Age { get; set; }

            /// <summary>
            /// Desc:
            /// Default:
            /// Nullable:False
            /// </summary>           
            public int SexType { get; set; }

        public string SextypeDes 
        {
            get
            {
                if(SexType==(int)SextypeEnum.male)
                {
                    return "男性";
                }
                else 
                {
                    return "女性";
                }
            }
        }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string CurrentAddress { get; set; }

            /// <summary>
            /// Desc:
            /// Default:
            /// Nullable:False
            /// </summary>           
            public string HomeAddress { get; set; }

            /// <summary>
            /// Desc:
            /// Default:
            /// Nullable:False
            /// </summary>           
            public DateTime EntryTime { get; set; }

            /// <summary>
            /// Desc:离职时间
            /// Default:
            /// Nullable:True
            /// </summary>           
           
            public DateTime? DepartTime { get; set; }

            /// <summary>
            /// Desc:
            /// Default:
            /// Nullable:False
            /// </summary>           
            public int JobStatus { get; set; }
        /// <summary>
        /// 在职状态文字描述
        /// </summary>
            public string JobStatusDes { 
            get
            {
              return EnumManager.GetJobStatusRemark(JobStatus);
            }
        }
        

    }
}
