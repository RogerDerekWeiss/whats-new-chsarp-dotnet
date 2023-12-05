namespace SharedProject
{
  public static class FileHelper
  {
      public static string GetFileSize(string filePath)
      {
          var fileInfo = new FileInfo(filePath);
          return fileInfo.Length / 1024 + " KB";
      }

      public static string ReadFileContents(string filePath)
      {
          return File.ReadAllText(filePath);
      }
  }
}