using System.IO;
using System.Text.Json;

public class Organizations
{
    public int Id { get; set; }

    public string NameOrganization { get; set; }

    public string DirectorNumber { get; set; }

    public int OrderID { get; set; }

    public Order Order { get; set; }

    public Organizations() { }

    public Organizations(int Id, string NameOrganization, string DirectorNumber, int OrderID, Order Order)
    {
        this.Id = Id;
        this.NameOrganization = NameOrganization;
        this.DirectorNumber = DirectorNumber;
        this.OrderID = OrderID;
        this.Order = Order;
    }
}

public class Order
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int AutoId { get; set; }

    public int StaffId { get; set; }

    public int AdressId { get; set; }

    public int OrganizationsId { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public int InvoiceId { get; set; }


    public Order() { }

    public Order(int Id, int ProductId, int AutoId, int StaffId, int AdressId, int OrganizationsId, string PhoneNumber, string Email, int InvoiceId)
    {
        this.Id = Id;
        this.ProductId = ProductId;
        this.AutoId = AutoId;
        this.StaffId = StaffId;
        this.AdressId = AdressId;
        this.OrganizationsId = OrganizationsId;
        this.PhoneNumber = PhoneNumber;
        this.Email = Email;
        this.InvoiceId = InvoiceId;
    }
}



public class JsonHandler<T> where T : class
{
    private string fileName;
    JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };


    public JsonHandler() { }

    public JsonHandler(string fileName)
    {
        this.fileName = fileName;
    }


    public void SetFileName(string fileName)
    {
        this.fileName = fileName;
    }

    public void Write(List<T> list)
    {
        string jsonString = JsonSerializer.Serialize(list, options);

        if (new FileInfo(fileName).Length == 0)
        {
            File.WriteAllText(fileName, jsonString);
        }
        else
        {
            Console.WriteLine("Specified path file is not empty");
        }
    }

    public void Delete()
    {
        File.WriteAllText(fileName, string.Empty);
    }

    public void Rewrite(List<T> list)
    {
        string jsonString = JsonSerializer.Serialize(list, options);

        File.WriteAllText(fileName, jsonString);
    }

    public void Read(ref List<T> list)
    {
        if (File.Exists(fileName))
        {
            if (new FileInfo(fileName).Length != 0)
            {
                string jsonString = File.ReadAllText(fileName);
                list = JsonSerializer.Deserialize<List<T>>(jsonString);
            }
            else
            {
                Console.WriteLine("Specified path file is empty");
            }
        }
    }

    public void OutputJsonContents()
    {
        string jsonString = File.ReadAllText(fileName);

        Console.WriteLine(jsonString);
    }

    public void OutputSerializedList(List<T> list)
    {
        Console.WriteLine(JsonSerializer.Serialize(list, options));
    }
}



class Program
{
    static void Main(string[] args)
    {
        List<Organizations> OrganizationsList = new List<Organizations>();

        JsonHandler<Organizations> partsHandler = new JsonHandler<Organizations>("Organizations.json");

        OrganizationsList.Add(new Organizations(1, "Pyatorochka", "89209654114", 1, new Order(1, 1, 1, 1, 1, 1, "89404147447", "fefeff@gmail.com",2)));
        OrganizationsList.Add(new Organizations(2, "Magnit", "89105254114", 2, new Order(2, 2, 2, 2, 2, 2, "89502544123", "rrg@gmail.com", 1)));
        OrganizationsList.Add(new Organizations(3, "Perekryostok", "89208456556", 3, new Order(3, 3, 3, 3, 3, 3, "89501455474", "ff@gmail.com", 2)));
        OrganizationsList.Add(new Organizations(4, "Diksi", "89155144556", 4, new Order(4, 4, 4, 4, 4, 4, "89602587414", "ss@gmail.com", 1)));
        partsHandler.Rewrite(OrganizationsList);
        partsHandler.OutputJsonContents();
    }
}