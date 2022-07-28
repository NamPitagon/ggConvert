﻿using GoogleConvert.Models.Share;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GoogleConvert.Models.ConvertDataToArrByte
{
    public class DataToArrByte
    {
        public static byte[] StringToArrByte(string inputValue)
        {
            byte[] bytes = new byte[] { };
            if (string.IsNullOrEmpty(inputValue)) return null;
            else
            {
                string removeChar = inputValue;
                removeChar = Regex.Replace(removeChar, @"[^0-9]", "");
                if (removeChar.All(char.IsNumber) && removeChar != "")
                {
                    inputValue = Regex.Replace(inputValue, @"\s+", " ");
                    string[] arr = inputValue.Split(new Char[] { ' ', '-' });
                    bytes = new byte[arr.Length];
                    for (int i = 0; i < arr.Length; i++)
                        bytes[i] = (byte)int.Parse(arr[i].ToString());
                }
                else bytes = Encoding.UTF8.GetBytes(inputValue);
                return bytes;
            }
        }

        public static byte[] Base64ToArrByte(string inputValue)
        {
            if (string.IsNullOrEmpty(inputValue)) return null;
            else
            {
                if (ShareCodeCheck.IsBase64String(inputValue))
                {
                    return Convert.FromBase64String(inputValue);
                }
                else return null;
            }
        }

        public static byte[] HexToArrByte(string inputValue)
        {
            if (string.IsNullOrEmpty(inputValue)) return null;
            else
            {
                inputValue = Regex.Replace(inputValue, @"\s+|-", "");
                byte[] bytes = new byte[inputValue.Length / 2];
                for (int i = 0; i < bytes.Length; i++)
                    bytes[i] = Convert.ToByte(inputValue.Substring(i * 2, 2), 16);
                return bytes;
            }
        }

        public static string FormatArrByteToString(byte[] bytes)
        {
            if (bytes.Length == 0) return null;
            else
            {
                StringBuilder strBuilder = new StringBuilder();
                foreach (byte b in bytes)
                    strBuilder.Append(b.ToString() + " ");
                return strBuilder.ToString().Trim();
            }
        }
    }
}
