using System.Configuration;

namespace QulixApp.DataAccessLayer.Domain
{
    public class Base
    {
        private static string ConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["DefaultConnection"];
            }
        }

        public static string strConnect
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[ConnectionString].ConnectionString;
            }
        }
    }
}
