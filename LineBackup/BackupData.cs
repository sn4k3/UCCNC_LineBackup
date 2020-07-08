using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Plugins
{
    public sealed class BackupData
    {
        public uint CurrentLine { get; set; }
        public string CurrentTime { get; set; }
        public string LoadedFile { get; set; }

        public void LoadFromString(string content)
        {
            if (string.IsNullOrWhiteSpace(content)) return;

            var contents = content.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (contents.Length >= 1)
            {
                if (uint.TryParse(contents[0], out var uintContent))
                {
                    CurrentLine = uintContent;
                }
            }

            if (contents.Length >= 2)
                CurrentTime = contents[1].Trim();
            if (contents.Length >= 3)
                LoadedFile = contents[2].Trim();
        }

        public string GetStringToFileWrite()
        {
            return $"{CurrentLine}{Environment.NewLine}{CurrentTime}{Environment.NewLine}{LoadedFile}";
        }

        public override string ToString()
        {
            return $"GCode Line: {CurrentLine}\nWorking Time: {CurrentTime}\nFile: {string.Join($"\n    {Path.DirectorySeparatorChar}", LoadedFile.Split(new []{ Path.DirectorySeparatorChar }, StringSplitOptions.None))}";
        }
    }
}
