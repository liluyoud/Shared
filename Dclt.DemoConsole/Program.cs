using Dclt.Directus;
using Dclt.Shared.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

await TesteUser();
//await TesteQuery();
//await TesteMultipleClients();

async Task TesteUser()
{
    var client = new DirectusClient("https://rovema.dclt.com.br");
    var user = await client.AuthenticateAndGetUserAsync("liluyoud@rovemaenergia.com.br", "Rovema@123");
    var jsonUser = JsonSerializer.Serialize(user, new JsonSerializerOptions() { WriteIndented = true });
    Console.WriteLine(jsonUser);
    Console.ReadLine();
}

//async Task TesteQuery()
//{
//    //var query = new Query()
//    //    .Fields("name,type")
//    //    .Search("buritis")
//    //    .Sort("name")
//    //    .Page(1)
//    //    .Offset(3)
//    //    .Limit(3)
//    //    .Build();

//    var filter1 = new DirectusFilter().Equal("type", "Tempo");
//    var filter2 = new DirectusFilter().Equal("status", "published");
//    var filter = new DirectusFilter().And([filter1,filter2]);
    
//    var query = new Query()
//        .Fields("name,type,settings,date_created")
//        //.FilterAnd([filter1, filter2])
//        //.Filter("name", Operation.Contains, "mac")
//        .Filter("type", Operation.Equal, "Tempo")
//        .Filter("status", Operation.Equal, "published")
//        .Build();
//    Console.WriteLine(query);
//    Console.ReadLine();

//    var client = new DirectusClient("https://rovema.dclt.com.br", "8SyRFwK5bcl1WPPIpOjJS7nprTSNfXUe");
//    var rpas = await client.GetItemsAsync<IEnumerable<RpaModel>>("rpas", query);
    
//    if (rpas != null) {
//        foreach (var rpa in rpas)
//        {
//            Console.WriteLine(" - " + rpa.Name);
//            Console.WriteLine("   " + rpa.Type);
//            Console.WriteLine("   " + rpa.DateCreated);
//            if (rpa.Settings != null) {
//                foreach (var setting in rpa.Settings)
//                    Console.WriteLine($"    .  {setting.Key}: {setting.Value}");
//            }
//        }
//    }
//}

async Task TesteMultipleClients()
{
    var client1 = new DirectusClient("https://rovema.dclt.com.br", "8SyRFwK5bcl1WPPIpOjJS7nprTSNfXUe");

    var client2 = new DirectusClient("https://rovema.dclt.com.br");


    var item1 = await client1.GetItemAsync<dynamic>("rpas", 1);
    Console.WriteLine($"Item 1: {item1}");

    var item2 = await client2.GetItemAsync<dynamic>("rpas", 1);
    Console.WriteLine($"Item 2: {item2}");

    var item3 = await client1.GetItemAsync<dynamic>("rpas", 1);
    Console.WriteLine($"Item 3: {item3}");

    Console.WriteLine($"Client 1: {client1.IsAuthenticated}");
    Console.WriteLine($"Client 2: {client2.IsAuthenticated}");

    var autenticado = await client2.AuthenticateAsync("admin@dclt.com.br", "Lsmlzlh_2507");
    if (autenticado)
    {
        var item4 = await client2.GetItemAsync<dynamic>("rpas", 1);
        Console.WriteLine($"Item 4: {item4}");
        Console.WriteLine($"Client 2: {client2.IsAuthenticated}");
    }
    else
    {
        Console.WriteLine("Não autenticado");
    }
}





//if ()
//{
//    Console.WriteLine("Authenticated successfully!");

//    //// Create an item
//    //var newItem = new { name = "New Item", description = "This is a new item." };
//    //bool created = await client.CreateItemAsync("your-collection", newItem);
//    //Console.WriteLine($"Item created: {created}");

//    // Get an item
//    var item = await client.GetItemAsync<dynamic>("rpas", 1);
//    Console.WriteLine($"Item retrieved: {item}");

//    var rpa = await client.GetItemAsync<RpaModel>("rpas", 1);
//    Console.WriteLine($"Item retrieved: {rpa}");


//    //// Update an item
//    //var updatedItem = new { name = "Updated Item" };
//    //bool updated = await client.UpdateItemAsync("your-collection", 1, updatedItem);
//    //Console.WriteLine($"Item updated: {updated}");

//    // Delete an item
//    //bool deleted = await client.DeleteItemAsync("your-collection", 1);
//    //Console.WriteLine($"Item deleted: {deleted}");


//    var fieldsQuery = client.CreateFieldsQuery("name,type");
//    var filterQuery = client.CreateFilterQuery(new Dictionary<string, object>
//        {
//            { "name", new { _contains = "Mac" } }
//        });
//    var sortQuery = client.CreateSortQuery("-date_created");
//    var limitQuery = client.CreateLimitQuery(10);

//    var queryParams = new Dictionary<string, string>();
//    foreach (var query in new[] { fieldsQuery, filterQuery, sortQuery, limitQuery })
//    {
//        foreach (var param in query)
//        {
//            queryParams[param.Key] = param.Value;
//        }
//    }

//    var items = await client.GetItemsAsync("your_collection", queryParams);
//    Console.WriteLine(items);
//}
//else
//{
//    Console.WriteLine("Failed to authenticate.");
//}

public class RpaModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }

    [JsonPropertyName("date_created")]
    public DateTime? DateCreated { get; set; }

    public List<KeyValue>? Settings { get; set; }
}
