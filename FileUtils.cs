
public class FileUtils
{
    
    public static string[] GetAllLinesInFile(string path)
    {
        string[] allLinesInFile = File.ReadAllLines(path);

        return allLinesInFile;
    }

    public static List<FileInfo> GetAllNonEmptyFilesInFolderWith(string path, string including, string notIncluding = "-1")
    {
            
        DirectoryInfo d = new DirectoryInfo(path); //Assuming Test is your Folder

        FileInfo[] files;
        try
        {
            files = d.GetFiles(); //Getting Text files
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
            
        List<FileInfo> listOfFiles = files.Where(file => file.Length > 0).ToList();
        listOfFiles = listOfFiles.Where(file => file.Name.Contains(including) && !file.Name.Contains(notIncluding)).ToList();
        return listOfFiles;
    }

    public static bool Exists(string filePath)
    {
        return File.Exists(filePath);
    }
}