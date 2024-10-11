using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoadButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public TextMeshProUGUI posTittle;
    public TextMeshProUGUI loopCount;
    public TextMeshProUGUI level;
    public TextMeshProUGUI hour;
    public TextMeshProUGUI date;
    public TextMeshProUGUI time;

    public GameSavedData gameSavedData;

    public GameObject select;
    public GameObject unSelect;
    private LoadPanel parent;
    private bool isSelected;

    private void Start()
    {
        if (gameSavedData != null)
        {
            posTittle.text = gameSavedData.lastPosition.pointName;
            level.text = gameSavedData.gameLevel.ToString();
            hour.text = gameSavedData.playDuration.ToString();
            date.text = gameSavedData.last_DateTime;
            if (gameSavedData.gameLoop <= 1)
            {

                loopCount.text = "";
            }
            else
            {
                loopCount.text = gameSavedData.gameLoop.ToString() + "番轮回";
            }

        }
    }
    public void SetParent(LoadPanel parent)
    {
        this.parent = parent;
    }

    public void SetUnSelectd()
    {
        isSelected = false;
        select.SetActive(false);
        unSelect.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("ONClick");
        //CloseLastButton
        if (parent.LastSelectedButton != null)
        {
            parent.LastSelectedButton.SetUnSelectd();
        }

        //To set This Button is "Selected"
        isSelected = true;
        select.SetActive(true);
        unSelect.SetActive(false);

        parent.SetSelectedButton(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        unSelect.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isSelected)
        {
            unSelect.SetActive(true);
        }
    }
}