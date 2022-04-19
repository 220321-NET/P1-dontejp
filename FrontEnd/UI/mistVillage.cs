
namespace UI;

public class mistVillage: leafVillage
{
    public mistVillage(HttpService httpService) : base(httpService) { }

    public override async Task Start()
    {
        VillageID = 4;
        await Welcome();
        await CartPrompt();
    }
}