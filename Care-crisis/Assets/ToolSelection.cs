using System;
using UnityEngine;
using UnityEngine.UI;

public class ToolSelection : MonoBehaviour
{
    public Image band_aid;
    public Image desinfectant;
    
    public string selectedTool;
    
    void Start()
    {
        selectedTool = "band_aid";
    }
    
    public void SelectBandAid()
    {
        selectedTool = "band_aid";
        band_aid.color = Color.green;
        desinfectant.color = Color.white;
    }
    
    public void SelectDesinfectant()
    {
        selectedTool = "desinfectant";
        band_aid.color = Color.white;
        desinfectant.color = Color.green;
    }

    
}
