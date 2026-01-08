using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class WindowController : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    Canvas canvas;
    RectTransform rect;
    RectTransform parentRect;

    public Text titleText;
    public String appName;

    GameObject activeContentInstance;

    private WndwAreaCntrlr wndwAreaCntrlr;

    void Awake()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        rect = GetComponent<RectTransform>();
        parentRect = GameObject.Find("WindowArea").GetComponent<RectTransform>();
        wndwAreaCntrlr = GameObject.Find("WindowArea").GetComponent<WndwAreaCntrlr>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rect.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
        ClampToParent();
    }

    void ClampToParent()
    {
        Vector2 pos = rect.anchoredPosition;

        float parentWidth = parentRect.rect.width;
        float parentHeight = parentRect.rect.height;

        float xLimit = (parentWidth / 2) - (rect.rect.width / 2);
        float yLimit = (parentHeight / 2) - (rect.rect.height / 2);

        pos.x = Mathf.Clamp(pos.x, -xLimit, xLimit);
        pos.y = Mathf.Clamp(pos.y, -yLimit, yLimit);

        rect.anchoredPosition = pos;
    }

    public void SetTitle(string title)
    {
        titleText.text = title;
    }

    public void CloseWindow()
    {
        wndwAreaCntrlr.openWndws.Remove(this.gameObject, out appName);
        Destroy(gameObject);
    }

    public void SetWindowContent(GameObject presContent, GameObject pastContent, GameObject corrContent, TimeController timeCntrlr2)
    {
        if (activeContentInstance != null)
        {
            Destroy(activeContentInstance);
        }

        GameObject contentToSpawn = null;

        if (timeCntrlr2.IsInPresent())
        {
            contentToSpawn = presContent;
        }
        else if (timeCntrlr2.IsInPast())
        {
            contentToSpawn = pastContent;
        }
        else if (timeCntrlr2.IsInCorrupt())
        {
            contentToSpawn = corrContent;
        }

        activeContentInstance = Instantiate(contentToSpawn, transform);
    }
}
