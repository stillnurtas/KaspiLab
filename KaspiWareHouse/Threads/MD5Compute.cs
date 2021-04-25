using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KaspiWareHouse
{
    public class MD5Compute
    {
        static async Task MD5Hash(int count, string text)
        {
            byte[] hash;

            for (var i = 1; i <= count; i++)
            {
                await Task.Run(() => {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    var md5 = MD5.Create(text);
                    hash = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
                    stopWatch.Stop();
                    var computedTime = stopWatch.Elapsed;
                    Console.WriteLine($"Task{i} computed time: {computedTime}");
                });
            }

            Task.WaitAll();
        }


    }
}
