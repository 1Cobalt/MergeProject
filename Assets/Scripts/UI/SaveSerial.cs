using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveSerial : MonoBehaviour
{
    private string SAVE_FOLDER;
    
    void Start()
    {
        SAVE_FOLDER = (Application.persistentDataPath + "/SaveData.dat");
        Debug.Log(SAVE_FOLDER);

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            LoadGame();
        }
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveData.dat");
        SaveScript data = new SaveScript();

        data.bestScore = StaticDataStorage.GetBestScore();
        data.shakeCount = StaticDataStorage.GetShakeCount();
        data.setNumber = StaticDataStorage.GetSetNumber();
        data.musicStatus = StaticDataStorage.GetMusicStatus();
        data.soundStatus = StaticDataStorage.GetSoundStatus();



        bf.Serialize(file, data);
        file.Close();

        Debug.Log("Game data saved!");
    }
    public void LoadGame()
    {
        Debug.Log("Attempt to load data...");
        if (File.Exists(Application.persistentDataPath + "/SaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Open);
            SaveScript data = (SaveScript)bf.Deserialize(file);
            file.Close();

            StaticDataStorage.SetBestScore(data.bestScore);
            StaticDataStorage.SetShakeCount(data.shakeCount);
            StaticDataStorage.SetSetNumber(data.setNumber);
            StaticDataStorage.SetMusicStatus(data.musicStatus);
            StaticDataStorage.SetSoundStatus(data.soundStatus);

        }
        else
        {
            SaveGame();
            Debug.Log("There is no saved data");
        }
    }
}


[Serializable]
class SaveScript
{
    public int bestScore = 0;
    public int shakeCount = 1;

    public int setNumber = 1;

    public bool musicStatus = false;
    public bool soundStatus = false;
}
