namespace ZooShop.Models;
public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public PetType Type { get; set; }
    public int TypeId { get; set; }
}

public class PetType
{
    public int Id { get; set; }
    public required string Name { get; set; }
}

