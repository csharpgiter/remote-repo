using SmartFactory.BusinessInterface;
using SqlSugar;

namespace SmartFactory.BusinessService
{
    public class UserService : BaseService, IUserService
    {
        #region 伪代码
        //public void Add()
        //{
        //    // Add system log
        //}
        //public void Update()
        //{
        //    // Update system log
        //}
        //public void Delete()
        //{
        //    // Delete system log
        //}
        //public void Query()
        //{
        //    // Get system log
        //}
        #endregion
        public UserService(ISqlSugarClient client) : base(client)
        {
        }
    }
}
