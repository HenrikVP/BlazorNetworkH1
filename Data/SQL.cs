using System.Data.SqlClient;

namespace BlazorNetworkH1.Data
{
    public class SQL
    {
        SqlConnection sqlConnection = new SqlConnection(
            "Data Source =.; " +
            "Initial Catalog = BreakfastH1; " +
            "Integrated Security = True;");
    }
}
