using Server.Data;
using System;
using System.Collections.Concurrent;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace Exercise_1_simple_web_server
{
    class StartUp
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            const string NewLine = "\r\n";

            TcpListener tcpListener = new TcpListener(
                IPAddress.Loopback, 80);
            tcpListener.Start();

            using var connection = new SqlConnection("Server=.;Database=DapperDB;Trusted_Connection=True");

            connection.Open();

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                using (var stream = client.GetStream())
                {
                    byte[] buffer = new byte[1000000];
                    var lenght = stream.Read(buffer, 0, buffer.Length);

                    string requestString =
                        Encoding.UTF8.GetString(buffer, 0, lenght);
                    Console.WriteLine(requestString);

                    var currentPage = "There's no page in the URL";
                    var parsedURL = requestString.Split(" HTTP")[0].Split("/");
                    if (parsedURL.Length>1) //meaining there's a page added
                    {
                        currentPage = parsedURL[1];
                    }
                    Console.WriteLine(currentPage);

                    if (currentPage == "login")
                    {
                        var parametersArray = requestString.Split("\r\n\r\n")[1].Split("&");
                        var username = parametersArray[0].Split("=")[1];
                        var password = parametersArray[1].Split("=")[1];

                        Console.WriteLine($"username = {username}, password = {password}");

                        string htmlPost = $"<h1>{DapperDb.Login(connection, username, password)}</h1>";

                        string responsePost = "HTTP/1.1 200 OK" + NewLine +
                            "Server: NikiServer 2020" + NewLine +
                            // "Location: https://www.google.com" + NewLine +
                            "Content-Type: text/html; charset=utf-8" + NewLine +
                            // "Content-Disposition: attachment; filename=niki.txt" + NewLine +
                            "Content-Lenght: " + htmlPost.Length + NewLine +
                            NewLine +
                            htmlPost + NewLine;

                        byte[] responseBytesPost = Encoding.UTF8.GetBytes(responsePost);
                        stream.Write(responseBytesPost);

                        Console.WriteLine(new string('=', 70));

                        continue;
                    }

                    if (currentPage == "register")
                    {
                        string htmlPost = $"<h1>Congratulations, you have successfully registered as new user</h1>";

                        string responsePost = "HTTP/1.1 200 OK" + NewLine +
                            "Server: NikiServer 2020" + NewLine +
                            // "Location: https://www.google.com" + NewLine +
                            "Content-Type: text/html; charset=utf-8" + NewLine +
                            // "Content-Disposition: attachment; filename=niki.txt" + NewLine +
                            "Content-Lenght: " + htmlPost.Length + NewLine +
                            NewLine +
                            htmlPost + NewLine;

                        byte[] responseBytesPost = Encoding.UTF8.GetBytes(responsePost);
                        stream.Write(responseBytesPost);

                        Console.WriteLine(new string('=', 70));

                        continue;
                    }

                    string html = $"<h1>Hello from NikiServer {DateTime.Now}</h1>" +
                        $"<h3>Please login</h3>" +
                        $"<form action=/login method=post><input name=username /><input name=password />" +
                        $"<input type=submit /></form>" +
                        $"<h3>Or please register if you don't have an account</h3>" +
                        $"<form action=/register method=post><input name=username /><input name=password />" +
                        $"<input type=submit /></form>";

                    string response = "HTTP/1.1 200 OK" + NewLine +
                        "Server: NikiServer 2020" + NewLine +
                        // "Location: https://www.google.com" + NewLine +
                        "Content-Type: text/html; charset=utf-8" + NewLine +
                        // "Content-Disposition: attachment; filename=niki.txt" + NewLine +
                        "Content-Lenght: " + html.Length + NewLine +
                        NewLine +
                        html + NewLine;

                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes);

                    Console.WriteLine(new string('=', 70));
                }
            }
        }

        public static async Task ReadData()
        {
            string url = "https://softuni.bg/courses/csharp-web-basics";
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine,
                response.Headers.Select(x => x.Key + ": " + x.Value.First())));

            // var html = await httpClient.GetStringAsync(url);
            // Console.WriteLine(html);
        }
    }
}