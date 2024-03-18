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
    Title="Bug�n pazartesi",
    Body="Hava a��k ve g�ne�li",

};

cevap = await client.PostAsJsonAsync(url, yeni);
Post olusan = await cevap.Content.ReadFromJsonAsync<Post>();

Console.WriteLine("Sunucuda olu�an yaz�m�z:");
Console.WriteLine("Id:"+olusan.Id);
Console.WriteLine("Kullan�c� Id:" + olusan.UserId);
Console.WriteLine("Basl�k:" + olusan.Title);
Console.WriteLine("Govde:" + olusan.Body);




Console.ReadKey();