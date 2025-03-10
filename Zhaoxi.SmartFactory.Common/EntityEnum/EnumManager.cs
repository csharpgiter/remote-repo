using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartFactory.Common.EntityEnum
{
    public class EnumManager
    {
        public static string GetJobStatusRemark(int ovalue)
        {
            JobstatusEnum jobstatusEnum = (JobstatusEnum)ovalue;
            FieldInfo fieldInfo = typeof(JobstatusEnum).GetField(jobstatusEnum.ToString());
            if (fieldInfo != null && fieldInfo.IsDefined(typeof(RemarkAttribute), true))
            {
                RemarkAttribute attribute = fieldInfo.GetCustomAttribute<RemarkAttribute>();
                return attribute.GetRemark();
            }
            return jobstatusEnum.ToString();
        }
        public class RemarkAttribute : Attribute
        {
            private string _Remark = string.Empty;
            public RemarkAttribute(string remark)
            {
                _Remark = remark;
            }
            public string GetRemark() => this._Remark;
        }
    }
}
