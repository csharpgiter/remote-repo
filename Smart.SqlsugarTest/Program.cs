using SqlSugar;
using SmartFactory.Entity.EntityMap;
namespace Smart.SqlsugarTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //---准备连接数据库的对象 ConnectionConfig
            try
            {
                ConnectionConfig connection = new ConnectionConfig()
                {
                    ConnectionString = "Data Source=.;Initial Catalog=Zhaoxi.SmartFactory;User ID=sa;Password=123456;Trust Server Certificate=True",
                    DbType = DbType.SqlServer,
                    IsAutoCloseConnection = true,
                    InitKeyType = InitKeyType.Attribute
                };
                SqlSugarClient sqlSugarClient = new SqlSugarClient(connection);
                //sqlSugarClient.DbFirst.CreateClassFile("D:\\桌面\\Zhaoxi\\SmartFactoryApi\\SmartFactory.Entity\\EntityMap");
                SystemLog systemLog = sqlSugarClient.Queryable<SystemLog>().First();
                systemLog.Id = 0;
                systemLog.Message = "测试";
                //sqlSugarClient.Insertable<SystemLog>(systemLog).ExecuteCommand()
                int rows= sqlSugarClient.Insertable<User>(new List<User>()
                {
                    new User()
                    {
                        UserName = "张三",
                        PassWord = "123456",
                        Age = 18,
                        CurrentAddress = "北京",
                        EntryTime = DateTime.Now.AddYears(-2),
                        IdNumber = "123456789",
                        SexType = 1,
                        HomeAddress = "河北",
                        JobStatus = 1,
                    },
                    new User()
                    {
                        UserName = "李四",
                        PassWord = "123166",
                        Age = 18,
                        CurrentAddress = "北京",
                        EntryTime = DateTime.Now.AddYears(-1),
                        IdNumber = "123456789",
                        SexType = 0,
                        HomeAddress = "江西",
                        JobStatus = 2,
                    },
                    new User()
                    {
                        UserName = "王五",
                        PassWord = "123246",
                        Age = 18,
                        CurrentAddress = "北京",
                        EntryTime = DateTime.Now.AddYears(-2),
                        IdNumber = "123456789",
                        SexType = 1,
                        HomeAddress = "石家庄",
                        JobStatus = 2,
                    },
                    new User()
                    {
                        UserName = "赵六",
                        PassWord = "123256",
                        Age = 18,
                        CurrentAddress = "北京",
                        EntryTime = DateTime.Now.AddYears(-3),
                        IdNumber = "123456789",
                        SexType = 0,
                        HomeAddress = "南京",
                        JobStatus = 3,
                    }
                }).ExecuteCommand();
                Console.WriteLine(rows);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
