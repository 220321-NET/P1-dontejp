using System.Net.Http;
using System.Text.Json;
using System.Text;


namespace UI;

public class HttpService
{

    private readonly string _apiBaseURL = "https://localhost:7028/api/";

    private HttpClient client = new HttpClient();

    public HttpService()
    { 
        client.BaseAddress = new Uri(_apiBaseURL);
    }

    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        List<Customer> customers = new List<Customer>();

        try
        {
            customers =await JsonSerializer.DeserializeAsync<List<Customer>>(await client.GetStreamAsync("Customer")) ?? new List<Customer>();

        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("Something bad happened", ex);
        }

        return customers;
    }
    public async Task<Customer> CreateCustomerAsync(Customer customerToCreate)
    {
        Customer cust=new Customer();
        string serializedCustomer = JsonSerializer.Serialize(customerToCreate);
        StringContent content = new StringContent(serializedCustomer, Encoding.UTF8, "application/json");

        try
        {
            HttpResponseMessage response = await client.PostAsync("Customer", content);
            response.EnsureSuccessStatusCode();
            cust = await JsonSerializer.DeserializeAsync<Customer>(await response.Content.ReadAsStreamAsync()) ?? new Customer();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Couldn't Add Customer");
        }
        return cust;
    }
    public async Task<List<Product>> GetInventoryAsync(int VillageID)
    { 
        List<Product> products = new List<Product>();

        try
        { 
            products = await JsonSerializer.DeserializeAsync<List<Product>>(await client.GetStreamAsync($"Inventory/{VillageID}")) ?? new List<Product>();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Couldn't Get Inventory");
        }

        return products;
    }

    public async Task<int> GetProductAsync(int item, int VillageID)
    {
        int value=0;

        try
        {
            value = await JsonSerializer.DeserializeAsync<int>(await client.GetStreamAsync($"Product/{item}/{VillageID}"));
            return value;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Couldn't Get Inventory");
        }
        return value;

    }
    class Update
    { 
        public int item { get; set; }
        public int remaining { get; set; }
        public int VillageID { get; set; }
    }
    public async Task UpdateInventoryAsync(int item, int remaining, int VillageID) 
    {
        Update update = new Update();
        update.item = item;
        update.remaining = remaining;
        update.VillageID = VillageID;
        string sUpdate = JsonSerializer.Serialize(update);
        StringContent stringcontent = new StringContent(sUpdate, Encoding.UTF8, "application/json");
        try
        {
            HttpResponseMessage response = await client.PutAsync("Inventory", stringcontent);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Couldn't Update Inventory");
        }
    }

}
