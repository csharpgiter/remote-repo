using SmartFactory.BusinessInterface;
using SqlSugar;

namespace SmartFactory.BusinessService
{
    public class SystemlogService : BaseService, ISystemlogService
    {
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
        public SystemlogService(ISqlSugarClient client) : base(client)
        {
        }
    }
}
