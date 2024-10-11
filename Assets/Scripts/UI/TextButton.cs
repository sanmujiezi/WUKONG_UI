using System;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Button button;
    public TextMeshProUGUI text;
    public TextMeshProUGUI text_Select;
    public GameObject selectState;
    private void Start() {
        text_Select.text = text.text;
        
    }                
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        selectState.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selectState.SetActive(false);
    }


}



