using System.Web;
using Microsoft.VisualBasic.CompilerServices;

var poczatke = "https://pxvdeveundocupload.blob.core.windows.net/";
var stringURL = "tstbn-335e9e22-36c9-43f9-9b70-77ebdebc5fb1-upload/143f9692-6172-4788-8a5a-e2747e22cca6-%23$%^&()_+{}-=[];,..pdf?skoid=6026dd03-933c-487d-8594-a87bf3acb47a&sktid=66b904a2-2bfc-4d24-a410-96b77b32bf77&skt=2023-01-13T18%3A33%3A08Z&ske=2023-01-13T19%3A34%3A08Z&sks=b&skv=2021-08-06&sv=2021-10-04&st=2023-01-13T18%3A33%3A08Z&se=2023-01-13T19%3A34%3A08Z&sr=b&sp=r&sig=YCiBdGjSP%2B8yfHuJxS6C9G1ivwXKGeg8EtlPnUhuauE%3D";

var builder = Uri.EscapeDataString(stringURL);

var c = new Uri(poczatke+builder);

var s = 50;


IEnumerable<string> collection = new List<string>();

var implicitType = new { A = 5, C = 2 };

Console.WriteLine(typeof(int));

var ccc = typeof(IWalkable);

Console.WriteLine(ccc);

var a = 21.ToString();





interface IWalkable
{
    void Walk();
}

class Pet : IWalkable
{
    public string Name { get; set; }
    public void Walk()
    {
        throw new NotImplementedException();
    }
}


Task<string> DoSomeLongAction()
{
    return new Task<string>(() =>
    {
        Task.Delay(1500);
        Console.WriteLine("FROM LONG ACTION");
        return "abc";
    });
} 