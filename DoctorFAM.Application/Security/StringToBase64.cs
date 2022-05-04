using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Security
{
    public static class HashHelper
    {
        public static string StringToBase64(string value, string merchantKey)
        {
            var byteData = Encoding.UTF8.GetBytes(value);

            var algorithm = SymmetricAlgorithm.Create("TripleDes");

            if (algorithm == null) return string.Empty;

            algorithm.Mode = CipherMode.ECB;
            algorithm.Padding = PaddingMode.PKCS7;

            var encryption = algorithm.CreateEncryptor(Convert.FromBase64String(merchantKey), new byte[8]);

            string signData = Convert.ToBase64String(encryption.TransformFinalBlock(byteData, 0, byteData.Length));

            return signData;
        }
    }
}
