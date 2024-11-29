using Dclt.Chatwoot.Client;
using Dclt.DemoConsole;
using Dclt.Directus;
using Dclt.Evolution.Client;
using System.Text.Json;


await TestEvo();
Console.ReadLine();

//var client = new HttpClient();
//client.DefaultRequestHeaders.Add("api_access_token", "aPSosrgHkKSYs6EF4h5xw9mi");
//var result = await client.GetStringAsync("https://omni.dclt.com.br/api/v1/accounts/2/contacts?page=2");
//Console.WriteLine(result);
//Console.ReadLine();
//await TesteChat();
//await TesteUser();
//await TesteQuery();
//await TesteMultipleClients();

async Task TestEvo()
{
    var msg = "*SPED de maio de 2024 foi processado.*";
    msg += "\n\nAs notas fiscais de *01/05* até *31/05/2024* foram processadas, e foram adicionados mais *32* empresas para a base de dados de monitoramento do cliente *DCLT Tecnologia*.";
    msg += "\n\nCaso haja algum *inidôneo* em sua base, em breve iremos avisá-lo.";

    var msg2 = "*Inidôneo encontrado!*";
    msg2 += $"\n\nA empresa *DCL Tecnologia* com o CNPJ *11.111.111/0001-11* e Inscrição Estadual *111.111.111.111* foi encontrada na nossa base de inidôneos.";
    msg2 += $" A situação de *NULA* consta no diário oficial do dia *02/05/2024*.";
    msg2 += "\n\nProcure seu contador ou a Secretaria de Receita Estadual para esclarecimentos sobre as devidas providências.";

    var evo = new EvolutionClient("https://evo.qute.ro", "27AC54D0F288-483C-90F4-98ADC05890DA", "quteai");
    var textMsg = await evo.SendText("1399788-2009", msg2);
    if (textMsg != null)
        Console.WriteLine(textMsg.Status);

    //var mediaMsg = await evo.SendMedia("6981141732", MimeType.ImagePng, "Imagem do Console", "https://academico.mpro.mp.br/assets/a414dde7-1aff-45ef-ac16-e4a0ccf85fe8", "logo.png");
    //if (mediaMsg != null)
    //    Console.WriteLine(mediaMsg.Status);

}

//async Task TesteChat()
//{
//    var chat = new ChatwootClient("https://omni.dclt.com.br", "aPSosrgHkKSYs6EF4h5xw9mi", 2);
//    var result = await chat.GetContactsAsync();
//    if (result != null && result.Data != null)
//    {
//        foreach (var contact in result.Data)
//        {
//            Console.WriteLine($"{contact.Id} - {contact.Name}");
//        }
//    }
//    Console.ReadLine();

//    var resultConv = await chat.GetConversationsAsync();
//    if (resultConv != null && resultConv.Data != null)
//    {
//        foreach (var conv in resultConv.Data)
//        {
//            Console.Write($"{conv.Id} - {conv.Meta?.Sender?.Name} ({conv.Meta?.Sender?.PhoneNumber})");
//            if (conv.Labels != null && conv.Labels.Count() > 0)
//                Console.Write($" : {string.Join(",", conv.Labels)}");
//            Console.WriteLine();
//            if (conv.Messages != null && conv.Messages.Count() > 0)
//            {
//                foreach (var message in conv.Messages)
//                {
//                    Console.WriteLine($" . {message.Id} - {message.ContentType} / {message.MessageType}: {message.Content} ");
//                }
//            }
//        }
//    }
//    Console.ReadLine();

//}

//async Task TesteCache()
//{
   
//    var client = new DirectusClient("https://pme.dclt.com.br", "t-FdgNmL1halTNeWwOISgvkl35Y94QjX");

//    var cache = await client.GetItemAsync<CacheModel<ReadInverterModel>>("cache", 5);
    
//    var read = cache?.Data;

//    var jsonOptions = new JsonSerializerOptions() { WriteIndented = true };

//    var jsonCache = JsonSerializer.Serialize(cache, jsonOptions);
//    var jsonRead = JsonSerializer.Serialize(read, jsonOptions);

//    Console.WriteLine(jsonCache);
//    Console.WriteLine(jsonRead);
//}

//async Task TesteUser()
//{
//    var client = new DirectusClient("https://rovema.dclt.com.br");
//    var user = await client.AuthenticateAndGetUserAsync("liluyoud@rovemaenergia.com.br", "Rovema@123");
//    var jsonUser = JsonSerializer.Serialize(user, new JsonSerializerOptions() { WriteIndented = true });
//    Console.WriteLine(jsonUser);
//    Console.ReadLine();
//}

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

//async Task TesteMultipleClients()
//{
//    var client1 = new DirectusClient("https://rovema.dclt.com.br", "8SyRFwK5bcl1WPPIpOjJS7nprTSNfXUe");

//    var client2 = new DirectusClient("https://rovema.dclt.com.br");


//    var item1 = await client1.GetItemAsync<dynamic>("rpas", 1);
//    Console.WriteLine($"Item 1: {item1}");

//    var item2 = await client2.GetItemAsync<dynamic>("rpas", 1);
//    Console.WriteLine($"Item 2: {item2}");

//    var item3 = await client1.GetItemAsync<dynamic>("rpas", 1);
//    Console.WriteLine($"Item 3: {item3}");

//    Console.WriteLine($"Client 1: {client1.IsAuthenticated}");
//    Console.WriteLine($"Client 2: {client2.IsAuthenticated}");

//    var autenticado = await client2.AuthenticateAsync("admin@dclt.com.br", "Lsmlzlh_2507");
//    if (autenticado)
//    {
//        var item4 = await client2.GetItemAsync<dynamic>("rpas", 1);
//        Console.WriteLine($"Item 4: {item4}");
//        Console.WriteLine($"Client 2: {client2.IsAuthenticated}");
//    }
//    else
//    {
//        Console.WriteLine("Não autenticado");
//    }
//}





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


