using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Master.Bridge.Before
{
    public abstract class Encryption
    {
        public abstract void Encrypt();

    }

    public class ImageEncryption : Encryption
    {
        public override void Encrypt()
        {
            Console.WriteLine("Encrypting Image");
        }
    }

    public class TextEncryption : Encryption
    {
        public override void Encrypt()
        {
            Console.WriteLine("Encrypting Text");
        }
    }

    public class ImageAesEncryption : ImageEncryption
    {
        public override void Encrypt()
        {
            Console.WriteLine("AES Algo for Image");
        }
    }

    public class TextDesEncryption : TextEncryption
    {
        public override void Encrypt()
        {
            Console.WriteLine("DES Algo for Text");
        }
    }

    internal class EncryptionMain
    {
        public static void Main(string[] args)
        {
            ImageEncryption imageEncryption = new ImageAesEncryption();
            imageEncryption.Encrypt();

            TextEncryption textEncryption = new TextDesEncryption();
            textEncryption.Encrypt();

            Console.ReadLine();
        }
    }
}
