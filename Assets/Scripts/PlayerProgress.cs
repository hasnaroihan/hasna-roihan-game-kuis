using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.Collections;
using System.IO.Enumeration;
using Unity.VisualScripting;

[CreateAssetMenu(
    fileName = "Player Progress Baru",
    menuName = "Game Kuis/Player Progress")]
public class PlayerProgress : ScriptableObject
{
    [System.Serializable]
    public struct MainData
    {
        public int koin;
        public Dictionary<string, int> progresLevel;
    }

    [SerializeField] private string _startingLevelPackName = string.Empty;
    [SerializeField] private string filename;

    public MainData progresData = new MainData();

#if UNITY_EDITOR
    string directoryPath = Application.dataPath + "/Temporary/";
#elif (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
    string directoryPath = Application.persistentDataPath + "/LocalProgress/";
#endif

    public void SimpanProgres()
    {
        string fullPath = directoryPath + filename;

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
            Debug.Log("Direktori " + directoryPath + " telah dibuat");
        }

        if (!File.Exists(fullPath)) {
            File.Create(fullPath).Dispose();
            Debug.Log("Data telah dibuat di: " + fullPath);
        }

        // Sampel data
        //progresData.koin = 200;
        //if (progresData.progresLevel == null)
        //{
        //    progresData.progresLevel = new();
        //}
        //progresData.progresLevel.Add("Level Pack 1", 3);
        //progresData.progresLevel.Add("Level Pack 3", 5);

        if (progresData.progresLevel == null)
        {
            progresData.progresLevel = new()
            {
                { _startingLevelPackName, 0 }
            };
            progresData.koin = 0;
        }

        // Menulis data ke file teks
        //string teksProgress = "";
        //foreach (var i in  progresData.progresLevel)
        //{
        //    Debug.Log(i.Value);
        //    teksProgress = teksProgress + i.Key + "-" + i.Value + ";";
        //}

        //string kontenData = $"{progresData.koin}\n{teksProgress}";
        //File.WriteAllText(fullPath, kontenData);
        //Debug.Log("Data disimpan di: " + fullPath);

        // Menyimpan data ke file biner
        var fileStream = File.Open(fullPath, FileMode.Open);
        fileStream.Flush();

        // Binary formatter
        var formatter = new BinaryFormatter();
        formatter.Serialize(fileStream, progresData);

        // Binary writer
        //var writer = new BinaryWriter(fileStream);
        //writer.Write(progresData.koin);
        //foreach (var i in progresData.progresLevel)
        //{
        //    writer.Write(i.Key);
        //    writer.Write(i.Value);
        //}

        //writer.Dispose();

        fileStream.Dispose();
        Debug.Log("Data berhasil diperbarui");
    }

    public bool MuatProgres()
    {
        string fullPath = directoryPath + filename;
        FileStream fileStream = null;
        //BinaryReader reader = null;


        // Binary formatter
        try
        {

            var formatter = new BinaryFormatter();
            fileStream = File.Open(fullPath, FileMode.Open);

            progresData = (MainData)formatter.Deserialize(fileStream);

            fileStream.Dispose();

            Debug.Log("Berhasil memuat data");

            return true;
        }
        catch (System.Exception e)
        {
            Debug.Log($"ERROR: Terjadi kesalahan memuat progres\n{e.Message}");
            //fileStream.Dispose();
            return false;
        }
        finally
        {
            if (fileStream != null)
            {
                fileStream.Dispose();
            }
        }

        // Binary reader
        //try
        //{
        //    fileStream = File.Open(fullPath, FileMode.Open);
        //    reader = new BinaryReader(fileStream);

        // NOTES: Untuk menentukan EOF di sini pakai perbandingan posisi stream dengan panjang stream, karena PeekChar menghasilkan exception buffer decoding
        //    if (reader.BaseStream.Position < reader.BaseStream.Length)
        //    {
        //        Debug.Log("tes");
        //        progresData.koin = reader.ReadInt32();
        //        Debug.Log(progresData.koin);
        //    }

        //    if (progresData.progresLevel == null)
        //    {
        //        progresData.progresLevel = new();
        //    }

        //    while (reader.BaseStream.Position < reader.BaseStream.Length)
        //    {
        //        var key = reader.ReadString();
        //        var value = reader.ReadInt32();
        //        progresData.progresLevel.Add(key, value);
        //        Debug.Log($"{key}:{value}");
        //    }

        //    reader.Dispose();
        //    fileStream.Dispose();

        //    //Debug.Log($"{progresData.koin}; {progresData.progresLevel.Count}");

        //    return true;
        //}
        //catch (System.Exception e)
        //{
        //    Debug.Log($"ERROR: Terjadi kesalahan memuat progres\n{e.Message}");

        //    return false;
        //}
        //finally
        //{
        //    if (fileStream != null)
        //    {
        //        fileStream.Dispose();
        //    }
        //    if (reader != null)
        //    {
        //        reader.Dispose();
        //    }
        //}
    }
}
