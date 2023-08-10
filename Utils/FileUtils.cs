namespace CsharpChallenges.Utils
{
    internal class FileUtils
    {
        public FileUtils()
        {
        }

        internal static string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        internal static void WriteFile(string filePath, string text)
        {
            File.WriteAllText(filePath, text);
        }
    }
}
