namespace Models;

public class Customer
{
    public int Id{get; set;}
    public string? Username{ get; set;}
    public int Balance{ get; set;}

    public override string ToString()
    {
        string qString=$"Id: {Id} \nUsername: {Username} \nBalance: {Balance}";

        return qString;
    }
}