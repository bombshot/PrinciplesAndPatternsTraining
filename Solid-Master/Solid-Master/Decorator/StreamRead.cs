using System;
using System.IO;

namespace Solid_Master.Decorator
{
    public static class StreamRead
    {
        public static void Main(string[] args)
        {
            StreamReaderExample();
        }

        public static void StreamReaderExample()
        {
            using (var streamReader =
                new StreamReader(
                    new BufferedStream(
                        new FileStream(
                            "Read.cs",
                            FileMode.Open, FileAccess.Read))))
            {
                Console.WriteLine(streamReader.ReadToEnd());
            }
            Console.ReadLine();
        }
    }
}