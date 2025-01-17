using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Victory : MonoBehaviour
{
    public string restart;
    public string nextLevel;
    
    public void Setup(int score){
        gameObject.SetActive(true);
        //pointText.text = score.ToString() + " POINTS";
    }
    
    public void restartButton()
    {
        MinigameManager.Instance.ResetPatientsCompleted();

        SceneManager.LoadScene(restart);
        
    }
    
    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}