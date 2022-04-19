// See https://aka.ms/new-console-template for more information
using UI;

//string connectionString = File.ReadAllText("./connectionString.txt");

//DBRepository repo = new DBRepository(connectionString);
//IP0BL bl = new P0BL(repo);
HttpService http = new HttpService();

await new mainMenu(http).start();

