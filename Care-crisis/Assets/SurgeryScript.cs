using UnityEngine;
using UnityEngine.UI;

public class SurgeryScript : MonoBehaviour
{
    public ToolSelection toolSelection; // Reference to the ToolSelection script

    private string tool;

    // Counters for tracking wounds and viruses
    private int remainingWounds;
    private int remainingViruses;

    void Start()
    {
        // Initialize counters
        remainingWounds = GameObject.FindGameObjectsWithTag("Wound").Length;
        remainingViruses = GameObject.FindGameObjectsWithTag("Virus").Length;

        Debug.Log($"Starting game: {remainingWounds} wounds and {remainingViruses} viruses.");
    }

    void Update()
    {
        // Update the selected tool
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
        // Activate the band-aid image
        Transform bandAidImage = wound.transform.Find("band-aidimg");
        Transform woundImage = wound.transform.Find("WoundImg");

        if (bandAidImage != null) bandAidImage.gameObject.SetActive(true); // Show band-aid
        if (woundImage != null) woundImage.gameObject.SetActive(false);   // Hide wound

        // Optional: Disable further interaction with the wound
        Button button = wound.GetComponent<Button>();
        if (button != null) button.interactable = false;

        // Change the tag to indicate it's healed
        wound.tag = "Healed";
        Debug.Log("Wounds remaining: " + --remainingWounds);
    }


    private void RemoveVirus(GameObject virus)
    {
        // Destroy or disable the virus
        Destroy(virus);

        // Decrement remaining viruses and check game status
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
    }
}
