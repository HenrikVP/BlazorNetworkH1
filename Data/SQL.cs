using System.Data;
using System.Data.SqlClient;

namespace BlazorNetworkH1.Data
{
    public class SQL
    {
        SqlConnection con = new SqlConnection(
               "Data Source =.; " +
               "Initial Catalog = BreakfastH1; " +
               "Integrated Security = True;");
        public bool CreateFood(Food f)
        {
            SqlCommand cmd = new("INSERT INTO [food] VALUES (@item, @amount, @price)", con);
            cmd.Parameters.Add("@item", SqlDbType.NVarChar).Value = f.Item;
            cmd.Parameters.Add("@amount", SqlDbType.Int).Value = f.Amount;
            cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = f.Price;
            con.Open();
            bool isSuccess = cmd.ExecuteNonQuery() == 1 ? true : false;
            con.Close();
            return isSuccess;
        }

        public List<Food> ReadFood()
        {
            List<Food> list = new();
            SqlCommand cmd = new("SELECT * FROM [food]", con);
            con.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Food f = new()
                    {
                        Id = reader.GetInt32(0),
                        Item = reader.GetString(1),
                        Amount = reader.GetInt32(2),
                        Price = (double)reader.GetDecimal(3)
                    };
                    list.Add(f);
                }
            }
            con.Close();
            return list;
        }
    }
}
