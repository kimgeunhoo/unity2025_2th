using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatUIElement : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI valueText;

    public void SetUI(float value)
    {
        valueText.SetText(value.ToString());    
    }
}