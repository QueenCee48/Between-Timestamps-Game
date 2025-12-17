using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class AppController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    Canvas canvas;
    RectTransform rect;
    RectTransform parentRect;

    WndwAreaCntrlr wndwAreaCntrlr;

    Vector2 lastValidPos;
    bool isDragging;

    void Awake()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        rect = GetComponent<RectTransform>();
        parentRect = GameObject.Find("DesktopApps").GetComponent<RectTransform>();
        wndwAreaCntrlr = GameObject.Find("WindowArea").GetComponent<WndwAreaCntrlr>();
        lastValidPos = rect.anchoredPosition;
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
        lastValidPos = rect.anchoredPosition;

        isDragging = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDragging = true;

        rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
        ClampToParent();

        if (!IsOverlapping())
        {
            lastValidPos = rect.anchoredPosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (IsOverlapping())
        {
            rect.anchoredPosition = lastValidPos;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isDragging)
        {
            return;
        }

        OpenAppWindow();
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

    bool IsOverlapping()
    {
        GameObject[] apps = GameObject.FindGameObjectsWithTag("App");

        Rect myRect = GetWorldRect(rect);

        foreach (GameObject app in apps)
        {
            if (app == gameObject) continue;

            RectTransform otherApp = app.GetComponent<RectTransform>();
            Rect otherAppRect = GetWorldRect(otherApp);

            if (myRect.Overlaps(otherAppRect))
            {
                return true;
            }
        }
        return false;
    }

    Rect GetWorldRect(RectTransform rt)
    {
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners);

        return new Rect(
            corners[0].x,
            corners[0].y,
            corners[2].x - corners[0].x,
            corners[2].y - corners[0].y
        );
    }

    public void OpenAppWindow()
    {
        string appName = gameObject.name;
        wndwAreaCntrlr.OpenWindow(appName);
    }
}
