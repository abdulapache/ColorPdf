using Dapper;
using Dataaccess.Entites;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PersonalApp.Utilites
{
    public class StoredProcedure
    {
        private readonly IConfiguration _config;
        public StoredProcedure(IConfiguration config)
        {
            _config = config;
        }
        public List<Customer> getManagerDsa(int ManagerId)
        {
            using (var connection = new SqlConnection(_config.GetConnectionString("StudentDb")))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@ManagerId", ManagerId);


                var result = connection.Query<Customer>(
                    sql: "getManagerDSA",
                    param: parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }
    }
}
