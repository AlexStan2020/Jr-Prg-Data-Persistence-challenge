using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HighScoreManager : MonoBehaviour
{
   
    public static HighScoreManager instance;

    public int highScore;
    public string highScoreName;
    public string currentName;

    string fileName;

    public void Awake()
    {
        if (instance !=null)
        {
            Destroy(gameObject);
            return;
        }

        fileName = Application.persistentDataPath + "/data.json";

        instance = this;
        instance.GetInfo();
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class Savedata
    {
        public int highScore;
        public string highScoreName;
     }

    public void SaveInfo()
    {
        Savedata saveData = new Savedata();

        saveData.highScore = instance.highScore;
        saveData.highScoreName = instance.highScoreName;

        string data = JsonUtility.ToJson(saveData);
        System.IO.File.WriteAllText(fileName, data);
    }

    public void GetInfo()
    {
        if (File.Exists(fileName))
        {
            string data = System.IO.File.ReadAllText(fileName);
            Savedata saveData = JsonUtility.FromJson<Savedata>(data);

            instance.highScore = saveData.highScore;
            instance.highScoreName = saveData.highScoreName;
        }
    }

}
