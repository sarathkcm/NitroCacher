using NitroCacher.Models;
using Fiddler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Drawing;

namespace NitroCacher
{
    static class Utils
    {
        public static bool DoesUrlMatch(string url, FilterRule filterRule)
        {
            switch (filterRule.MatchType)
            {
                case MatchType.ExactUrl:
                    return url.Equals(filterRule.Criteria, StringComparison.OrdinalIgnoreCase);
                case MatchType.HostName:
                    return new Uri($"http://{url}").Host.Equals(filterRule.Criteria, StringComparison.OrdinalIgnoreCase);
                case MatchType.PartialUrl:
                    if (string.IsNullOrWhiteSpace(filterRule.Criteria))
                        return false;
                    return url.ToLower().Contains(filterRule.Criteria.ToLower());
                case MatchType.Regex:
                    return new Regex(filterRule.Criteria).IsMatch(url);
                default:
                    return false;
            }
        }

        public static string GetHashFromRequest(Session oSession, FilterRule filterRule)
        {
            var headersToIgnore = filterRule.HeadersToIgnore ?? new List<string>();
            var headers = oSession.RequestHeaders.Where(h => !headersToIgnore.Contains(h.Name)).Select(h => new Header(h.Name, h.Value)).ToList();
            var request = new HttpRequest(headers, oSession.url, oSession.RequestMethod, oSession.RequestBody);
            var serializedRequest = XmlSerialize(request);
            return ComputeSha256Hash(serializedRequest);
        }

        static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string XmlSerialize<T>(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var sw = new StringWriter())
            {
                serializer.Serialize(sw, obj);
                return sw.ToString();
            }
        }

        public static T XmlDeSerialize<T>(string xml) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var sw = new StringReader(xml))
            {
                return serializer.Deserialize(sw) as T;
            }
        }

        public static Image ToImage(this string base64)
        {
            {
                byte[] bytes = Convert.FromBase64String(base64);

                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    return Image.FromStream(ms);
                }

            }
        }
    }
}
