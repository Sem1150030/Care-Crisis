using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    
    public string restart;
    public string nextLevel;
    public Text pointText;
    
    
    public void Setup(int score){
        gameObject.SetActive(true);
        //pointText.text = score.ToString() + " POINTS";
    }

    public void restartButton()
    {
        Debug.Log("Restarting");
        SceneManager.LoadScene(restart);
        gameObject.SetActive(false);
        
    }

    public void exitButton()
    {
        
    }
}