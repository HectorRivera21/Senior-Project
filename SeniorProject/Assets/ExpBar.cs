using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ExpBar : MonoBehaviour
{

    public Slider slider; 
    public Gradient gradient;
    public Image fill;

    public PlayerAttr myPlayer;
    int currentLevel;

    [Header("Interface")]
    [SerializeField] TextMeshProUGUI levelText;

    public void Start(){
        slider.value = 0;
    }

    public void SetMaxExp(int exp)
    {
        slider.maxValue = exp;

        fill.color = gradient.Evaluate(1f);
    }
    
    public void SetExp(int exp)
    {
        if(slider.value == myPlayer.how_exp){
            slider.value = 0;
            currentLevel++;
            UpdateLevel();
        } else{
            slider.value = exp;
        }
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    void UpdateLevel(){
        Debug.Log("Level UP!!!");
        levelText.text = currentLevel.ToString();
    }
}
