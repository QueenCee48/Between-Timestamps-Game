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

    private TimeController timeCntrlr;
    
    public MsgsThreadMngr manager;

    void Awake()
    {
        if (gameObject.name == "ValeThread" || gameObject.name == "EvanThread")
        {
            selectedColorPres = new Color32(131, 255, 244, 255);
            unselectedColorPres = new Color32(12, 173, 159, 255);

            selectedColorPast = new Color32(131, 188, 255, 255);
            unselectedColorPast = new Color32(56, 136, 231, 255);

            selectedColorCorr = new Color32(255, 121, 126, 255);
            unselectedColorCorr = new Color32(238, 55, 66, 255);
        }
        else if (gameObject.name == "ProjectSummary" || gameObject.name == "ProfessionalReflection" || gameObject.name == "TemporalErasure")
        {
            selectedColorPres = new Color32(99, 215, 205, 50);
            unselectedColorPres = new Color32(99, 215, 205, 0);

            selectedColorPast = new Color32(81, 159, 255, 50);
            unselectedColorPast = new Color32(81, 159, 255, 0);

            selectedColorCorr = new Color32(255, 106, 113, 50);
            unselectedColorCorr = new Color32(255, 106, 113, 0);
        }

        myThreadImg = GetComponent<Image>();

        timeCntrlr = GameObject.Find("TimeControls").GetComponent<TimeController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "ValeThread")
        {
            if (timeCntrlr.IsInPresent()) 
            {
                notiBbl.enabled = !ItemsReadState.Instance.valeMsgReadPres;
            }
            else if (timeCntrlr.IsInPast())
            {
                notiBbl.enabled = !ItemsReadState.Instance.valeMsgReadPast;
            }
            else if (timeCntrlr.IsInCorrupt())
            {
                notiBbl.enabled = !ItemsReadState.Instance.valeMsgReadCorr;
            }
        }
        else if (gameObject.name == "EvanThread")
        {
            if (timeCntrlr.IsInPresent()) 
            {
                notiBbl.enabled = !ItemsReadState.Instance.evanMsgReadPres;
            }
            else if (timeCntrlr.IsInPast())
            {
                notiBbl.enabled = !ItemsReadState.Instance.evanMsgReadPast;
            }
            else if (timeCntrlr.IsInCorrupt())
            {
                notiBbl.enabled = !ItemsReadState.Instance.evanMsgReadCorr;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        manager.SelectThread(this);

        // Messages
        if (gameObject.name == "ValeThread")
        {
            if (timeCntrlr.IsInPresent()) 
            {
                if (!ItemsReadState.Instance.valeMsgReadPres)
                {
                    ItemsReadState.Instance.valeMsgReadPres = true;

                    if (notiBbl != null)
                    {
                        notiBbl.enabled = false;
                    }
                }
            }
            else if (timeCntrlr.IsInPast())
            {
                if (!ItemsReadState.Instance.valeMsgReadPast)
                {
                    ItemsReadState.Instance.valeMsgReadPast = true;

                    if (notiBbl != null)
                    {
                        notiBbl.enabled = false;
                    }
                }
            }
            else if (timeCntrlr.IsInCorrupt())
            {
                if (!ItemsReadState.Instance.valeMsgReadCorr)
                {
                    ItemsReadState.Instance.valeMsgReadCorr = true;

                    if (notiBbl != null)
                    {
                        notiBbl.enabled = false;
                    }
                }
            }
        }
        else if (gameObject.name == "EvanThread")
        {
            if (timeCntrlr.IsInPresent()) 
            {
                if (!ItemsReadState.Instance.evanMsgReadPres)
                {
                    ItemsReadState.Instance.evanMsgReadPres = true;

                    if (notiBbl != null)
                    {
                        notiBbl.enabled = false;
                    }
                }
            }
            else if (timeCntrlr.IsInPast())
            {
                if (!ItemsReadState.Instance.evanMsgReadPast)
                {
                    ItemsReadState.Instance.evanMsgReadPast = true;

                    if (notiBbl != null)
                    {
                        notiBbl.enabled = false;
                    }
                }
            }
            else if (timeCntrlr.IsInCorrupt())
            {
                if (!ItemsReadState.Instance.evanMsgReadCorr)
                {
                    ItemsReadState.Instance.evanMsgReadCorr = true;

                    if (notiBbl != null)
                    {
                        notiBbl.enabled = false;
                    }
                }
            }
        }

        // TalkGPT
        else if (gameObject.name == "ProjectSummary")
        {
            if (timeCntrlr.IsInPresent()) 
            {
                if (!ItemsReadState.Instance.projSummReadPres)
                {
                    ItemsReadState.Instance.projSummReadPres = true;
                }
            }
            else if (timeCntrlr.IsInPast())
            {
                if (!ItemsReadState.Instance.projSummReadPast)
                {
                    ItemsReadState.Instance.projSummReadPast = true;
                }
            }
            else if (timeCntrlr.IsInCorrupt())
            {
                if (!ItemsReadState.Instance.projSummReadCorr)
                {
                    ItemsReadState.Instance.projSummReadCorr = true;
                }
            }
        }
        else if (gameObject.name == "ProfessionalReflection")
        {
            if (timeCntrlr.IsInPresent()) 
            {
                if (!ItemsReadState.Instance.profReflReadPres)
                {
                    ItemsReadState.Instance.profReflReadPres = true;
                }
            }
            else if (timeCntrlr.IsInPast())
            {
                if (!ItemsReadState.Instance.profReflReadPast)
                {
                    ItemsReadState.Instance.profReflReadPast = true;
                }
            }
            else if (timeCntrlr.IsInCorrupt())
            {
                if (!ItemsReadState.Instance.profReflReadCorr)
                {
                    ItemsReadState.Instance.profReflReadCorr = true;
                }
            }
        }
        else if (gameObject.name == "TemporalErasure")
        {
            if (timeCntrlr.IsInCorrupt())
            {
                if (!ItemsReadState.Instance.tempErasReadCorr)
                {
                    ItemsReadState.Instance.tempErasReadCorr = true;
                }
            }
        }
    }

    public void SetSelected()
    {
        if (timeCntrlr.IsInPresent()) {
            myThreadImg.color = selectedColorPres;
        }
        else if (timeCntrlr.IsInPast())
        {
            myThreadImg.color = selectedColorPast;
        }
        else if (timeCntrlr.IsInCorrupt())
        {
            myThreadImg.color = selectedColorCorr;
        }
    }

    public void SetUnselected()
    {
        if (timeCntrlr.IsInPresent()) {
            myThreadImg.color = unselectedColorPres;
        }
        else if (timeCntrlr.IsInPast())
        {
            myThreadImg.color = unselectedColorPast;
        }
        else if (timeCntrlr.IsInCorrupt())
        {
            myThreadImg.color = unselectedColorCorr;
        }
    }
}
