using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using JetBrains.Annotations;
using TMPro;

public class ReadyPanel : BasePanel
{
    public Image bg;
    public Image logo;
    public CanvasGroup textCanvasGroup;
    private float speed = 0.5f;
    private bool isShowText = true;
    protected override void Update()
    {
        base.Update();
        if (!Input.anyKeyDown)
        {
            if (isShowText)
            {
                textCanvasGroup.alpha -= Time.deltaTime * speed;
                if (textCanvasGroup.alpha <= 0f)
                {
                    textCanvasGroup.alpha = 0f;
                    isShowText = false;
                }

            }
            else
            {
                textCanvasGroup.alpha += Time.deltaTime * speed;
                if (textCanvasGroup.alpha >= 1f)
                {
                    textCanvasGroup.alpha = 1f;
                    isShowText = true;
                }
            }
        }
        else
        {
            textCanvasGroup.alpha = 1;
            UIManager.Instance.HidePanel(PanelMap.PanelType.ReadyPanel);
            UIManager.Instance.ShowPanel(PanelMap.PanelType.StartPanel);
        }
    }

}
