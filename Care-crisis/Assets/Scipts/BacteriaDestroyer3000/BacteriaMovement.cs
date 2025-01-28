using UnityEngine;
using UnityEngine.UI;

public class BacteriaMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float fallSpeed = 100f;

    [Header("Destruction Settings")]
    public float destroyThreshold = -100f;
    public BacteriaDestroyer destroyer;

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            Debug.LogError("This script requires a RectTransform component!");
        }

        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnImageClicked);
        }
        else
        {
            Debug.LogError("This GameObject needs a Button component to detect clicks.");
        }
    }
    void Update()
    {
        if (destroyer != null && destroyer.gameStarted)
        {
            if (rectTransform != null)
            {
                rectTransform.anchoredPosition -= new Vector2(0, fallSpeed * Time.deltaTime);

                if (rectTransform.anchoredPosition.y < destroyThreshold)
                {
                    destroyer.Buffer--;
                    Destroy(gameObject);
                }
            }
        }
    }

    void OnImageClicked()
    {
        destroyer.AmountLeft--;
        Destroy(gameObject);
    }
}
