using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;

public enum JsonType
{
    ListJson,
    JsonUtility
}

public class JsonMgr
{
    private static JsonMgr instance = new JsonMgr();
    public static JsonMgr Instance => instance;

    private JsonMgr() { }

    public void SaveData(object data, string fileName, JsonType jsonType = JsonType.ListJson)
    {
        string path = Application.persistentDataPath;

        string tempJson = "";
        switch (jsonType)
        {
            case JsonType.ListJson:
                tempJson = JsonMapper.ToJson(data);
                break;
            case JsonType.JsonUtility:
                tempJson = JsonUtility.ToJson(data);
                break;
        }
        File.WriteAllText(path + "/" + fileName, tempJson);
    }

    public T LoadData<T>(string fileName, JsonType jsonType = JsonType.ListJson) where T : new()
    {
        string path =Application.streamingAssetsPath + "/" + fileName + ".json";
         
        if (!File.Exists(path))
        {
            path = Application.persistentDataPath + "/" + fileName;
        }
        if (!File.Exists(path))
        {
            return new T();
        }


        string json = File.ReadAllText(path);
        T data = default(T);
        switch (jsonType)
        {
            case JsonType.ListJson:
                data = JsonMapper.ToObject<T>(json);
                break;
            case JsonType.JsonUtility:
                data = JsonUtility.FromJson<T>(json);
                break;
        }

        return data;


    }
}
