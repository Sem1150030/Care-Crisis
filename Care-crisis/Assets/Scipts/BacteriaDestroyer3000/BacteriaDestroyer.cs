using DefaultNamespace;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class BacteriaDestroyer : Minigame
{

    [Header("UI Elements")]
    public TMP_Text scoreText;
    public GameObject bacterias;
    public int Buffer = 3;
    public int AmountLeft;
    public bool gameStarted = false;
    public GameObject ScorePanel;
    
    public static BacteriaDestroyer Instance;
    
    public MinigameManager minigameManager;
    public PatientScript assignedPatient; 


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (minigameManager == null)
        {
            minigameManager = MinigameManager.Instance;
        }
    }

    private void Update()
    {
        if (gameStarted)
        {
            AmountLeft = bacterias.transform.childCount;
            scoreText.text = "Amount left:" + AmountLeft;

            if (Buffer <= 0)
            {
                foreach (Transform child in bacterias.transform)
                {
                    Destroy(child.gameObject);
                }
                scoreText.text = "You lost";
            }

            if (AmountLeft == 0 && Buffer > 0)
            {
                scoreText.text = "You won! Enough bacteria was defeated";
                EndGame(true);
            }
        }
        
        
    }

    public override void StartGame(string gameName)
    {
        gameStarted = true;
        ScorePanel.SetActive(true);
        
    }

    public override void EndGame(bool success)
    {
        ScorePanel.SetActive(false);
        gameStarted = false;
        minigameManager.MinigameCompleted(true);
        assignedPatient.CompleteHealing(true);
    }
}
