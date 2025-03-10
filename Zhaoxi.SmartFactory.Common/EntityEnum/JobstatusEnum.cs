using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Zhaoxi.SmartFactory.Common.EntityEnum.EnumManager;

namespace Zhaoxi.SmartFactory.Common.EntityEnum
{
    public enum JobstatusEnum
    {
        [Remark("离职")]
        left=0,
        [Remark("在职")]
        on=1
    }
}
