namespace buildingClass;

public class Building
{
    public string name;
    public int amount = 0;
    public int price;
    public float OPS;
    public Building(string name, int price, float OPS)
    {
        this.name = name; //this. is the public string declerd above insted of the imported verible from program.cs
        this.price = price;
        this.OPS = OPS;
    }
}