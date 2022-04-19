
namespace UI;

public class stoneVillage: leafVillage
{
    public stoneVillage(HttpService httpService) : base(httpService) { }

    public override async Task Start()
    {
        VillageID = 5;
        await Welcome();
        await CartPrompt();
    }
}