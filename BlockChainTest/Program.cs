using BlockChainTest.Classes;
using Newtonsoft.Json;
using System;

namespace BlockChainTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Blockchain phillyCoin = new Blockchain();
            phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:Quentin,receiver:Marie,amount:10}"));
            phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:Marie,receiver:Quentin,amount:5}"));
            phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:Marie,receiver:Quentin,amount:5}"));

            Console.WriteLine(JsonConvert.SerializeObject(phillyCoin, Formatting.Indented));

            Console.WriteLine($"Is Chain Valid: {phillyCoin.IsValid()}");

            Console.WriteLine($"Update the entire chain");
            phillyCoin.Chain[2].PreviousHash = phillyCoin.Chain[1].Hash;
            phillyCoin.Chain[2].Hash = phillyCoin.Chain[2].CalculateHash();
            phillyCoin.Chain[3].PreviousHash = phillyCoin.Chain[2].Hash;
            phillyCoin.Chain[3].Hash = phillyCoin.Chain[3].CalculateHash();

            Console.WriteLine($"Is Chain Valid: {phillyCoin.IsValid()}");
        }
    }
}
