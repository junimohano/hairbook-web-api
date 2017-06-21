﻿using System.Security.Cryptography;

namespace HairbookWebApi.Auth
{
    public class RsaKeyHelper
    {
        public static RSAParameters GenerateKey()
        {
            using (var key = new RSACryptoServiceProvider(2048))
            {
                return key.ExportParameters(true);
            }
        }
    }
}
