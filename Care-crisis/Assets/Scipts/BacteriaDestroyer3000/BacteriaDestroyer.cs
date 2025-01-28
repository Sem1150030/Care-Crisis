using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class BacteriaDestroyer : MonoBehaviour
{

    [Header("UI Elements")]
    public TMP_Text scoreText;
    public GameObject bacterias;
    public int Buffer = 3;
    public int AmountLeft;

    private void Update()
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
        }
    }
}
