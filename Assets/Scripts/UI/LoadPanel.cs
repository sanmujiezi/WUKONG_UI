using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadPanel : BasePanel
{
    public ScrollRect scrollView;
    public TextMeshProUGUI savedCount;

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

        }

    }

}
