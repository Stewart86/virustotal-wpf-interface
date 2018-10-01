using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CustodioUIApp
{
    public class Helper
    {
        public static string ConvertByteToString(byte[] Sha256)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (byte b in Sha256)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }

            return stringBuilder.ToString();
        }

        public static byte[] GetHashSha256(string filename)
        {
            SHA256 Sha256 = SHA256.Create();

            using (FileStream stream = File.OpenRead(filename))
            {
                stream.Position = 0;
                return Sha256.ComputeHash(stream);
            }
        }
    }
}