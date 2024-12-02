namespace Helpers
{
    public class FileHelpers()
    {
        public StreamReader GetFileStream(string path)
        {
            StreamReader? result = null;

            try 
            {
                StreamReader sr = new StreamReader(path);
                result = sr;
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex.Message);
            }
            return result!;
        }
    }
}