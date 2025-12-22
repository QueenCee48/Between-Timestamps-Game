using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MsgsController : MonoBehaviour, IPointerClickHandler
{
    Color32 selectedColorPres;
    Color32 unselectedColorPres;

    Color32 selectedColorPast;
    Color32 unselectedColorPast;

    Color32 selectedColorCorr;
    Color32 unselectedColorCorr;

    public Image notiBbl;
    Image myThreadImg;

    TimeController timeCntrlr3;
    
    public MsgsThreadMngr manager;

    bool valeUnread;
    bool evanUnread;

    void Awake()
    {
        selectedColorPres = new Color32(131, 255, 244, 255);
        unselectedColorPres = new Color32(12, 173, 159, 255);

        selectedColorPast = new Color32(131, 188, 255, 255);
        unselectedColorPast = new Color32(56, 136, 231, 255);

        selectedColorCorr = new Color32(255, 121, 126, 255);
        unselectedColorCorr = new Color32(238, 55, 66, 255);

        myThreadImg = GetComponent<Image>();

        timeCntrlr3 = GameObject.Find("TimeControls").GetComponent<TimeController>();

        // valeUnread = true;
        // evanUnread = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "ValeThread")
        {
            notiBbl.enabled = !ItemsReadState.Instance.valeMsgRead;
        }
        else if (gameObject.name == "EvanThread")
        {
            notiBbl.enabled = !ItemsReadState.Instance.evanMsgRead;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        manager.SelectThread(this);

        if (gameObject.name == "ValeThread")
        {
            if (!ItemsReadState.Instance.valeMsgRead)
            {
                ItemsReadState.Instance.valeMsgRead = true;

                if (notiBbl != null)
                {
                    notiBbl.enabled = false;
                }
            }
        }

        else if (gameObject.name == "EvanThread")
        {
            if (!ItemsReadState.Instance.evanMsgRead)
            {
                ItemsReadState.Instance.evanMsgRead = true;

                if (notiBbl != null)
                {
                    notiBbl.enabled = false;
                }
            }
        }
    }

    public void SetSelected()
    {
        if (timeCntrlr3.IsInPresent()) {
            myThreadImg.color = selectedColorPres;
        }
        else if (timeCntrlr3.IsInPast())
        {
            myThreadImg.color = selectedColorPast;
        }
        else if (timeCntrlr3.IsInCorrupt())
        {
            myThreadImg.color = selectedColorCorr;
        }
    }

    public void SetUnselected()
    {
        if (timeCntrlr3.IsInPresent()) {
            myThreadImg.color = unselectedColorPres;
        }
        else if (timeCntrlr3.IsInPast())
        {
            myThreadImg.color = unselectedColorPast;
        }
        else if (timeCntrlr3.IsInCorrupt())
        {
            myThreadImg.color = unselectedColorCorr;
        }
    }
}
