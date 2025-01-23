namespace labs.Classes;

public class DeveloperInfoAttribute : Attribute
{
    private string developer;
    private DateTime date;
    public string DeveloperName => developer;
    public DateTime Date => date;

    public DeveloperInfoAttribute(string developerName, string date)
    {
        developer = developerName;
        this.date = DateTime.Parse(date);
    }
    
    public override string ToString()
    {
        return $"Разработчик: {DeveloperName}, Дата разработки класса: {Date:dd/MM/yyyy}";
    }
}