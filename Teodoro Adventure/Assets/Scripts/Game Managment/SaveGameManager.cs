using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveGameManager 
{
    private static string savePath = Application.persistentDataPath + "/player.fun";
    public static void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(savePath, FileMode.Create);

        SaveGameData saveGameData = new SaveGameData();
        formatter.Serialize(fileStream, saveGameData);
        fileStream.Close();
    }

    public static SaveGameData loadSave()
    {
        if (!File.Exists(savePath))
        {
            Debug.LogError("Save file not found");
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(savePath, FileMode.Open);
        SaveGameData saveGameData = formatter.Deserialize(fileStream) as SaveGameData;
        fileStream.Close();
        return saveGameData;

    }
}
