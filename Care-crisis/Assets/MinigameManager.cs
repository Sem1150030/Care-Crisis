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
    public string minigameName;
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

    public void StartMinigame(string miniGameName)
    {
        Debug.Log($"Start minigame: {minigameName}");

        switch (miniGameName)
        {
            case "ReactionTest":
                if (ReactionTest.Instance != null)
                {
                    ReactionTest.Instance.StartGame("d");
                }
                else
                {
                    Debug.LogError("ReactionTest instance is not initialized!");
                }
                break;
            
            case "SyringeFilling":
                if (SyringeFilling.Instance != null)
                {
                    SyringeFilling.Instance.StartGame("d");
                }
                else
                {
                    Debug.LogError("SyringeGame instance is not initialized!");
                }
                break;  
            
            case "TicTacToe":
                if (TicTacToeManager.Instance != null)
                {
                    TicTacToeManager.Instance.StartGame("d");
                }
                else
                {
                    Debug.LogError("TicTacToe instance is not initialized!");
                }
                break;
            case "TicTacToe 2":
                if (TicTacToeManager.Instance != null)
                {
                    TicTacToeManager.Instance.StartGame("dd");
                }
                else
                {
                    Debug.LogError("TicTacToe instance is not initialized!");
                }
                break;
            case "BacteriaDestroyer":
                if (BacteriaDestroyer.Instance != null)
                {
                    BacteriaDestroyer.Instance.StartGame("d");
                    
                }
                else
                {
                    Debug.LogError("BacteriaDestroyer instance is not initialized!");
                }
                break;
            case "BacteriaDestroyer 2":
                if (BacteriaDestroyer.Instance != null)
                {
                    BacteriaDestroyer.Instance.StartGame("dd");

                }
                else
                {
                    Debug.LogError("BacteriaDestroyer instance is not initialized!");
                }
                break;
            case "SurgeryGame":
                if (SurgeryScript.Instance != null)
                {
                    SurgeryScript.Instance.StartGame("d");
                }
                else
                {
                    Debug.LogError("SurgeryScript instance is not initialized!");
                }
                break;
            case "LabGameVitals":
                if (LabGame.Instance != null)
                {
                    LabGame.Instance.StartGame("VitalsGame");
                }
                else
                {
                    Debug.LogError("LabGame instance is not initialized!");
                }
                break;
            case "LabGameMicroscope":
                if (LabGame.Instance != null)
                {
                    LabGame.Instance.StartGame("MicroscopeGame");
                }
                else
                {
                    Debug.LogError("LabGame instance is not initialized!");
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