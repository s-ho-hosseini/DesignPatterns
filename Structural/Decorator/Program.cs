using System;

namespace Decorator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StoreCreditCard(new CompressedCloudStream(new CloudStream()));
        }

        public static void StoreCreditCard(Stream stream)
        {
            stream.Write("laksd0lkklak-asdasd");
        }
    }

    public class CloudStream : Stream
    {
        public virtual void Write(string data)
        {
            Console.WriteLine($"Stroing {data}");
        }
    }

    public class EncryptCloudStream : Stream
    {
        private Stream _stream;

        public EncryptCloudStream(Stream stream)
        {
            _stream = stream;
        }

        public void Write(String data)
        {
            var newData = Encrypt(data);
            _stream.Write(newData);
        }

        private string Encrypt(string data)
        {
            return "!@#*()$@#(**(()Q)*#^@*";
        }
    }

    public class CompressedCloudStream : Stream
    {
        private Stream _stream;

        public CompressedCloudStream(Stream stream)
        {
            _stream = stream;
        }

        public void Write(string data)
        {
            var compressed = Compress(data);
            _stream.Write(compressed);
        }

        private string Compress(string data)
        {
            return data[..5];
        }
    }

    public class CompressedAndEncryptedCloudStream : CloudStream
    {
    }


    public interface Stream
    {
        void Write(string data);
    }
}