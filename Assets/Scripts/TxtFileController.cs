using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TxtFileController : MonoBehaviour, IDragHandler, IPointerDownHandler
{

    Canvas canvas;
    RectTransform rect;
    RectTransform parentRect;

    public Sprite presImage;
    public Sprite pastImage;
    public Sprite corrImage;

    private WndwAreaCntrlr wndwAreaCntrlr;
    private TimeController timeCntrlr;
    Image img;

    public string fileName;

    void Awake()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        rect = GetComponent<RectTransform>();
        parentRect = GameObject.Find("WindowArea").GetComponent<RectTransform>();

        img = GetComponent<Image>();
        timeCntrlr = GameObject.Find("TimeControls").GetComponent<TimeController>();
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

    public void UpdateFile()
    {
        if (timeCntrlr.IsInPresent() && presImage != null)
        {
            img.sprite = presImage;
        }
        else if (timeCntrlr.IsInPast() && pastImage != null)
        {
            img.sprite = pastImage;
        }
        else if (timeCntrlr.IsInCorrupt() && corrImage != null)
        {
            img.sprite = corrImage;
        }
        else 
        {
            CloseFile();
        }
    }

    public void CloseFile()
    {
        wndwAreaCntrlr.openFls.Remove(this.gameObject, out fileName);
        Destroy(gameObject);
    }
}
