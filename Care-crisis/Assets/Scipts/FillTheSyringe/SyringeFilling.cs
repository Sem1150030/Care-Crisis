using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SyringeFilling : Minigame
{
    public RectTransform imageRectTransform;
    public Image image;
    public bool started = false;
    public GameObject UI;
    public static SyringeFilling Instance;
    public PatientScript assignedPatient; 

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

    private void Update()
    {
        if (started)
        {
            if (imageRectTransform.sizeDelta.y > 90 && imageRectTransform.sizeDelta.y < 100)
            {
                image.color = Color.green;
            } 
            else
            {
                image.color = Color.red;
            }
            Debug.Log(imageRectTransform.sizeDelta.y);
        } 
        
    }

    public void CompleteSyringe()
    {
        if (image.color == Color.green)
        {
            Debug.Log("Player succes!");
            EndGame(true);
        }
        else
        {
            Debug.Log("Player failed");
        }
    }

    public void MakeTallerFromTop(float amount)
    {
        imageRectTransform.sizeDelta = new Vector2(imageRectTransform.sizeDelta.x, imageRectTransform.sizeDelta.y + amount);

        imageRectTransform.anchoredPosition += new Vector2(0, amount / 2);
    }

    public void MakeShorterFromTop(float amount)
    {
        imageRectTransform.sizeDelta = new Vector2(imageRectTransform.sizeDelta.x, imageRectTransform.sizeDelta.y - amount);

        imageRectTransform.anchoredPosition -= new Vector2(0, amount / 2);
    }

    public override void StartGame(string gameName)
    {
        started = true;
        UI.SetActive(true);
    }

    public override void EndGame(bool success)
    {
        UI.SetActive(false);
        assignedPatient.CompleteHealing(true); 
        minigameManager.MinigameCompleted(true);
    }
}
