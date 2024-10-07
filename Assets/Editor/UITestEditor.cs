using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class UITestEditor : MonoBehaviour
{
    [MenuItem("UITestTool/UI/Show_ReadyPanel", priority = 0)]
    public static void CreateReadyPanel()
    {
        UIManager.Instance.ShowPanel(PanelMap.PanelType.ReadyPanel);
    }

    [MenuItem("UITestTool/UI/Hide_ReadyPanel", priority = 1)]
    public static void HideReadyPanel()
    {
        UIManager.Instance.HidePanel(PanelMap.PanelType.ReadyPanel);
    }

    [MenuItem("UITestTool/Untility/ClearPanelDic", priority = 3)]
    public static void ClearPanelDic()
    {
        UIManager.Instance.ClearPanelDic();
        Debug.Log("清理成功：" + UIManager.Instance.paneList.Count);
    }

    [MenuItem("UITestTool/Untility/WriteGameDataByJson", priority = 2)]
    public static void WriteGameDataByJson()
    {
        GameDataManager.Instance.WriteGameDataFromSAPath();
    }

    [MenuItem("UITestTool/Untility/CreateGameData", priority = 1)]
    public static void CreateGameData()
    {

        GameSaved gameSaved = new GameSaved();
        gameSaved.gameSavedDatas = new List<GameSavedData>();
        for (int i = 0; i < 5; i++)
        {
            gameSaved.gameSavedDatas.Add(new GameSavedData()
            {
                lastPosition = new SavedPoint
                {
                    postionX = i,
                    postionY = i * 2 + 1,
                    postionZ = i * 3 + 2,
                    imgPath = "Image/scene_outdoor_hu",
                    pointName = "场景_" + i
                },
                gameLoop = i,
                gameLevel = i * 30,
                playDuration = i * 10.2f,
                last_DateTime = System.DateTime.Now.AddHours(i).ToString()
            });
        }

        GameDataManager.Instance.WriteGameDataFromSAPath(gameSaved);
        print(GameDataManager.Instance.GameSavedDatas.gameSavedDatas.Count);
        Debug.Log(Application.persistentDataPath);
    }

    [MenuItem("APITest/PrintDate")]
    public static void PrintDate()
    {
        Debug.Log("当前时间：" + System.DateTime.Now);

        Debug.Log("年：" + System.DateTime.Now.Year);
        Debug.Log("星期：" + System.DateTime.Now.DayOfWeek);
        Debug.Log("月：" + System.DateTime.Now.Month);
        Debug.Log("天：" + System.DateTime.Now.Day);
        Debug.Log("小时：" + System.DateTime.Now.Hour);
        Debug.Log("分钟：" + System.DateTime.Now.Minute);
        Debug.Log("秒：" + System.DateTime.Now.Second);
        Debug.Log("毫秒：" + System.DateTime.Now.Millisecond);
    }
}
