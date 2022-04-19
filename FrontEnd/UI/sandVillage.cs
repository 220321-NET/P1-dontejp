
namespace UI;

public class sandVillage: leafVillage
{
    public sandVillage(HttpService httpService) : base(httpService) { }

    public override async Task Start()
    {
        VillageID = 3;
        await Welcome();
        await CartPrompt();
    }
}