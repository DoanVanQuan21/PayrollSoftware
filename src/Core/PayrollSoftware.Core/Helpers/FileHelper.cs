using Newtonsoft.Json;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace PayrollSoftware.Core.Helpers
{
    public class FileHelper
    {
        public static T Read<T>(string path, string filename)
        {
            var filepath = Path.Combine(path, filename);
            if (!File.Exists(filepath))
            {
                return Activator.CreateInstance<T>();
            }
            try
            {
                var json = File.ReadAllText(filepath);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception)
            {
                //TODO
                return Activator.CreateInstance<T>();
            }
        }

        public static void Save(string path, string filename, string content)
        {
            var filepath = Path.Combine(path, filename);
            CreateSubDir(path);
            var subDirs = path.Split('\\');
            var root = $"{subDirs[0]}\\";
            if (!Directory.Exists(root))
            {
                path.Replace("D:", "E:");
            }
            if (!File.Exists(filepath))
            {
                using var _ = File.Create(filepath);
            }
            var jsonString = JsonConvert.SerializeObject(content);
            File.WriteAllText(filepath, jsonString);
        }

        public static void Save<T>(string path, string filename, T content)
        {
            var filepath = Path.Combine(path, filename);
            CreateSubDir(path);
            if (!File.Exists(filepath))
            {
                using var _ = File.Create(filepath);
            }

            var jsonString = JsonConvert.SerializeObject(content);
            File.WriteAllText(filepath, jsonString);
        }

        public static void Save<T>(string path, T content)
        {
            var jsonString = JsonConvert.SerializeObject(content);
            CreateSubDir(path);
            DirectoryInfo dir = new(path);
            if (!dir.Exists)
            {
                dir.Create();
            }
            if (!File.Exists(path))
            {
                using var _ = File.Create(path);
            }
            File.WriteAllText(path, jsonString);
        }

        private static void AddAccessRule(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            DirectorySecurity dir = directoryInfo.GetAccessControl();
            dir.SetAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, AccessControlType.Deny));
        }

        private static void CreateSubDir(string path)
        {
            if (Directory.Exists(path))
            {
                return;
            }
            char sperator = default;
            var isSperator = path.Contains("/");
            sperator = isSperator ? '/' : '\\';
            var subDirs = path.Split(sperator);
            var root = $"{subDirs[0]}{sperator}";
            for (int i = 1; i < subDirs.Length; i++)
            {
                root = Path.Combine(root, subDirs[i]);
                if (Directory.Exists(root))
                {
                    continue;
                }
                Directory.CreateDirectory(root);
            }
        }
    }
}