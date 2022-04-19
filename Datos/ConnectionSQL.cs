using System.Data.SqlClient;
namespace CRUDMVC.Datos
{
    public class ConnectionSQL
    {
        private static string  stringConnexionSQL = string.Empty;

        public ConnectionSQL()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            stringConnexionSQL = builder.GetSection("ConnectionStrings:StringSQL").Value;
            
        }

        public string GetConnectionString() { return stringConnexionSQL; }



    }
}
