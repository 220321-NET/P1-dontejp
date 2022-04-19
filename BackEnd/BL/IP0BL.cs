namespace BL;
public interface IP0BL
{
    public Task<List<Product>> GetInventory(int VillageID);

    public Customer CreateCustomer(Customer customerToCreate);

    public Task<List<Customer>> GetAllCustomersAsync();

    public void UpdateInventory(int item, int remaining, int VillageID);

    public Task<int> GetProduct(int item, int VillageID);



    
    //public void GetInventory();
    //public void GetUsers();
    //public void CreateCustomer();








}
