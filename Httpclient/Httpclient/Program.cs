using Httpclient;

string url = "https://jsonplaceholder.typicode.com/todos";
HttpClient client = new HttpClient();
HttpResponseMessage cevap = await client.GetAsync(url);


////string ile okuma///
//string icerik = await cevap.Content.ReadAsStringAsync();
//Console.WriteLine(icerik);
//Console.ReadKey();

List<Todo> todos = await cevap.Content.ReadFromJsonAsync<List<Todo>>();

foreach (var item in todos.Take(20))
{
    Console.WriteLine($"Id:{item.Id}Title:{item.Title}");
}


url = "https://jsonplaceholder.typicode.com/posts";

CreatePost yeni = new CreatePost()
{
    UserId = 77,
    Title="Bugün pazartesi",
    Body="Hava açýk ve güneþli",

};

cevap = await client.PostAsJsonAsync(url, yeni);
Post olusan = await cevap.Content.ReadFromJsonAsync<Post>();

Console.WriteLine("Sunucuda oluþan yazýmýz:");
Console.WriteLine("Id:"+olusan.Id);
Console.WriteLine("Kullanýcý Id:" + olusan.UserId);
Console.WriteLine("Baslýk:" + olusan.Title);
Console.WriteLine("Govde:" + olusan.Body);




Console.ReadKey();