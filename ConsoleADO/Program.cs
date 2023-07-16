// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

Console.WriteLine("Hello, World!");

string cs = "Server=(localdb)\\MSSQLLocalDB; Database=Rumos; Integrated Security=SSPI; Persist Security Info=False;";

SqlConnection con = new SqlConnection(cs);

try
{
    con.Open();
    // data retrieving
    Console.WriteLine("Connected");

    using (con)
    {
        string query = "SELECT * FROM Costumers";

        
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = query;
        cmd.Connection = con;

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
            Console.WriteLine($"{reader["ClientId"]} - {reader["FirstName"]} {reader["LastName"]}");
        



        /*
        query = "INSERT Costumers(FirstName,LastName,BirthDay,Age,AddressId) VALUES ('Ana', 'Soares', NULL, 35, 1)";
        SqlCommand cmd_2 = new SqlCommand();
        cmd_2.CommandText = query;
        cmd_2.Connection = con;
        int result = cmd_2.ExecuteNonQuery();

        if (result == 0)
            Console.WriteLine("Insert gonna bad! please try again later");
        else
            Console.WriteLine("Insert ok!");
        */





        /*string first_name = "Filipa";

        query = "INSERT Costumers(FirstName,LastName,BirthDay,Age,AddressId) VALUES (@FirstName, 'Soares', NULL, 35, 1)";
        SqlCommand cmd_2 = new SqlCommand();
        cmd_2.CommandText = query;
        cmd_2.Connection = con;
        cmd_2.Parameters.AddWithValue("@FirstName", first_name);

        int result = cmd_2.ExecuteNonQuery();

        if (result == 0)
            Console.WriteLine("Insert gonna bad! please try again later");
        else
            Console.WriteLine("Insert ok!");*/





        /*
        query = "SELECT COUNT(ClientId) as 'Total pessoas'  " +
            "FROM Costumers LEFT JOIN tblAddresses ON Costumers.AddressId = tblAddresses.Id;";

        SqlCommand cmd_3 = new SqlCommand();
        cmd_3.CommandText = query;
        cmd_3.Connection = con;
        object result = cmd_3.ExecuteScalar();

        Console.WriteLine($"O total de registos na BD é {result}");*/
    }
}
catch (SqlException e)
{
    Console.WriteLine(e.ToString());
    Console.WriteLine("Couldn’t connect");
}
finally
{
    if (con.State == ConnectionState.Open)
        con.Close();
}
