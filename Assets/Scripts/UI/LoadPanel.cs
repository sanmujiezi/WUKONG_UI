using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadPanel : BasePanel
{
    public ScrollRect scrollView;
    public TextMeshProUGUI savedCount;
    private LoadButton lastSelectedButton;
    public LoadButton LastSelectedButton => lastSelectedButton;

    protected override void Init()
    {
        var datas = GameDataManager.Instance.GameSavedDatas.gameSavedDatas.Count;

        savedCount.text = datas.ToString() + " / 10";

        //ClearChild
        for(int i = 0 ; i < scrollView.content.childCount ; i++)
        {
            Destroy(scrollView.content.GetChild(i).gameObject);
        }
        //LoadSaved
        for(int i = 0; i< GameDataManager.Instance.GameSavedDatas.gameSavedDatas.Count; i++)
        {
            GameObject button = Instantiate(Resources.Load<GameObject>("UI/LoadButton"),scrollView.content.transform);
            var buttonScript = button.GetComponent<LoadButton>();
            buttonScript.gameSavedData = GameDataManager.Instance.GameSavedDatas.gameSavedDatas[i];
            buttonScript.SetParent(this);
            
        }

    }

    public void SetSelectedButton(LoadButton button){
        lastSelectedButton = button;
    }

}
