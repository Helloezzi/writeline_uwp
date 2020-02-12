using System;
using System.Collections.Generic;
using System.IO;
using Windows.Storage;

public class WriteLine
{
    private StorageFolder FolderPath = ApplicationData.Current.LocalCacheFolder;

    public async void WriteLog(string str)
    {
        string fileName = "file.txt";
        string filePath = FolderPath.Path + "/" + fileName;

        var listofstrings = new List<string> { str, };
        if (File.Exists(filePath) == false)
        {
            StorageFile file = await FolderPath.CreateFileAsync(fileName,
                CreationCollisionOption.OpenIfExists);
            await FileIO.WriteLinesAsync(file, listofstrings, Windows.Storage.Streams.UnicodeEncoding.Utf16BE);
        }
        else
        {
            StorageFile file = await FolderPath.GetFileAsync(fileName);
            await FileIO.AppendLinesAsync(file, listofstrings, Windows.Storage.Streams.UnicodeEncoding.Utf16BE);
        }
    }
}


