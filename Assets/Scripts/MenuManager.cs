using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager MenuInstance;
    public string playerName;
    public int hiscore;
    public InputField inputField;
    private void Awake()
    {
        if (MenuInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        MenuInstance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    public void SetPlayerName()
    {
        playerName = inputField.text;
        SceneManager.LoadScene(1);
    }
    [System.Serializable]
    class BestScore
    {
        public int bestScore;
    }
    public int LoadHiScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestScore data = JsonUtility.FromJson<BestScore>(json);

            hiscore = data.bestScore;
            
        }
        return hiscore;

    }
    public void SetHiScore()
    {
        BestScore data = new BestScore();
        data.bestScore = hiscore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    /*private void Start()
    {
        playerName.text = inputField.text;
    }
    public void StartNew()
    {
        //MainManager.MenuInstance.SaveColor();
        SceneManager.LoadScene(1);
    }*/

}
