using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public class BasePanel : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private UnityAction unityAction;
    private float fadeTime = 5f;
    private bool isShow;
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }


    protected virtual void Start()
    {
        Init();
    }

    protected virtual void Update()
    {
        if (isShow && canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * fadeTime;
            if (canvasGroup.alpha >= 1)
            {
                canvasGroup.alpha = 1;
            }

        }
        else if (!isShow && canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * fadeTime;
            if (canvasGroup.alpha <= 0)
            {
                canvasGroup.alpha = 0;
                unityAction?.Invoke();
            }
        }
    }

    public void ShowMe()
    {
        isShow = true;
        canvasGroup.alpha = 0;
    }

    public void HideMe(UnityAction unityAction)
    {
        isShow = false;
        canvasGroup.alpha = 1;
        this.unityAction = unityAction;
    }

    protected virtual void Init() { }
}
