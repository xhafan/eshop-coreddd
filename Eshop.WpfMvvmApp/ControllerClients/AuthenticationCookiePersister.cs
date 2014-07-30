using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using CoreWebApiClient;

namespace Eshop.WpfMvvmApp.ControllerClients
{
    // todo: move this to CoreMvvm library as a default persister?
    public class AuthenticationCookiePersister : IAuthenticationCookiePersister // todo: save cookie asynchronously in one thread - two threads might compete when writing the file
    {
        private static readonly string CurrentDomainFriendlyName = AppDomain.CurrentDomain.FriendlyName.Replace(" ", ".").Replace("vshost.", "");
        private static readonly string AppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), CurrentDomainFriendlyName);
        internal static readonly string PersistentCookiePath = Path.Combine(AppDataPath, "persistent.cookie");

        static AuthenticationCookiePersister()
        {
            if (!Directory.Exists(AppDataPath))
            {
                Directory.CreateDirectory(AppDataPath);
            }
        }

        public Cookie GetPersistentAuthenticationCookie()
        {
            if (!File.Exists(PersistentCookiePath)) return null;

            try
            {
                using (var fileStream = File.OpenRead(PersistentCookiePath))
                {
                    var formatter = new BinaryFormatter();
                    return (Cookie)formatter.Deserialize(fileStream);
                }
            }
            catch
            {
                File.Delete(PersistentCookiePath);
                return null;
            }
        }

        public void SetPersistentAuthenticationCookie(Cookie cookie)
        {
            if (cookie == null) return;

            using (var fileStream = File.Create(PersistentCookiePath))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, cookie);
            }
        }
    }
}