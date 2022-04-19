using Microsoft.Data.SqlClient;
using Models;


namespace DB;
public class DBRepository
{
    private readonly string? _connectionString;
    public DBRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    public async Task<List<Customer>> GetAllCustomersAsync()
    {
            List<Customer> allCustomers = new List<Customer>();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            

            SqlCommand cmd = new SqlCommand("SELECT * FROM Users", connection);

            SqlDataReader reader = cmd.ExecuteReader();
            while(await reader.ReadAsync())
            {
                int id = reader.GetInt32(0);
                string username = reader.GetString(1);
                int balance = reader.GetInt32(2);

                Customer profile = new Customer{
                        Id = id,
                        Username = username,
                        Balance = balance
                };
                allCustomers.Add(profile);
            }
            reader.Close();
            connection.Close();

            return allCustomers;
    }
    public Customer CreateCustomer(Customer customerToCreate)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand cmd = new SqlCommand("INSERT INTO Users(Username, Balance) OUTPUT INSERTED.Id Values (@Username,@Balance)", connection);

        cmd.Parameters.AddWithValue("@Username", customerToCreate.Username);
        cmd.Parameters.AddWithValue("@Balance", customerToCreate.Balance);

        customerToCreate.Id = (int) cmd.ExecuteScalar();

        // using SqlCommand cmd = new SqlCommand($"INSERT INTO Users(Id,Username, Balance) VALUES ({customerToCreate.Id}{customerToCreate.Username}, {customerToCreate.Balance})", connection);

        connection.Close();

        return customerToCreate;
    }
    public void UpdateInventory(int item, int remaining, int VillageID)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand cmd = new SqlCommand("UPDATE Inventory SET Quantity_INV = @remaining where ProductID = @item and VillageID = @VillageID", connection);
        cmd.Parameters.AddWithValue("@item", item);
        cmd.Parameters.AddWithValue("@VillageID",VillageID);
        cmd.Parameters.AddWithValue("@remaining", remaining);

        cmd.ExecuteScalar();

        connection.Close();
    }
    public async Task<List<Product>> GetInventory(int VillageID)
    {
        List<Product> Inventory = new List<Product>();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            
            SqlCommand cmd = new SqlCommand("SELECT Inventory.ProductID, Product, Price, Quantity_INV FROM Inventory INNER JOIN Product ON Inventory.ProductID = Product.ProductID WHERE VillageID = @VillageID", connection);
            cmd.Parameters.AddWithValue("@VillageID",VillageID);

            SqlDataReader reader = cmd.ExecuteReader();
            while(await reader.ReadAsync())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int price = reader.GetInt32(2);
                int quantity = reader.GetInt32(3);

                Product item = new Product{
                        Id = id,
                        Name = name,
                        Price = price,
                        Quantity = quantity
                };
                Inventory.Add(item);
            }

            reader.Close();
            connection.Close();
            return Inventory;
    }
    public async Task<int> GetProduct(int item, int VillageID)
    {
            int quantity=-1;

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Quantity_INV FROM Inventory INNER JOIN Product ON Inventory.ProductID = Product.ProductID WHERE Inventory.ProductID = @item and VillageID = @VillageID;", connection);

            cmd.Parameters.AddWithValue("@item", item);
            cmd.Parameters.AddWithValue("@VillageID", VillageID);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            { 
                quantity = reader.GetInt32(0); 
            }
            reader.Close();
            connection.Close();
            return quantity;
    }
}