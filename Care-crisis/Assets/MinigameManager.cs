using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager Instance; // Singleton om minigames overal aan te roepen
    public int totalPatients = 0; 
    public int patientsCompleted = 0;
    public Victory victory;
    
    
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
    }

    public void StartMinigame(string minigameName)
    {
        Debug.Log($"Start minigame: {minigameName}");
        // Hier kun je een scene laden of een overlay tonen
        switch (minigameName)
        {
            case "ReactionTest":
                // Start de Reaction Test minigame
                ReactionTest.Instance.StartGame();
                break;
            case "MemoryMatch":
                // Start de Memory Match minigame
                // MemoryMatch.Instance.StartGame();
                break;
            default:
                Debug.LogError($"Onbekende minigame: {minigameName}");
                break;
        }
    }

    public void MinigameCompleted(bool success)
    {
        if (success)
        {
            Debug.Log("Minigame voltooid!");
            patientsCompleted++;
            if (patientsCompleted >= totalPatients)
            {
                Debug.Log("Alle patiënten zijn behandeld!");
                victory.Setup(10);
                
            }
            Debug.Log("current healed patients: " + patientsCompleted);
        }
        else
        {
            Debug.Log("Minigame mislukt!");
        }
    }
}
