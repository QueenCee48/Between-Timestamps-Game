using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TxtIconController : MonoBehaviour, IPointerClickHandler
{
    public GameObject txtFilePrefab;
    public Sprite presImg;
    public Sprite pastImg;
    public Sprite corrImg;

    public Text txtIconLabel;

    private WndwAreaCntrlr wndwAreaCntrlr;
    private TimeController timeCntrlr;

    void Awake()
    {
        wndwAreaCntrlr = GameObject.Find("WindowArea").GetComponent<WndwAreaCntrlr>();
        timeCntrlr = GameObject.Find("TimeControls").GetComponent<TimeController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        wndwAreaCntrlr.OpenFile(txtFilePrefab, presImg, pastImg, corrImg);

        // File Explorer
        if (gameObject.name == "ReadMe") {

            if (timeCntrlr.IsInPresent()) 
            {
                if (!ItemsReadState.Instance.readMeReadPres)
                {
                    ItemsReadState.Instance.readMeReadPres = true;
                }
            }
            else if (timeCntrlr.IsInPast())
            {
                if (!ItemsReadState.Instance.readMeReadPast)
                {
                    ItemsReadState.Instance.readMeReadPast = true;
                }
            }
            else if (timeCntrlr.IsInCorrupt())
            {
                if (!ItemsReadState.Instance.readMeReadCorr)
                {
                    ItemsReadState.Instance.readMeReadCorr = true;
                }
            }
        }
        else if (gameObject.name == "Log01") {

            if (timeCntrlr.IsInPresent()) 
            {
                if (!ItemsReadState.Instance.log1ReadPres)
                {
                    ItemsReadState.Instance.log1ReadPres = true;
                }
            }
            else if (timeCntrlr.IsInPast())
            {
                if (!ItemsReadState.Instance.log1ReadPast)
                {
                    ItemsReadState.Instance.log1ReadPast = true;
                }
            }
            else if (timeCntrlr.IsInCorrupt())
            {
                if (!ItemsReadState.Instance.log1ReadCorr)
                {
                    ItemsReadState.Instance.log1ReadCorr = true;
                }
            }
        }
        else if (gameObject.name == "Log02") {

            if (timeCntrlr.IsInPresent()) 
            {
                if (!ItemsReadState.Instance.log2ReadPres)
                {
                    ItemsReadState.Instance.log2ReadPres = true;
                }
            }
            else if (timeCntrlr.IsInPast())
            {
                if (!ItemsReadState.Instance.log2ReadPast)
                {
                    ItemsReadState.Instance.log2ReadPast = true;
                }
            }
            else if (timeCntrlr.IsInCorrupt())
            {
                if (!ItemsReadState.Instance.log2ReadCorr)
                {
                    ItemsReadState.Instance.log2ReadCorr = true;
                }
            }
        }
        else if (gameObject.name == "SysWarn") {

            if (timeCntrlr.IsInPresent()) 
            {
                if (!ItemsReadState.Instance.sysWarnReadPres)
                {
                    ItemsReadState.Instance.sysWarnReadPres = true;
                }
            }
            else if (timeCntrlr.IsInCorrupt())
            {
                if (!ItemsReadState.Instance.sysWarnReadCorr)
                {
                    ItemsReadState.Instance.sysWarnReadCorr = true;
                }
            }
        }
        else if (gameObject.name == "EchoFrag") {

            if (timeCntrlr.IsInCorrupt())
            {
                if (!ItemsReadState.Instance.echoFragReadCorr)
                {
                    ItemsReadState.Instance.echoFragReadCorr = true;
                }
            }
        }

        // Notes
        else if (gameObject.name == "PersonalLog") {

            if (timeCntrlr.IsInPresent()) 
            {
                if (!ItemsReadState.Instance.persLogReadPres)
                {
                    ItemsReadState.Instance.persLogReadPres = true;
                }
            }
            else if (timeCntrlr.IsInPast())
            {
                if (!ItemsReadState.Instance.persLogReadPast)
                {
                    ItemsReadState.Instance.persLogReadPast = true;
                }
            }
            else if (timeCntrlr.IsInCorrupt())
            {
                if (!ItemsReadState.Instance.persLogReadCorr)
                {
                    ItemsReadState.Instance.persLogReadCorr = true;
                }
            }
        }
        else if (gameObject.name == "EchoDraft") {

            if (timeCntrlr.IsInPresent()) 
            {
                if (!ItemsReadState.Instance.echoDraftReadPres)
                {
                    ItemsReadState.Instance.echoDraftReadPres = true;
                }
            }
            else if (timeCntrlr.IsInPast())
            {
                if (!ItemsReadState.Instance.echoDraftReadPast)
                {
                    ItemsReadState.Instance.echoDraftReadPast = true;
                }
            }
            else if (timeCntrlr.IsInCorrupt())
            {
                if (!ItemsReadState.Instance.echoDraftReadCorr)
                {
                    ItemsReadState.Instance.echoDraftReadCorr = true;
                }
            }
        }
        else if (gameObject.name == "Reminders") {

            if (timeCntrlr.IsInPresent()) 
            {
                if (!ItemsReadState.Instance.remindersReadPres)
                {
                    ItemsReadState.Instance.remindersReadPres = true;
                }
            }
            else if (timeCntrlr.IsInPast())
            {
                if (!ItemsReadState.Instance.remindersReadPast)
                {
                    ItemsReadState.Instance.remindersReadPast = true;
                }
            }
            else if (timeCntrlr.IsInCorrupt())
            {
                if (!ItemsReadState.Instance.remindersReadCorr)
                {
                    ItemsReadState.Instance.remindersReadCorr = true;
                }
            }
        }

        // Photos
        else if (gameObject.name == "LabEntry") {

            if (timeCntrlr.IsInPresent()) 
            {
                if (!ItemsReadState.Instance.labEntryReadPres)
                {
                    ItemsReadState.Instance.labEntryReadPres = true;
                }
            }
            else if (timeCntrlr.IsInPast())
            {
                if (!ItemsReadState.Instance.labEntryReadPast)
                {
                    ItemsReadState.Instance.labEntryReadPast = true;
                }
            }
            else if (timeCntrlr.IsInCorrupt())
            {
                if (!ItemsReadState.Instance.labEntryReadCorr)
                {
                    ItemsReadState.Instance.labEntryReadCorr = true;
                }
            }
        }
        else if (gameObject.name == "ControlRoom") {

            if (timeCntrlr.IsInPresent()) 
            {
                if (!ItemsReadState.Instance.cntrlRoomReadPres)
                {
                    ItemsReadState.Instance.cntrlRoomReadPres = true;
                }
            }
            else if (timeCntrlr.IsInPast())
            {
                if (!ItemsReadState.Instance.cntrlRoomReadPast)
                {
                    ItemsReadState.Instance.cntrlRoomReadPast = true;
                }
            }
            else if (timeCntrlr.IsInCorrupt())
            {
                if (!ItemsReadState.Instance.cntrlRoomReadCorr)
                {
                    ItemsReadState.Instance.cntrlRoomReadCorr = true;
                }
            }
        }
        else if (gameObject.name == "SubjectFrame") {

            if (timeCntrlr.IsInPresent()) 
            {
                if (!ItemsReadState.Instance.subFrameReadPres)
                {
                    ItemsReadState.Instance.subFrameReadPres = true;
                }
            }
            else if (timeCntrlr.IsInPast())
            {
                if (!ItemsReadState.Instance.subFrameReadPast)
                {
                    ItemsReadState.Instance.subFrameReadPast = true;
                }
            }
            else if (timeCntrlr.IsInCorrupt())
            {
                if (!ItemsReadState.Instance.subFrameReadCorr)
                {
                    ItemsReadState.Instance.subFrameReadCorr = true;
                }
            }
        }
        else if (gameObject.name == "FinalCapture") {

            if (timeCntrlr.IsInPresent()) 
            {
                if (!ItemsReadState.Instance.finalCaptReadPres)
                {
                    ItemsReadState.Instance.finalCaptReadPres = true;
                }
            }
            else if (timeCntrlr.IsInPast())
            {
                if (!ItemsReadState.Instance.finalCaptReadPast)
                {
                    ItemsReadState.Instance.finalCaptReadPast = true;
                }
            }
            else if (timeCntrlr.IsInCorrupt())
            {
                if (!ItemsReadState.Instance.finalCaptReadCorr)
                {
                    ItemsReadState.Instance.finalCaptReadCorr = true;
                }
            }
        }

        // Trash
        else if (gameObject.name == "StaffGroup") {

            if (timeCntrlr.IsInPresent()) 
            {
                if (!ItemsReadState.Instance.staffGroupReadPres)
                {
                    ItemsReadState.Instance.staffGroupReadPres = true;
                }
            }
            else if (timeCntrlr.IsInPast())
            {
                if (!ItemsReadState.Instance.staffGroupReadPast)
                {
                    ItemsReadState.Instance.staffGroupReadPast = true;
                }
            }
            else if (timeCntrlr.IsInCorrupt())
            {
                if (!ItemsReadState.Instance.staffGroupReadCorr)
                {
                    ItemsReadState.Instance.staffGroupReadCorr = true;
                }
            }
        }
        else if (gameObject.name == "Argument") {

            if (timeCntrlr.IsInPresent()) 
            {
                if (!ItemsReadState.Instance.argumentReadPres)
                {
                    ItemsReadState.Instance.argumentReadPres = true;
                }
            }
            else if (timeCntrlr.IsInPast())
            {
                if (!ItemsReadState.Instance.argumentReadPast)
                {
                    ItemsReadState.Instance.argumentReadPast = true;
                }
            }
            else if (timeCntrlr.IsInCorrupt())
            {
                if (!ItemsReadState.Instance.argumentReadCorr)
                {
                    ItemsReadState.Instance.argumentReadCorr = true;
                }
            }
        }
        else if (gameObject.name == "TempDis") {

            if (timeCntrlr.IsInCorrupt())
            {
                if (!ItemsReadState.Instance.tempDispReadCorr)
                {
                    ItemsReadState.Instance.tempDispReadCorr = true;
                }
            }
        }
        else if (gameObject.name == "ResiPres") {

            if (timeCntrlr.IsInCorrupt())
            {
                if (!ItemsReadState.Instance.resiPresReadCorr)
                {
                    ItemsReadState.Instance.resiPresReadCorr = true;
                }
            }
        }
    }

}
