namespace labs.Classes;

public class Building
{
    private static int nextBuildingNumber = 1;
    private int buildingNumber;
    private double height;
    private int floors;
    private int apartments;
    private int entrances;

    public int BuildingNumber { get => buildingNumber; private set => buildingNumber = value; }
    public double Height { get => height; private set => height = value; }
    public int Floors { get => floors; private set => floors = value; }
    public int Apartments { get => apartments; private set => apartments = value; }
    public int Entrances { get => entrances; private set => entrances = value; }

    public Building(double height, int floors, int apartments, int entrances)
    {
        if (height < 0) { throw new ArgumentException("Высота не может быть отрицательной"); }
        if (floors < 0) { throw new ArgumentException("Кол-во этажей не может быть отрицательным"); }
        if (entrances < 0) { throw new ArgumentException("Кол-во подъездов не может быть отрицательным"); }
        if (apartments < 0) { throw new ArgumentException("Кол-во квартир не может быть отрицательным"); }
        if (height / floors < 2) { throw new ArgumentException("Высота этажей не может быть меньше 2 метров"); } 
        if (apartments % entrances != 0 || apartments % floors != 0) { throw new ArgumentException("Количество квартир должно быть кратно количеству подъездов и этажей"); } 
    
        BuildingNumber = nextBuildingNumber++;
        Height = height;
        Floors = floors;
        Apartments = apartments;
        Entrances = entrances;
    }

    public void FloorHeight()
    {
        Console.WriteLine($"Высота этажей: {Height / floors}");
    }

    public void ApartmentsPerEntrance()
    {
        Console.WriteLine($"Кол-во квартир в подъезде: {Apartments / Entrances}");
    }

    public void AparartmentsPerFloor()
    {
        Console.WriteLine($"Кол-во квартир на этаже: {Apartments / Floors}");

    } 

    public override string ToString()
    {
        return $"Номер здания: {buildingNumber}, Высота здания: {height}, Кол-во этажей: {floors}, Кол-во квартир: {apartments}, Кол-во подъездов: {entrances}";
    }
}