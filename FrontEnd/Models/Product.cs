namespace Models;

public class Product
{
    public int Id{get; set;}
    public string? Name{get; set;}
    public int Price{get; set;}
    
    public int Quantity{get; set;}

    public override string ToString()
    {
        string qString=$"Id: {Id} \nItem: {Name} \nPrice: ${Price} \nQuantity: {Quantity}\n~~~~~~~~~~~~~~~~~~~";
        return qString;
    }


}