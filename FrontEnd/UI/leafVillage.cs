namespace UI;

public class leafVillage: StoreFronts
{
    protected int VillageID;

    public leafVillage(HttpService httpService): base(httpService)
    {

    }

    public virtual async Task Start()
    {
        VillageID = 1;
        await Welcome();
        await CartPrompt();
    }

    protected async Task Welcome()
    {
    
    List<Product> product = await _httpService.GetInventoryAsync(VillageID);
        foreach(Product p in product )
        {
            Console.WriteLine(p);
        }
    }

    protected async Task CartPrompt()
    {
        tryagain1:
        Console.WriteLine("Would you like to buy something [Y/N]");
        string? answer = Console.ReadLine();
        if(answer != null)
        {
            char answerC = answer[0];

            if(Char.ToUpper(answerC) == 'Y')
            {
                Console.WriteLine("Enter the product Id you'd like to purchase");
                string? i = Console.ReadLine();
                int item = Convert.ToInt32(i);
                Console.WriteLine(VillageID);
                Console.WriteLine(item);
                int number = await _httpService.GetProductAsync(item,VillageID);
                Console.WriteLine(number);
                Console.WriteLine("How many would you like to buy?: ");
                string? b = Console.ReadLine();
                int buy = Convert.ToInt32(b);

                if (number>=buy && buy >0)
                {
                    int remaining = number - buy;
                    await _httpService.UpdateInventoryAsync(item, remaining, VillageID);
                    Console.WriteLine(buy+ " items purchased "+remaining+ " remaining");
                }
                else if(number< buy)
                {
                    Console.WriteLine("There is not enough of that product to complete your purchase...");
                    goto tryagain1;
                }
            }
            else if(Char.ToUpper(answerC) == 'N')
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid input... Try again!");
                goto tryagain1;
            }
        }
    }
}