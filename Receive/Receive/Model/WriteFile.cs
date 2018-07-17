using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receive.Model
{
    class WriteFile
    {
        public int Size { get; set; }
        public string Name { get; set; }
        private readonly FileStream fs;

        public WriteFile(string fileName,int size)
        {
            Name = fileName;
            Size = size;
            fs = new FileStream(Name, FileMode.OpenOrCreate,
                FileAccess.Write);
        }

        public void WriteData(byte[] data,int receivedBytes)
        {
            fs.Write(data, 0, receivedBytes);
        }

        public void Close()
        {
            fs.Close();
        }

    }
}
