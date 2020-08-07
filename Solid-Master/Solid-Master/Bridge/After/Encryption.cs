using System;

namespace Solid_Master.Bridge.After
{
    internal abstract class EncryptionContentType
    {
        public EncryptionAlgo algo = EncryptionAlgoUtil.DesAlgo;

        internal virtual EncryptionAlgo Algo
        {
            get => algo;
            set => algo = value;
        }

        internal virtual void Encrypt()
        {
            algo.Invoke();
        }
    }

    internal class ImageContent : EncryptionContentType
    {
        internal override void Encrypt()
        {
            base.Encrypt();
            Console.WriteLine("Encrypting Image");
        }
    }

    internal class TextContent : EncryptionContentType
    {
        internal override void Encrypt()
        {
            base.Encrypt();
            Console.WriteLine("Encrypting Text");
        }
    }

    internal delegate void EncryptionAlgo();

    internal class EncryptionAlgoUtil
    {
        public static readonly EncryptionAlgo DesAlgo = () => Console.WriteLine("DES algo");
        public static readonly EncryptionAlgo AesAlgo = () => Console.WriteLine("AES algo");
        public static readonly EncryptionAlgo TdesAlgo = () => Console.WriteLine("TDES algo");
    }

    internal class EncryptionMain
    {
        public static void Main(string[] args)
        {
            EncryptionContentType contentType = new TextContent();
            contentType.Encrypt();
            contentType.Algo = EncryptionAlgoUtil.TdesAlgo;
            contentType.Encrypt();
        }
    }
}