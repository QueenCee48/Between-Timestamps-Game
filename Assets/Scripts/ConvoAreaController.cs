using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvoAreaController : MonoBehaviour
{
    public RectTransform content;
    public RectTransform viewport;
    public int scrollStep = 16;

    // Start is called before the first frame update
    void Start()
    {
        content.anchoredPosition = new Vector2(0, GetMaxScroll());
    }

    // Update is called once per frame
    void Update()
    {
        float wheel = Input.mouseScrollDelta.y;

        if (wheel > 0)
        {
            ScrollUp();
        }
        else if (wheel < 0)
        {
            ScrollDown();
        }
    }

    public void ScrollUp()
    {
        Vector2 pos = content.anchoredPosition;

        pos.y -= scrollStep;
        pos.y = Mathf.Clamp(pos.y, -GetMaxScroll(), 0);
        pos.y = Mathf.Round(pos.y);
        content.anchoredPosition = pos;
    }

    public void ScrollDown()
    {
        Vector2 pos = content.anchoredPosition;

        pos.y += scrollStep;
        pos.y = Mathf.Clamp(pos.y, -GetMaxScroll(), 0);
        pos.y = Mathf.Round(pos.y);
        content.anchoredPosition = pos;
    }

    float GetMaxScroll()
    {
        float contentHeight = content.rect.height;
        float viewportHeight = viewport.rect.height;

        return Mathf.Max(0, contentHeight - viewportHeight);
    }
}
