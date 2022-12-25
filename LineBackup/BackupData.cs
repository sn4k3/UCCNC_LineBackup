using System;
using System.IO;

namespace Plugins
{
    public sealed class BackupData
    {
        /// <summary>
        /// Gets or sets the current line
        /// </summary>
        public uint CurrentLine { get; set; }

        /// <summary>
        /// Gets or sets the current time
        /// </summary>
        public string CurrentTime { get; set; }

        /// <summary>
        /// Gets or sets the current loaded job file
        /// </summary>
        public string LoadedFile { get; set; }

        /// <summary>
        /// Gets the path separator chars
        /// </summary>
        public static readonly string[] PathSeparatorChars = {"\r\n", "\r", "\n"};

        /// <summary>
        /// Loads a backup from a string
        /// </summary>
        /// <param name="content"></param>
        public void LoadFromString(string content)
        {
            if (string.IsNullOrWhiteSpace(content)) return;

            var contents = content.Split(PathSeparatorChars, StringSplitOptions.RemoveEmptyEntries);

            if (contents.Length >= 1)
            {
                if (uint.TryParse(contents[0], out var uintContent))
                {
                    CurrentLine = uintContent;
                }
            }

            if (contents.Length >= 2) CurrentTime = contents[1].Trim();
            if (contents.Length >= 3) LoadedFile = contents[2].Trim();
        }

        /// <summary>
        /// Gets the backup string to write to file
        /// </summary>
        /// <returns></returns>
        public string GetStringToFileWrite()
        {
            return $"{CurrentLine}{Environment.NewLine}{CurrentTime}{Environment.NewLine}{LoadedFile}";
        }

        /// <summary>
        /// Backup string representation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"GCode Line: {CurrentLine}\n" +
                   $"Working Time: {CurrentTime}\n" +
                   $"File: {string.Join($"\n    {Path.DirectorySeparatorChar}", LoadedFile.Split(new []{ Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries))}";
        }
    }
}
