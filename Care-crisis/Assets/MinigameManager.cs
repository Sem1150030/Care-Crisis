using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager Instance; // Singleton om minigames overal aan te roepen
    public int totalPatients = 0;
    public int patientsCompleted = 0;
    public Victory victory;
    public Text patientCounterText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ResetPatientsCompleted();
        AssignVictoryObject();
    }

    public void ResetPatientsCompleted()
    {
        patientsCompleted = 0;
    }

    private void Update()
    {
        patientCounterText.text = $"{patientsCompleted}/{totalPatients}";
    }

    public void StartMinigame(string minigameName)
    {
        Debug.Log($"Start minigame: {minigameName}");

        switch (minigameName)
        {
            case "ReactionTest":
                if (ReactionTest.Instance != null)
                {
                    ReactionTest.Instance.StartGame();
                }
                else
                {
                    Debug.LogError("ReactionTest instance is not initialized!");
                }
                break;
            case "SurgeryGame":
                if (SurgeryScript.Instance != null)
                {
                    SurgeryScript.Instance.StartGame();
                }
                else
                {
                    Debug.LogError("SurgeryScript instance is not initialized!");
                }
                break;
            default:
                Debug.LogError($"Unknown minigame: {minigameName}");
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
                if (victory != null)
                {
                    victory.Setup(10);
                }
                else
                {
                    Debug.LogError("Victory object is not assigned or has been destroyed!");
                }
            }
            Debug.Log("current healed patients: " + patientsCompleted);
        }
        else
        {
            Debug.Log("Minigame mislukt!");
        }
    }

    private void AssignVictoryObject()
    {
        if (victory == null)
        {
            victory = Object.FindFirstObjectByType<Victory>();
            if (victory != null)
            {
                if (victory.transform.parent != null)
                {
                    victory.transform.SetParent(null); // Detach from parent to make it a root GameObject
                }
                DontDestroyOnLoad(victory.gameObject);
            }
            else
            {
                Debug.LogError("Victory object not found in the scene!");
            }
        }
    }
}