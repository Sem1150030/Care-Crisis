using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager Instance; // Singleton om minigames overal aan te roepen

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
            // Geef feedback aan de patiënt
        }
        else
        {
            Debug.Log("Minigame mislukt!");
        }
    }
}
