namespace AssetFinder
{
    class Program
    {

        private static string CONCATENATED_FILE_NAME = "AllFiles.txt";
        private static string INCLUDING_TEXT = ".txt";
        private static string NOT_INCLUDING_TEXT = CONCATENATED_FILE_NAME;

        /// <summary>
        /// Lists contents of all txt files in a folder 
        /// according to their file names
        /// to help with searching
        /// </summary>
        /// <param name="args">
        /// arg 0 : Path folder
        /// 
        /// </param>
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("ERROR: Specify path");
                return;
            }

            string filePath = args[0];

            var allFiles =
                FileUtils.GetAllNonEmptyFilesInFolderWith(filePath, INCLUDING_TEXT, NOT_INCLUDING_TEXT);
            string concatenatedFilePath = $"{filePath}\\{CONCATENATED_FILE_NAME}";
            
            // Check if file already exists. If yes, delete it.     
            if (FileUtils.Exists(concatenatedFilePath))
            {
                File.Delete(concatenatedFilePath);
                Console.WriteLine("Existing File Deleted");
            }

            using StreamWriter sw = File.AppendText(concatenatedFilePath);

            foreach (var file in allFiles)
            {
                string heading = $"\n\n-----{file.Name}-----\n\n";
                
                sw.Write(heading);

                var content = FileUtils.GetAllLinesInFile(file.FullName);
                foreach (var line in content)
                {
                    sw.Write($"{line}\n");
                }
            }
            sw.Close();
        }
    }
}
