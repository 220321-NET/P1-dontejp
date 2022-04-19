
using Models;

namespace UI;

public class StoreFronts: mainMenu
{

public StoreFronts(HttpService httpService): base(httpService)
{}
    public async Task Start(Customer currentCustomer)
    {
        Console.WriteLine("Welcome to the Ninja hub "+ currentCustomer.Username + "             Balance: $" + currentCustomer.Balance);
        await WelcomePrompt();
    }

//--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--
//--<>--<>--<>--<>--<>--<>--<>--<>--            All Methods           --<>--<>--<>--<>--<>--<>--<>--<>--
//--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--



    private async Task WelcomePrompt()
    {
    reset:
        Console.WriteLine("{1} Hidden Leaf Village");
        Console.WriteLine("{2} Hidden Cloud Village");
        Console.WriteLine("{3} Hidden Sand Village");
        Console.WriteLine("{4} Hidden Mist Village");
        Console.WriteLine("{5} Hidden Stone Vilage");
        Console.WriteLine("\nEnter a number!\n");
    reset1:
        Console.WriteLine("Which store would you like to enter?");
        string? a =Console.ReadLine();
        if(a != null)
        {
            switch(a)
            {
            case "1":
                    leafVillage leaf = new leafVillage(_httpService);
                    await leaf.Start();
                goto reset;
            case "2":
                    cloudVillage cloud = new cloudVillage(_httpService);
                    await cloud.Start();
                goto reset;
            case "3":
                    sandVillage sand = new sandVillage(_httpService);
                    await sand.Start();
                goto reset;
            case "4":
                    mistVillage mist = new mistVillage(_httpService);
                    await mist.Start();
                goto reset;
            case "5":
                    stoneVillage stone = new stoneVillage(_httpService);
                    await stone.Start();
                goto reset;
            default:
                    Console.WriteLine("The value you entered is not one of the stores... \nTry again!");
                goto reset1;
            }
        }
    }
}