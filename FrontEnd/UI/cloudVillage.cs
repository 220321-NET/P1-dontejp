
using Models;

namespace UI;

public class cloudVillage: leafVillage
{
    public cloudVillage(HttpService httpService) : base(httpService) { }

    public override async Task Start()
    {
        VillageID = 2;
        await Welcome();
        await CartPrompt();
    }
}