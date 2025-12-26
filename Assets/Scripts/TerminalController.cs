using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalController : MonoBehaviour
{
    Text terminalText;
    public Text inputText;
    public InputField inputPanel;
    public ScrollRect scrollRect;

    private TimeController timeCntrlr;

    private string lastLayer;

    void Awake()
    {
        timeCntrlr = GameObject.Find("TimeControls").GetComponent<TimeController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        terminalText = GetComponent<Text>();
        lastLayer = timeCntrlr.currentLayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCntrlr.currentLayer != lastLayer)
        {
            terminalText.text = "PS C:\\Users\\Dr.MaraKline> \n\nAvailable commands: \nhelp \nstatus \nhistory \ndiagnose \nexit";
            inputText.text = "";
            inputPanel.text = "";
            lastLayer = timeCntrlr.currentLayer;

            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;
        }
    }

    public void SubmitInput()
    {
        terminalText.text += "\n";
        terminalText.text += "\n" + inputText.text;

        if (timeCntrlr.IsInPresent())
        {
            terminalText.text += "\n" + PresentTerminalResponse(inputText.text);
        }
        else if (timeCntrlr.IsInPast())
        {
            terminalText.text += "\n" + PastTerminalResponse(inputText.text);
        }
        else if (timeCntrlr.IsInCorrupt())
        {
            terminalText.text += "\n" + CorruptedTerminalResponse(inputText.text);
        }

        inputText.text = "";
        inputPanel.text = "";

        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
    }

    string PresentTerminalResponse(string input)
    {
        string response = "";

        switch (input)
        {
            case "help":
                response = "\nAvailable commands: \nhelp \nstatus \nhistory \ndiagnose \nexit";
                break;
            case "status":
                response = "\nSystem Status: ONLINE \nTemporal Sync: DEGRADED \nMemory Drift: 12.7% \n\nWarning: Drift exceeds recommended limits";

                if (!ItemsReadState.Instance.statusReadPres)
                {
                    ItemsReadState.Instance.statusReadPres = true;
                }
                break;
            case "history":
                response = "\nSystem Event History \n\n[02/15/1993 11:58:21] System boot \n[02/15/1993 12:01:04] Calibration complete \n[02/15/1993 12:39:55] Memory scan initiated";
                response += "\n[02/15/1998 12:43:18] Temporal variance spike detected \n[02/15/1998 12:43:18] Event unresolved";

                if (!ItemsReadState.Instance.historyReadPres)
                {
                    ItemsReadState.Instance.historyReadPres = true;
                }
                break;
            case "diagnose":
                response = "\nDiagnostics Report \nMemory Integrity: DEGRADED \nTemporal Alignment: UNSTABLE \nError Rate: 14.6%";
                response += "\n\nWarning: Continuing operation may cause memory bleed";

                if (!ItemsReadState.Instance.diagnoseReadPres)
                {
                    ItemsReadState.Instance.diagnoseReadPres = true;
                }
                break;
            case "exit":
                response = "\nSession terminated";
                break;
            default:
                response = "\nInvalid command...";
                break;

        }

        return response;
    }

    string PastTerminalResponse(string input)
    {
        string response = "";

        switch (input)
        {
            case "help":
                response = "\nAvailable commands: \nhelp \nstatus \nhistory \ndiagnose \nexit";
                break;
            case "status":
                response = "\nSystem Status: ONLINE \nTemporal Sync: STABLE \nMemory Drift: 0.02%";

                if (!ItemsReadState.Instance.statusReadPast)
                {
                    ItemsReadState.Instance.statusReadPast = true;
                }
                break;
            case "history":
                response = "\nSystem Event History \n\n[02/15/1993 11:58:21] System boot \n[02/15/1993 12:01:04] Calibration complete \n[02/15/1993 12:39:55] Memory scan initiated";
                response += "\n\nNo critical events recorded";

                if (!ItemsReadState.Instance.historyReadPast)
                {
                    ItemsReadState.Instance.historyReadPast = true;
                }
                break;
            case "diagnose":
                response = "\nDiagnostics Report \nMemory Integrity: OK \nTemporal Alignment: OK \nError Rate: 0.01% \n\nNo action required";

                if (!ItemsReadState.Instance.diagnoseReadPast)
                {
                    ItemsReadState.Instance.diagnoseReadPast = true;
                }
                break;
            case "exit":
                response = "\nSession terminated";
                break;
            default:
                response = "\nInvalid command...";
                break;

        }

        return response;
    }

    string CorruptedTerminalResponse(string input)
    {
        string response = "";

        switch (input)
        {
            case "help":
                response = "\nAvailable commands: \nhelp \nstatus \nhistory \ndiagnose \nexit";
                break;
            case "status":
                response = "\nSystem Status: RUNNING \nTemporal Sync: FAILED \nMemory Drift: 68.9% \n\nRecommendation: TERMINATE SESSION";
                
                if (!ItemsReadState.Instance.statusReadCorr)
                {
                    ItemsReadState.Instance.statusReadCorr = true;
                }
                break;
            case "history":
                response = "\nSystem Event History \n\n[02/15/1993 11:58:21] System boot \n[02/15/1998 11:58:21] System boot \n[02/15/1993 12:43:18] Temporal variance spike detected";
                response += "\n[02/15/1998 12:43:18] Temporal variance spike detected \n[02/15/1998 12:43:18] Temporal variance spike detected";

                if (!ItemsReadState.Instance.historyReadCorr)
                {
                    ItemsReadState.Instance.historyReadCorr = true;
                }
                break;
            case "diagnose":
                response = "\nDiagnostics Report \nMemory Integrity: UNKNOWN \nTemporal Alignment: FAILED \nError Rate: ___% \n\nRecommendation: _________ _______";

                if (!ItemsReadState.Instance.diagnoseReadCorr)
                {
                    ItemsReadState.Instance.diagnoseReadCorr = true;
                }
                break;
            case "exit":
                response = "\nUnable to terminate";
                break;
            default:
                response = "\nInvalid command...";
                break;

        }

        return response;
    }
}
