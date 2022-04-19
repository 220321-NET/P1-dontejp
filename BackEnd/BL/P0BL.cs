namespace BL;

public class P0BL: IP0BL
{
    private readonly DBRepository _repo; 
    public P0BL(DBRepository repo)
    {
        _repo = repo;
    }

    public Customer CreateCustomer(Customer customerToCreate)
    {
        return  _repo.CreateCustomer(customerToCreate);
    }
    public async Task<List<Product>> GetInventory(int VillageID)
    {
        return await _repo.GetInventory(VillageID);
    }

    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        return await _repo.GetAllCustomersAsync();
    }

    public async Task<int> GetProduct(int item, int VillageID)
    {
        return await _repo.GetProduct(item, VillageID);
    }

    public void UpdateInventory(int item, int remaining, int VillageID)
    {
        _repo.UpdateInventory(item, remaining, VillageID);
    }




}