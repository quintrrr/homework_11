namespace labs.Classes;

public class Buildings
{
    private Building[] buildings = new Building[10];


    public Building this[int index]
    {
        get
        {
            foreach (Building building in buildings)
            {
                if (building.BuildingNumber == index)
                {
                    return building;
                }
            }
            return null;
        }
    }
}