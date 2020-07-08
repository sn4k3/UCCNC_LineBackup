using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Plugins
{
    public sealed class BackupManager : IDisposable
    {
        public const byte MaxFiles = 2;
        public const string Folder = "Contents\\LineBackupPlugin";
        public const string Filename = "LineBackup";
        public const string FileExtension = "txt";
        private FileStream[] Files { get; } = new FileStream[MaxFiles];
        private byte CurrentFileIndex { get; set; }

        public BackupManager()
        {
        }

        public static string GetFilePath(byte index)
        {
            return $"{Folder}{Path.DirectorySeparatorChar}{Filename}{index}.{FileExtension}";
        }

        public static BackupData ReadBackup()
        {
            BackupData backupData = new BackupData();
            BackupData tempBackupData = new BackupData();
            for (byte i = 0; i < MaxFiles; i++)
            {
                string file = GetFilePath(i);
                if (!File.Exists(file)) continue;
                string content = File.ReadAllText(file);
                if(string.IsNullOrWhiteSpace(content))  continue;
                
                tempBackupData.LoadFromString(content);
                if(tempBackupData.CurrentLine == 0) continue;
                if (tempBackupData.CurrentLine > backupData.CurrentLine)
                {
                    backupData = tempBackupData;
                }
            }

            return backupData;
        }

        public void Init()
        {
            Directory.CreateDirectory(Folder);
            DeleteBackups();
            for (byte i = 0; i < Files.Length; i++)
            {
                if (!ReferenceEquals(Files[i], null))
                {
                    continue;
                }

                Files[i] = File.Open(GetFilePath(i), FileMode.Create, FileAccess.Write);
            }
        }

        public void Close()
        {
            for (var i = 0; i < MaxFiles; i++)
            {
                if (ReferenceEquals(Files[i], null))
                {
                    continue;
                }

                try
                {
                    Files[i].Close();
                    Files[i].Dispose();
                    Files[i] = null;
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        public static void DeleteBackups()
        {
            DirectoryInfo di = new DirectoryInfo(Folder);

            foreach (FileInfo file in di.GetFiles())
            {
                if (!file.Name.StartsWith(Filename)) continue;
                file.Delete();
            }
        }

        public void Write(string content)
        {
            if(ReferenceEquals(Files[CurrentFileIndex], null)) return;

            try
            {
                Files[CurrentFileIndex].SetLength(0);
                byte[] bytes = Encoding.ASCII.GetBytes(content);
                Files[CurrentFileIndex].Write(bytes, 0, bytes.Length);
                Files[CurrentFileIndex].Flush(true);

                CurrentFileIndex++;
                if (CurrentFileIndex >= MaxFiles)
                    CurrentFileIndex = 0;
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public void Dispose()
        {
            Close();
        }
    }
}
