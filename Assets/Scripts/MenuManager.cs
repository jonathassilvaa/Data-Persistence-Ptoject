using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI bestScoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Application.dataPath);
        LoadName();
        BestScore();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit()
#endif
        gameManager.Instance.SaveData();
    }

   public void SaveName()
    {
        gameManager.playerName = inputField.text;
        gameManager.Instance.SaveData();
    }
    

   public void BestScore()
    {
        bestScoreTxt.SetText("Best Score:" + gameManager.bestScore);
    }
   public void LoadName()
    {
        gameManager.Instance.LoadData();
        nameText.SetText("Name:" + gameManager.playerName);
        Debug.Log(gameManager.playerName);
    }
}
