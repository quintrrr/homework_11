namespace BankLibrary.BankAccountLibrary;

public class DeveloperInfoAttribute : Attribute
{
    private string developer;
    private string organization;
    public string DeveloperName => developer;
    public string Organization => organization;

    public DeveloperInfoAttribute(string developerName, string organization)
    {
        developer = developerName;
        this.organization = organization;
    }
    
    public override string ToString()
    {
        return $"Разработчик: {DeveloperName}, Название организации: {Organization}";
    }
}