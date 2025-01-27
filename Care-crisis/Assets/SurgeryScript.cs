using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class SurgeryScript : Minigame
{
    public ToolSelection toolSelection; 

    private string tool;

    
    private int remainingWounds;
    private int remainingViruses;
    public PatientScript assignedPatient; 
    public GameObject SurgeryPanel;
    public bool finished = false;
    public static SurgeryScript Instance; 

    public MinigameManager minigameManager;

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

    void Update()
    {
        if (toolSelection != null)
        {
            tool = toolSelection.selectedTool;
        }
    }

    public void Heal(Button targetButton)
    {
        GameObject target = targetButton.gameObject;

        if (tool == "band_aid" && target.CompareTag("Wound"))
        {
            Debug.Log("Wound healed with band aid");
            HealWound(target);
        }
        else if (tool == "desinfectant" && target.CompareTag("Virus"))
        {
            Debug.Log("Virus removed with disinfectant");
            RemoveVirus(target);
        }
        else
        {
            Debug.Log("Incorrect tool for the selected target");
        }
    }

    private void HealWound(GameObject wound)
    {
        
        Transform bandAidImage = wound.transform.Find("band-aidimg");
        Transform woundImage = wound.transform.Find("WoundImg");

        if (bandAidImage != null) bandAidImage.gameObject.SetActive(true); // Show band-aid
        if (woundImage != null) woundImage.gameObject.SetActive(false);   // Hide wound

        
        Button button = wound.GetComponent<Button>();
        if (button != null) button.interactable = false;

       
        wound.tag = "Healed";
        Debug.Log("Wounds remaining: " + --remainingWounds);
    }


    private void RemoveVirus(GameObject virus)
    {
        
        Destroy(virus);

        
        remainingViruses--;
        CheckGameStatus();
    }

    private void CheckGameStatus()
    {
        if (remainingWounds == 0 && remainingViruses == 0)
        {
            MinigameFinished();
        }
    }

    private void MinigameFinished()
    {
        Debug.Log("Minigame finished! All wounds healed and viruses removed.");
        EndGame(true);
    }

    public override void StartGame(string gameName)
    {
        if (assignedPatient == null)
        {
            Debug.LogError("assignedPatient is not assigned!");
            return;
        }
        else
        {
            SurgeryPanel.SetActive(true);
            
            remainingWounds = GameObject.FindGameObjectsWithTag("Wound").Length;
            remainingViruses = GameObject.FindGameObjectsWithTag("Virus").Length;

            Debug.Log($"Starting game: {remainingWounds} wounds and {remainingViruses} viruses.");
        }
        
    }

    public override void EndGame(bool success)
    {
        if (success)
        {
            Debug.Log("game voltooid. Succes!");
            assignedPatient.CompleteHealing(true); // Patiënt is genezen
            SurgeryPanel.SetActive(false);
            // isButtonVisible = false;
            finished = true;
            minigameManager.MinigameCompleted(true);
        }
        

        // Verberg de knop en stop de game
        
    }
}
