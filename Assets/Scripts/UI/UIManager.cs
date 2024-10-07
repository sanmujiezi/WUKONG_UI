using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class UIManager
{
    private static UIManager instance = new UIManager();
    public static UIManager Instance => instance;
    public Dictionary<PanelMap.PanelType, BasePanel> paneList = new Dictionary<PanelMap.PanelType, BasePanel>();
    private GameObject uiRoot;
    public UIManager()
    {
        uiRoot = GameObject.Find("Canvas");
    }

    public BasePanel ShowPanel(PanelMap.PanelType panelType)
    {
        if (paneList.ContainsKey(panelType))
        {
            Debug.Log(panelType.ToString() + "已经打开");
            return null;
        }

        string path = PanelMap.Instance.PanelMaps[panelType];
        GameObject panel = GameObject.Instantiate(Resources.Load<GameObject>(path), uiRoot.transform);
        var panel_s = panel.GetComponent<BasePanel>();
        panel_s.ShowMe();
        paneList.Add(panelType, panel_s);

        return panel_s;

    }

    public void HidePanel(PanelMap.PanelType panelType,bool isFade = true)
    {
        if(!paneList.ContainsKey(panelType))
        {
            Debug.Log(panelType.ToString()+"未打开");
            return;
        }

        if(isFade){
            paneList[panelType].HideMe(()=>{
                GameObject.Destroy(paneList[panelType].gameObject);
                paneList.Remove(panelType);
            });
        }else{
            GameObject.Destroy(paneList[panelType].gameObject);
                paneList.Remove(panelType);
        }
    }

    public void ClearPanelDic(){
        paneList.Clear();
    }
}
