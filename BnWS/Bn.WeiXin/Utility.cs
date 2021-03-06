﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bn.WeiXin
{
    public static class Utility
    {
        public static Guid Generate()
        {
            var buffer = Guid.NewGuid().ToByteArray();

            var time = new DateTime(0x76c, 1, 1);
            var now = DateTime.Now;
            var span = new TimeSpan(now.Ticks - time.Ticks);
            var timeOfDay = now.TimeOfDay;

            var bytes = BitConverter.GetBytes(span.Days);
            var array = BitConverter.GetBytes(
                (long)(timeOfDay.TotalMilliseconds / 3.333333));

            Array.Reverse(bytes);
            Array.Reverse(array);
            Array.Copy(bytes, bytes.Length - 2, buffer, buffer.Length - 6, 2);
            Array.Copy(array, array.Length - 4, buffer, buffer.Length - 4, 4);

            return new Guid(buffer);
        }

        public static string Signature(string raw, string hashAlgorithm = "SHA1")
        {
            var arrString = string.Join("", raw);
            byte[] sha1Arr;
            if (hashAlgorithm == "SHA1")
            {
                var sha1 = System.Security.Cryptography.SHA1.Create();
                sha1Arr = sha1.ComputeHash(Encoding.UTF8.GetBytes(arrString));
            }
            else
            {//md5

                sha1Arr = System.Security.Cryptography.MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(arrString));
            }
            var sb = new StringBuilder();
            foreach (var b in sha1Arr)
            {
                sb.AppendFormat("{0:x2}", b);
            }
            return sb.ToString();
        }
        public static string Serialize<T>(T t)
        {
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xz = new XmlSerializer(t.GetType());
                xz.Serialize(sw, t);
                return sw.ToString();
            }

        }

        public static string GetTimeSpan()
        {
            return (DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1))).TotalSeconds.ToString();
        }

        public static string GenerateNonceStr()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
