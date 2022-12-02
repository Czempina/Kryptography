using Block;
using Common;
using ConsoleApp2;

List<int> key = new List<int>();
List<int> message = new List<int>();
Tests tests = new Tests();
BBS bbs = new BBS(7, 31);
int blockLength = 8;
ConsoleColor consoleColor = ConsoleColor.Green;

while (true)
{
    Console.Clear();
    Console.WriteLine("\n");
    //Console.WriteLine("__________________________________________________________________________________");
    Console.WriteLine("1 - Wygeneruj ciag BBS\t\t\t\t2 - Przetestuj ciag BBS\n3 - Szyfrowanie/Odszyfrowanie strumieniowe\t4 - Szyfrowanie/Odszyfrowanie EBC\n5 - Szyfrowanie/Odszyfrowanie CBC\t\t6 - Szyfrowanie/Odszyfrowanie PBC");
    var des = Console.ReadLine();

    if (des.Trim() == "1")
    {
        key = bbs.generateBits(1000000);
        CommonMethods.SaveToFile(key, "tests");
        Console.ReadKey();
    }
    else if (des.Trim() == "2")
    {
        CommonMethods.ReadFile("tests");
        Console.WriteLine(tests.SingleBit(key));
        Console.WriteLine(tests.Series(key));
        Console.WriteLine(tests.LongSeries(key));
        Console.WriteLine(tests.Poker(key));
        Console.ReadKey();
    }
    else if (des.Trim() == "3")
    {
        key = bbs.generateBits(30);
        message = bbs.generateBits(30);
        var codedBits = CommonMethods.SzyfrStrumieniowy(key, message);
        var decodedBits = CommonMethods.SzyfrStrumieniowy(key, codedBits);

        CommonMethods.SaveToFile(key, "key");
        CommonMethods.SaveToFile(message, "message");
        CommonMethods.SaveToFile(codedBits, "result");
        CommonMethods.SaveToFile(decodedBits, "decodedMessage");

        //Console.WriteLine();
        //Console.WriteLine(tests.SingleBit(codedBits));
        //Console.WriteLine(tests.Series(codedBits));
        //Console.WriteLine(tests.LongSeries(codedBits));
        //Console.WriteLine(tests.Poker(codedBits));
        Console.ReadKey();
    }
    else if (des.Trim() == "4")
    {
        key = bbs.generateBits(30);
        message = bbs.generateBits(30);
        key = CommonBlock.FillWithO(key, blockLength);
        message = CommonBlock.FillWithO(message, blockLength);

        var codedBits = ECB.Code(key, message, blockLength);
        var decodedBits = ECB.Code(key, codedBits, blockLength);

        CommonMethods.SaveToFile(key, "key");
        CommonMethods.SaveToFile(message, "message");
        CommonMethods.SaveToFile(codedBits, "result");
        CommonMethods.SaveToFile(decodedBits, "decodedMessage");

        //Console.WriteLine();
        //Console.WriteLine(tests.SingleBit(codedBits));
        //Console.WriteLine(tests.Series(codedBits));
        //Console.WriteLine(tests.LongSeries(codedBits));
        //Console.WriteLine(tests.Poker(codedBits));
        Console.ReadKey();
    }
    else if (des.Trim() == "5")
    {
        key = bbs.generateBits(30);
        message = bbs.generateBits(30);
        key = CommonBlock.FillWithO(key, blockLength);
        message = CommonBlock.FillWithO(message, blockLength);

        var codedBits = CBC.Code(key, message, blockLength);
        var decodedBits = CBC.Decode(key, codedBits, blockLength);

        CommonMethods.SaveToFile(key, "key");
        CommonMethods.SaveToFile(message, "message");
        CommonMethods.SaveToFile(codedBits, "result");
        CommonMethods.SaveToFile(decodedBits, "decodedMessage");

        //Console.WriteLine();
        //Console.WriteLine(tests.SingleBit(codedBits));
        //Console.WriteLine(tests.Series(codedBits));
        //Console.WriteLine(tests.LongSeries(codedBits));
        //Console.WriteLine(tests.Poker(codedBits));
        Console.ReadKey();
    }
    else if (des.Trim() == "6")
    {
        key = bbs.generateBits(30);
        message = bbs.generateBits(30);
        key = CommonBlock.FillWithO(key, blockLength);
        message = CommonBlock.FillWithO(message, blockLength);

        var codedBits = PBC.Code(key, message, blockLength);
        var decodedBits = PBC.Decode(key, codedBits, blockLength);

        CommonMethods.SaveToFile(key, "key");
        CommonMethods.SaveToFile(message, "message");
        CommonMethods.SaveToFile(codedBits, "result");
        CommonMethods.SaveToFile(decodedBits, "decodedMessage");

        //Console.WriteLine();
        //Console.WriteLine(tests.SingleBit(codedBits));
        //Console.WriteLine(tests.Series(codedBits));
        //Console.WriteLine(tests.LongSeries(codedBits));
        //Console.WriteLine(tests.Poker(codedBits));
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("Nie ma takiej komendy!");
        Console.ReadKey();
    }
}