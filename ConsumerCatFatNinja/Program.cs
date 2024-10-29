using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using static System.Console;

namespace ConsumerCatFatNinja
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = $"https://catfact.ninja/fact";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    WriteLine("Iniciando...");
                    HttpResponseMessage response = await client.GetAsync(url);

                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    JObject json = JObject.Parse(responseBody);

                    WriteLine($"Daily fact: {json["fact"]} String lenght: {json["length"]}");

                }
                catch (HttpRequestException e)
                {
                    WriteLine("Erro na requisição: " + e.Message);
                }
                catch (Exception ex)
                {
                    // Exibe a mensagem completa da exceção para facilitar a depuração
                    WriteLine("Erro: " + ex.ToString());
                }
            }
            ReadKey();
        }
    }
}