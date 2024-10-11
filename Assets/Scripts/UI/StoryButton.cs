using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoryButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject selectGameObject;
    private Animator selectAni;
    private bool isEnter;
    private Canvas canvasLayer;


    public Image image_UnSelect;
    public Image image_Select;
    public  Image BG;
    public TextMeshProUGUI chapterTheme_Unselect;
    public TextMeshProUGUI chapterTheme;
    public TextMeshProUGUI chapterCount;
    public TextMeshProUGUI chapterName;


    [Header("输入参数")]
    public Sprite UnselectImage;
    public Sprite SelectImage;
    public string ChapterTheme;
    public string ChapterCount;
    public string ChapterName;

    private void Awake()
    {
        selectGameObject = transform.Find("Select").gameObject;
        selectAni = selectGameObject.GetComponent<Animator>();
        canvasLayer  = GetComponentInChildren<Canvas>();
    }

    void Start()
    {
        Init();
    }

    private void Init()
    {
        image_Select.sprite = SelectImage;
        image_UnSelect.sprite = UnselectImage;
        BG.sprite = UnselectImage;
        chapterTheme_Unselect.text = ChapterTheme;
        chapterTheme.text = ChapterTheme;
        chapterCount.text = ChapterCount;
        chapterName.text = ChapterName;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("enter");
        canvasLayer.sortingOrder = 2;
        isEnter = true;
        selectAni.SetBool("IsEnter", isEnter);
        //OpenSelect();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("exit");
        canvasLayer.sortingOrder = 1;
        isEnter = false;
        selectAni.SetBool("IsEnter", isEnter);
        //CloseSelect();
    }

    public void CloseSelect(){
        selectGameObject.SetActive(false);
    }
    public void OpenSelect(){
        selectGameObject.SetActive(true);
    }
}
