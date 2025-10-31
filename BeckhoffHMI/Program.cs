using System;
using TwinCAT.Ads;

class Program
{
    static void Main()
    {
        using (AdsClient adsClient = new AdsClient())
        {
            try
            {
                adsClient.Connect("127.0.0.1.1.1", 851);
                Console.WriteLine("✅ Connected to Beckhoff PLC!");

                uint handle = adsClient.CreateVariableHandle("MAIN.iCounter");
                uint counter = (uint)adsClient.ReadAny(handle, typeof(uint));
                Console.WriteLine($"PLC Counter: {counter}");
                adsClient.DeleteVariableHandle(handle);
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Connection error: " + ex.Message);
            }
        }
    }
}