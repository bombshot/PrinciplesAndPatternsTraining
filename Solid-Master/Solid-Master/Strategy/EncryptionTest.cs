using System;

namespace Solid_Master.Strategy
{
    internal class EncryptionAlgoUtil
    {
        public static readonly Action DesAlgo = () => Console.WriteLine("DES");
        public static readonly Action AesAlgo = () => Console.WriteLine("AES");
        public static readonly Action TdesAlgo = () => Console.WriteLine("TDES");
    }

    internal class Encryption
    {
        private Action _algo = EncryptionAlgoUtil.DesAlgo;

        public Encryption()
        {
        }

        public Encryption(Action algo)
        {
            _algo = algo;
        }

        public virtual Action EncryptionAlgorithm
        {
            set => _algo = value;
            get => _algo;
        }

        public virtual void Encrypt()
        {
            _algo();
        }
    }


    public class EncryptionTest
    {
        public static void Main(string[] args)
        {
            var e = new Encryption();
            e.Encrypt();
            e.EncryptionAlgorithm = EncryptionAlgoUtil.AesAlgo;
            e.Encrypt();

            Console.ReadLine();
        }
    }
}