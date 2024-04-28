using RAM_Injection_Data.Model;

namespace RAM_Injection_Data.Controller
{
    public class File_Manager
    {
        public delegate void MaxProgressMethodInvoker(int amount);
        public event MaxProgressMethodInvoker MP;

        public File_Manager() 
        {

        }

        public byte[] OpenFile(string path)
        {
            return File.ReadAllBytes(path);
        }

        public void WriteFile(string path, byte[] inputFile)
        {
            File.WriteAllBytes(path, inputFile);
        }

        public void LoadData(string path, Applicaton_Values obj)
        {
            byte[] inputFile;

            inputFile = OpenFile(path);
            obj.FileData = inputFile;

            //MP(inputFile.Length);
        }

        public void LoadDataImport(string path, Applicaton_Values obj)
        {
            byte[] inputFile;

            inputFile = OpenFile(path);
            obj.ImportData = inputFile;
        }
    }
}
