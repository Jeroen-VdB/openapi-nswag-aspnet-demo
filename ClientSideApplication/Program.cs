using ClientSideApplication.V1;

var httpClient = new HttpClient();
var petClient = new Client(httpClient);

Console.WriteLine("Welcome to the pet store.");
Console.WriteLine("Find pets by status. 0 = Available, 1 = Pending, 2 = Sold, 3 = *Exit*");
Console.WriteLine("Find pets by status:");

var statusInput = Console.ReadLine();

while (statusInput != "3")
{
    var pets = await petClient.FindPetsByStatusAsync((Status)int.Parse(statusInput));

    Console.WriteLine("-----");

    foreach (var pet in pets)
    {
        Console.WriteLine(pet.Name);
    }

    Console.WriteLine("-----");
    Console.WriteLine("Find pets by status:");
    statusInput = Console.ReadLine();
}

