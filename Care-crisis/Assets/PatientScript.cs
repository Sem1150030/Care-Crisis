using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class PatientScript : MonoBehaviour
{
    public float maxTime = 30f;
    private float remainingTime;
    public Text timerText;
    private bool isHealed = false;
    private bool isBeingHealed = false;
    public Minigame assignedMinigame; // Verwijzing naar de gekoppelde minigame
    public GameOver gameOver;
    public PlayerScript playerScript;
    void Start()
    {
        remainingTime = maxTime;
        UpdateTimerUI();
    }

    void Update()
    {
        if (isHealed)
        {
            timerText.text = "Genezen!";
        }
        
        if (!isBeingHealed && !isHealed) 
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerUI();

            if (remainingTime <= 0)
            {
                OnDeath();
            }
        }
    }

    public void StartHealing()
    {
        if (assignedMinigame != null)
        {
            isBeingHealed = true;
            Debug.Log($"{gameObject.name} wordt nu genezen!");
            assignedMinigame.StartGame(); 
        }
        else
        {
            Debug.LogWarning($"{gameObject.name} heeft geen minigame toegewezen!");
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = Mathf.Ceil(remainingTime).ToString();
        }
    }

    void OnDeath()
    {
        Debug.Log($"{gameObject.name} is overleden.");
        Destroy(gameObject);
        if (gameOver != null)
        {
            gameOver.Setup(10);
        }

        if (playerScript)
        {
            playerScript.moveSpeed = 0;

        }
    }

    public void CompleteHealing(bool success)
    {
        if (success)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = Color.green; // Zet de patiënt groen bij succesvolle genezing
            }

            Debug.Log($"{gameObject.name} is genezen!");
            isBeingHealed = false;
            isHealed = true;
            CircleCollider2D collider = GetComponent<CircleCollider2D>();
            if (collider != null)
            {
                Destroy(collider); // Verwijder de collider
            }
        }
        else
        {
            Debug.Log($"{gameObject.name} kon niet worden genezen.");
            
        }
    }
}