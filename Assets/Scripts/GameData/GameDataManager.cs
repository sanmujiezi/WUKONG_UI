using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using UnityEngine;

public class GameDataManager
{
    private static GameDataManager instance = new GameDataManager();
    public static GameDataManager Instance => instance;
    private GameSaved gameSavedDatas;
    public GameSaved GameSavedDatas => gameSavedDatas;

    GameDataManager()
    {
        gameSavedDatas = JsonMgr.Instance.LoadData<GameSaved>("GameSaved");
    }

    public void SaveGameData()
    {
        JsonMgr.Instance.SaveData(gameSavedDatas, "GameSaved");
    }

    /// <summary>
    /// 写入streamingAssetsPath下的GameSaved.json文件
    /// </summary>
    public void WriteGameDataFromSAPath()
    {

        if (!File.Exists(Application.streamingAssetsPath + "GameSaved.json"))
        {
            Debug.Log("写入的源文件不存在，请创建GameSaved.json文件");
            return;
        }
        gameSavedDatas = JsonMgr.Instance.LoadData<GameSaved>("GameSaved");
        SaveGameData();

    }

    public void WriteGameDataFromSAPath(GameSaved gameSaved)
    {
        gameSavedDatas = gameSaved;
        SaveGameData();
    }





}

public class GameSaved
{
    public GameSavedData lastPlaySaved;
    public List<GameSavedData> gameSavedDatas;
}

public class GameSavedData
{
    public GameSavedData()
    {
        lastPosition = new SavedPoint();
        gameLoop = 1;
        gameLevel = 1;
        playDuration = 0;
        last_DateTime = System.DateTime.Now.ToString();
    }
    public GameSavedData(SavedPoint lastPosition)
    {
        this.lastPosition = lastPosition;
        this.gameLoop = 1;
        this.gameLevel = 1;
        this.playDuration = 0;
        last_DateTime = DateTime.Now.ToString();
    }
    public SavedPoint lastPosition;
    public int gameLoop;
    public int gameLevel;
    public float playDuration;
    public string last_DateTime;
}

public class SavedPoint
{
    public SavedPoint()
    {
        postionX = 0;
        postionY = 0;
        postionZ = 0;
        imgPath = "UI/scene_outdoor_hu";
        pointName = "未命名场地：" + Guid.NewGuid().ToString();
    }
    public SavedPoint(float x, float y, float z, string imgPath, string pointName)
    {
        postionX = x;
        postionY = y;
        postionZ = z;
        this.imgPath = imgPath;
        this.pointName = pointName;

    }

    public float postionX;
    public float postionY;
    public float postionZ;
    public string imgPath;
    public string pointName;
}