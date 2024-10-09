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

public class ButtonManager
{
    public enum ButtonType
    {
        continueGame,
        newGame,
        loadGame,
        story,
        settings,
        exit,
    }

    private static ButtonManager instance = new ButtonManager();
    public static ButtonManager Instance => instance;

    private Dictionary<ButtonType, UnityAction> buttonsAction = new Dictionary<ButtonType, UnityAction>();
    public Dictionary<ButtonType, UnityAction> ButtonsAction => buttonsAction;

    public ButtonManager()
    {
        buttonsAction.Add(ButtonType.continueGame, ContinueGame);
        buttonsAction.Add(ButtonType.newGame, NewGame);
        buttonsAction.Add(ButtonType.loadGame, LoadGame);
        buttonsAction.Add(ButtonType.story, Story);
        buttonsAction.Add(ButtonType.settings, GameSettings);
        buttonsAction.Add(ButtonType.exit,Exit);
    }

    private void Exit()
    {
        Debug.Log("Exit");
    }

    private void GameSettings()
    {
        Debug.Log("Settings");
    }

    private void Story()
    {
        Debug.Log("Story");
    }

    private void LoadGame()
    {
        Debug.Log("Load Game");
        UIManager.Instance.HidePanel(PanelMap.PanelType.StartPanel);
        UIManager.Instance.ShowPanel(PanelMap.PanelType.LoadPanel);
    }

    private void NewGame()
    {
        //GameDataManager.Instance.GameSavedDatas.gameSavedDatas.Add(new GameSavedData());
        Debug.Log("New Game");
    }

    private void ContinueGame()
    {
        Debug.Log("Continue Game");
    }


}
