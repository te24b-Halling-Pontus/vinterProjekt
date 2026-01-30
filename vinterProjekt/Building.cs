using System.Net.NetworkInformation;

namespace buildingClass;

public class Building
{
    public string name;
    public int amount = 0;
    public int price;
    public int startPrice;
    public float MPS; //MPS = Money per secound
    public float startMPS;
    public Building(string name, int price, float MPS)
    {
        this.name = name; //this. is the public string declerd above insted of the imported verible from program.cs
        this.price = price;
        this.MPS = MPS;
        startPrice = price;
        startMPS = MPS;
    }
}