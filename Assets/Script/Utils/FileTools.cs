using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileTools : Singleton<FileTools>
{

    public void CreateFile(string path,byte[] data,int length)
    {
        Stream sw;
        FileInfo f = new FileInfo(path);
        if (!f.Exists)
        {
            sw = f.Create();
        }
        else
        {
            return;
        }
        sw.Write(data, 0, length);
        sw.Close();
        sw.Dispose();
    }

}
