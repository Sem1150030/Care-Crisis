using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SyringeFilling : MonoBehaviour
{
    public RectTransform imageRectTransform;
    public Image image;

    private void Update()
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

    public void CompleteSyringe()
    {
        if (image.color == Color.green)
        {
            Debug.Log("Player succes!");
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
}
