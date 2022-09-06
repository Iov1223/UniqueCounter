using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UniqueCounter
{
    class ID
    {
        private long[] id = new long[10];
        private long count = 0;
        private long[] CreateID()
        {
            for (int i = 0; i < id.Length; i++)
            {
                id[i] = count + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                count++;
            }
            return id;
        }
        private string[] Convert2Str()
        {
            id = CreateID();
            string[] ArrToStr = new string[id.Length];
            for (int i = 0; i < id.Length; i++)
            {
                ArrToStr[i] = id[i].ToString();
            }
            return ArrToStr;
        }
        private void WriteToFile()
        {
            string[] id = Convert2Str();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ID.txt";
            for (int i = 0; i < id.Length; i++)
            {
                File.AppendAllText(path, id[i] + "\n");
            }

        }
        public void ShowID()
        {
            WriteToFile();
            id = CreateID();
            for (int i = 0; i < id.Length; i++)
                Console.WriteLine(id[i]);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ID id = new ID();
            id.ShowID();
        }
    }
}