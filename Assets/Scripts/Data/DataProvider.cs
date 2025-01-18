using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

namespace Orion.Data
{
    public class DataProvider : MonoBehaviour
    {
        private const string Key = "rXg95xJ9jzVfY1Z9XVG5xr7MZkcnWx5Gk4u5PfZgI10=";

        public static void SavePlayerData(PlayerData data)
        {
            string jsonData = JsonConvert.SerializeObject(data);

            string encryptedData = Encrypt(jsonData, Key);

            File.WriteAllText(Application.persistentDataPath + "/data.enc", encryptedData);
        }

        public static void RemovePlayerData()
        {
            if (File.Exists(Application.persistentDataPath + "/data.enc"))
                File.Delete(Application.persistentDataPath + "/data.enc");
        }

        public static PlayerData LoadPlayerData()
        {
            PlayerData playerData;
            if (File.Exists(Application.persistentDataPath + "/data.enc"))
            {
                string loadedEncryptedData = File.ReadAllText(Application.persistentDataPath + "/data.enc");
                string decryptedData = Decrypt(loadedEncryptedData, Key);

                playerData = JsonConvert.DeserializeObject<PlayerData>(decryptedData);
            }
            else
            {
                playerData = null;
            }

            return playerData;
        }

        public static string Encrypt(string plainText, string key)
        {
            using (Aes aes = Aes.Create())
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(key);
                Array.Resize(ref keyBytes, 16);
                aes.Key = keyBytes;

                aes.GenerateIV();
                byte[] iv = aes.IV;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(iv, 0, iv.Length);

                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(cs))
                        {
                            writer.Write(plainText);
                        }
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText, string key)
        {
            byte[] fullCipher = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(key);
                Array.Resize(ref keyBytes, 16);
                aes.Key = keyBytes;

                byte[] iv = new byte[16];
                Array.Copy(fullCipher, iv, iv.Length);
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(fullCipher, iv.Length, fullCipher.Length - iv.Length))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cs))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}