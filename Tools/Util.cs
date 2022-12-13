using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using wpfSBIFS.MVVM.Model;

namespace wpfSBIFS.Tools
{
    public class Util
    {
        /// <summary>
        /// it checks for different failed satuscodes and returns the corresponding error message
        /// </summary>
        /// <param name="StatusCode"></param>
        /// <returns> error message </returns>
        

        public static String CheckStatusCode(int StatusCode, int expectedCode)
        {
            if (StatusCode == 401)
            {
                return "Wrong username or password!";
            }
            if (StatusCode == 403)
            {
                return "Access denied!";
            }
            if (StatusCode == 501)
            {
                return "Internal Server Error, please contact administrator!";
            }
            if (StatusCode == 400)
            {
                return "Bad request, please contact administrator!";
            }
            if (StatusCode == 503)
            {
                return "Service unavailable, please try again later!";
            }
            if (StatusCode != expectedCode)
            {
                return "Unknown error" + StatusCode;
            }

            return "";


        }
        public static Boolean CheckUsernamePassword(string username, string password)
        {
            if (username.Equals("") || password.Equals(""))
            {
                return true;
            }
            return false;
        }
        public static async Task<bool> LabelChangeAsync(Label label, string errorString)
        {
            //making the text of the label to the fitting error message
            label.Content = errorString;
            //making the label visible
            label.Foreground = System.Windows.Media.Brushes.Red;
            await Task.Delay(500);
            label.Foreground = System.Windows.Media.Brushes.Black;
            return false;
        }

        /*
         * Generates a random password with the lenght 10 while looping until the lenght is reached then returning the pw
        */
        public static string GeneratePassword()
        {
            int lenght = 10;
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (lenght-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(validChars[(int)(num % (uint)validChars.Length)]);
                }
            }

            return res.ToString();
        }
        public static ServerConnectionAdapter sva;

        /*
        public Util()
        {
            // Create a new HttpClient object.
            HttpClient client = new HttpClient();

            // Initialize the sva object with the host name, port, and HttpClient.
            sva = new ServerConnectionAdapter(hostName, port, client);
        }
        
        */




    }
}
