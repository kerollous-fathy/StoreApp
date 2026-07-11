using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class FileHelper
    {
        private static readonly Encoding Utf8NoBom = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

        public static async Task Create(string path, string content)
        {
            var full = Normalize(path);
            EnsureDirectory(full);
            await File.WriteAllTextAsync(full, content ?? string.Empty, Utf8NoBom);
        }

        public static bool TryCreate(string path, string content)
        {
            try { Create(path, content); return true; }
            catch { content = null; return false; }
        }

        public static async Task Append(string path, string text, bool addNewLine = false)
        {
            var full = Normalize(path);
            EnsureDirectory(full);
            var payload = addNewLine ? (text ?? string.Empty) + Environment.NewLine : (text ?? string.Empty);
            await File.AppendAllTextAsync(full, payload, Utf8NoBom);
        }

        public static async Task Update(string path, string text, bool addNewLine = false)
        {
            var full = Normalize(path);
            EnsureDirectory(full);
            var payload = addNewLine ? (text ?? string.Empty) + Environment.NewLine : (text ?? string.Empty);
            await File.WriteAllTextAsync(full, payload, Utf8NoBom);
        }

        public static async Task<string> ReadAll(string path)
        {
            var full = Normalize(path);
            if (!File.Exists(full))
            {
                EnsureDirectory(full);
                await File.WriteAllTextAsync(full, string.Empty, Utf8NoBom);
                return string.Empty;
            }
            return await File.ReadAllTextAsync(full, Utf8NoBom);
        }

        public static async Task<string[]> ReadAllLines(string path)
        {
            var full = Normalize(path);
            if (!File.Exists(full))
            {
                EnsureDirectory(full);
                await File.WriteAllTextAsync(full, string.Empty, Utf8NoBom);
                return new string[1];
            }
            return await File.ReadAllLinesAsync(full, Utf8NoBom);
        }

        public static async Task<(bool success, string? content)> TryReadAll(string path)
        {
            try
            {
                var content = await ReadAll(path);
                return (true, content);
            }
            catch
            {
                return (false, string.Empty);
            }
        }

        public static bool Delete(string path)
        {
            var full = Normalize(path);
            if (!File.Exists(full))
                return false;
            File.Delete(full);
            return true;
        }

        private static string Normalize(string path) =>
            Path.GetFullPath(path ?? throw new ArgumentException(nameof(path)));

        private static void EnsureDirectory(string fullfilepath)
        {
            var dir = Path.GetDirectoryName(fullfilepath);
            if (!string.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);
        }

        
    }
}
