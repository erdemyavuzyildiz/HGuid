using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Shared_16092018_0434_53
{
    /// <summary>
    /// HGuidGenerator
    /// </summary>
    public static class HGuidGenerator
    {
        public static string NewHGuid()
        {
            var sw =Stopwatch.StartNew();
            var rand = new Random(DateTimeOffset.UtcNow.Ticks.GetHashCode());
            var randomNumber = rand.Next(000000000, 999999999);

            var proccessId = Process.GetCurrentProcess().Id;
            var machineName = Environment.MachineName;
            var hash=ComputeSha256Hash(proccessId+machineName+randomNumber+sw.ElapsedTicks);


            return
                $"{Guid.NewGuid()}{hash}{Guid.NewGuid().ToString()}"
                    .Replace("-", "");
        }

        static string ComputeSha256Hash(string rawData)  
        {  
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())  
            {  
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));  
  
                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();  
                for (int i = 0; i < bytes.Length; i++)  
                {  
                    builder.Append(bytes[i].ToString("x2"));  
                }  
                return builder.ToString();  
            }  
        }  
    }
}