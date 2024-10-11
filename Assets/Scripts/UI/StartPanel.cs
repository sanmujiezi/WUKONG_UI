using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    public GameObject container;
    public List<TextButton> buttons;
    protected override void Init()
    {
        //读取登录数据
        if (GameDataManager.Instance.GameSavedDatas.gameSavedDatas.Count != 0)
        {
            //读取后重置按钮
            AddButton(true);
        }
        else
        {
            AddButton(false);
        }
    }

    public void AddButton(bool isFirst = true)
    {
        //重置按钮
        for (int i = 0; i < container.transform.childCount; i++)
        {
            DestroyImmediate(container.transform.GetChild(i).gameObject);
        }

        GameObject exit_B = Instantiate(Resources.Load<GameObject>("UI/TextButton"), container.transform);
        GameObject settings_B = Instantiate(Resources.Load<GameObject>("UI/TextButton"), container.transform);
        GameObject story_B = Instantiate(Resources.Load<GameObject>("UI/TextButton"), container.transform);
        GameObject load_B = Instantiate(Resources.Load<GameObject>("UI/TextButton"), container.transform);
        GameObject new_B = Instantiate(Resources.Load<GameObject>("UI/TextButton"), container.transform);
        //添加按钮
        if (isFirst)
        {
            GameObject continue_B = Instantiate(Resources.Load<GameObject>("UI/TextButton"), container.transform);
            continue_B.GetComponent<TextButton>().button.onClick.AddListener(ButtonManager.Instance.ButtonsAction[ButtonManager.ButtonType.continueGame]);
            continue_B.GetComponent <TextButton>().text.text = "继续游戏";
            buttons.Add(continue_B.GetComponent<TextButton>());
        }

        new_B.GetComponent<TextButton>().button.onClick.AddListener(ButtonManager.Instance.ButtonsAction[ButtonManager.ButtonType.newGame]);
        new_B.GetComponent<TextButton>().text.text = "新游戏";
        load_B.GetComponent<TextButton>().button.onClick.AddListener(ButtonManager.Instance.ButtonsAction[ButtonManager.ButtonType.loadGame]);
        load_B.GetComponent<TextButton>().text.text = "载入游戏";
        story_B.GetComponent<TextButton>().button.onClick.AddListener(ButtonManager.Instance.ButtonsAction[ButtonManager.ButtonType.story]);
        story_B.GetComponent<TextButton>().text.text = "前尘影事";
        settings_B.GetComponent<TextButton>().button.onClick.AddListener(ButtonManager.Instance.ButtonsAction[ButtonManager.ButtonType.settings]);
        settings_B.GetComponent<TextButton>().text.text = "设置";
        exit_B.GetComponent<TextButton>().button.onClick.AddListener(ButtonManager.Instance.ButtonsAction[ButtonManager.ButtonType.exit]);
        exit_B.GetComponent<TextButton>().text.text = "退出";

        buttons.Add(new_B.GetComponent<TextButton>());
        buttons.Add(load_B.GetComponent<TextButton>());
        buttons.Add(story_B.GetComponent<TextButton>());
        buttons.Add(settings_B.GetComponent<TextButton>());
        buttons.Add(exit_B.GetComponent<TextButton>());
        
    }

    private void OnDestroy() {
        
    }

}
