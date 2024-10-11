using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        UIManager.Instance.HidePanel(PanelMap.PanelType.StartPanel);
        UIManager.Instance.ShowPanel(PanelMap.PanelType.StoryPanel);
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
