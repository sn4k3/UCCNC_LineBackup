using System;
using System.IO;
using System.Text;

namespace Plugins
{
    public sealed class BackupManager : IDisposable
    {
        /// <summary>
        /// Maximum backup files
        /// </summary>
        public const byte MaxFiles = 2;

        /// <summary>
        /// Gets the backup frequency time in milliseconds (ms)
        /// </summary>
        public const ushort BackupFrequencyMs = 1000;

        /// <summary>
        /// Folder to save backups
        /// </summary>
        public const string Folder = "Contents\\LineBackupPlugin";

        /// <summary>
        /// Backup filename
        /// </summary>
        public const string Filename = "LineBackup";

        /// <summary>
        /// Backup file extension
        /// </summary>
        public const string FileExtension = "txt";

        /// <summary>
        /// Cache of the files
        /// </summary>
        private readonly FileStream[] _fileStreams = new FileStream[MaxFiles];

        /// <summary>
        /// Current backup file being used
        /// </summary>
        private byte _currentFileIndex;

        public BackupManager()
        {
        }

        public static string GetFilePath(byte index)
        {
            return $"{Path.Combine(Folder, $"{Filename}{index}.{FileExtension}")}";
        }

        public static BackupData ReadBackup()
        {
            var backupData = new BackupData();
            var tempBackupData = new BackupData();
            for (byte i = 0; i < MaxFiles; i++)
            {
                var file = GetFilePath(i);
                if (!File.Exists(file)) continue;
                var content = File.ReadAllText(file);
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
            for (byte i = 0; i < _fileStreams.Length; i++)
            {
                if (!ReferenceEquals(_fileStreams[i], null)) continue;
                _fileStreams[i] = File.Open(GetFilePath(i), FileMode.Create, FileAccess.Write);
            }
        }

        public void Close()
        {
            for (var i = 0; i < MaxFiles; i++)
            {
                if (_fileStreams[i] is null) continue;

                try
                {
                    _fileStreams[i].Close();
                    _fileStreams[i].Dispose();
                    _fileStreams[i] = null;
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        public static void DeleteBackups()
        {
            var di = new DirectoryInfo(Folder);

            foreach (var file in di.GetFiles())
            {
                if (!file.Name.StartsWith(Filename)) continue;
                file.Delete();
            }
        }

        public void Write(BackupData data)
        {
            Write(data.GetStringToFileWrite());
        }

        private void Write(string content)
        {
            if(_fileStreams[_currentFileIndex] is null) return;

            try
            {
                _fileStreams[_currentFileIndex].SetLength(0);
                var bytes = Encoding.UTF8.GetBytes(content);
                _fileStreams[_currentFileIndex].Write(bytes, 0, bytes.Length);
                _fileStreams[_currentFileIndex].Flush(true);

                _currentFileIndex++;
                if (_currentFileIndex >= MaxFiles)
                    _currentFileIndex = 0;
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
