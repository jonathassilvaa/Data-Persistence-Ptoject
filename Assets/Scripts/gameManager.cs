using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static gameManager Instance;
    public static string playerName;
    public static int bestScore;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }
    [System.Serializable]
    class Savedata
    {
        public string name;
        public int score;
    }

    public void SaveData()
    {
        Savedata data = new Savedata();
        data.name = playerName;
        data.score = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Savedata data = JsonUtility.FromJson<Savedata>(json);

            playerName = data.name;
            bestScore = data.score;
        }
    }
}
