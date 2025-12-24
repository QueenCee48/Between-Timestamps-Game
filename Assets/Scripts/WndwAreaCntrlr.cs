using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WndwAreaCntrlr : MonoBehaviour
{
    public GameObject windowPrefab;
    public Sprite presWindow;
    public Sprite pastWindow;
    public Sprite corrWindow;

    Sprite presImage;
    Sprite pastImage;
    Sprite corrImage;

    public GameObject[] openWindows;
    public GameObject[] openFiles;

    TimeController timeCntrlr;
    WindowController windowCntrlr;
    TxtFileController txtFileCntrlr;

    GameObject newWindow;
    GameObject newFile;

    public GameObject fileExpPresContent;
    public GameObject fileExpPastContent;
    public GameObject fileExpCorrContent;

    public GameObject msgsPresContent;
    public GameObject msgsPastContent;
    public GameObject msgsCorrContent;

    public GameObject notesContent;

    public GameObject photosPresContent;
    public GameObject photosPastContent;
    public GameObject photosCorrContent;

    string lastLayer;

    // Start is called before the first frame update
    void Start()
    {
        timeCntrlr = GameObject.Find("TimeControls").GetComponent<TimeController>();
        lastLayer = timeCntrlr.currentLayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCntrlr.currentLayer != lastLayer)
        {
            UpdateWindows();
            UpdateFiles();
            lastLayer = timeCntrlr.currentLayer;
        }
    }

    public void OpenWindow(string appName)
    {
        newWindow = Instantiate(windowPrefab, transform);
        windowCntrlr = newWindow.GetComponent<WindowController>();
        
        if (timeCntrlr.IsInPresent())
        {
            newWindow.GetComponent<Image>().sprite = presWindow;
        }
        else if (timeCntrlr.IsInPast())
        {
            newWindow.GetComponent<Image>().sprite = pastWindow;
        }
        else if (timeCntrlr.IsInCorrupt())
        {
            newWindow.GetComponent<Image>().sprite = corrWindow;
        }
    
        switch (appName)
        {
            case "FileExplorer":
                windowCntrlr.SetTitle("File Explorer");
                windowCntrlr.SetWindowContent(fileExpPresContent, fileExpPastContent, fileExpCorrContent, timeCntrlr);
                break;
            case "Notes":
                windowCntrlr.SetTitle("Notes");
                windowCntrlr.SetWindowContent(notesContent, notesContent, notesContent, timeCntrlr);
                break;
            case "Photos":
                windowCntrlr.SetTitle("Photos");
                windowCntrlr.SetWindowContent(photosPresContent, photosPastContent, photosCorrContent, timeCntrlr);
                break;
            case "Terminal":
                windowCntrlr.SetTitle("Terminal");
                break;
            case "TalkGPT":
                windowCntrlr.SetTitle("TalkGPT");
                break;
            case "Trash":
                windowCntrlr.SetTitle("Trash");
                break;
            case "Messages":
                windowCntrlr.SetTitle("Messages");
                windowCntrlr.SetWindowContent(msgsPresContent, msgsPastContent, msgsCorrContent, timeCntrlr);
                break;
            case "CorruptionAnalyzer":
                windowCntrlr.SetTitle("Corruption Analyzer");
                break;
        }
    }

    void UpdateWindows()
    {
        openWindows = GameObject.FindGameObjectsWithTag("Window");

        if (openWindows != null)
        {
            foreach (GameObject window in openWindows)
            {
                if (timeCntrlr.IsInPresent())
                {
                    window.GetComponent<Image>().sprite = presWindow;
                }
                else if (timeCntrlr.IsInPast())
                {
                    window.GetComponent<Image>().sprite = pastWindow;
                }
                else if (timeCntrlr.IsInCorrupt())
                {
                    window.GetComponent<Image>().sprite = corrWindow;
                }

                string appName = window.GetComponent<WindowController>().titleText.text;

                switch (appName)
                {
                    case "File Explorer":
                        window.GetComponent<WindowController>().SetWindowContent(fileExpPresContent, fileExpPastContent, fileExpCorrContent, timeCntrlr);
                        break;
                    case "Notes":
                        window.GetComponent<WindowController>().SetWindowContent(notesContent, notesContent, notesContent, timeCntrlr);
                        break;
                    case "Photos":
                        window.GetComponent<WindowController>().SetWindowContent(photosPresContent, photosPastContent, photosCorrContent, timeCntrlr);
                        break;
                    case "Terminal":
                        break;
                    case "TalkGPT":
                        break;
                    case "Trash":
                        break;
                    case "Messages":
                        window.GetComponent<WindowController>().SetWindowContent(msgsPresContent, msgsPastContent, msgsCorrContent, timeCntrlr);
                        break;
                    case "Corruption Analyzer":
                        break;
                }
            }
        }
    }

    public void OpenFile(GameObject txtFile, Sprite presImg, Sprite pastImg, Sprite corrImg)
    {
        newFile = Instantiate(txtFile, transform);

        txtFileCntrlr = newFile.GetComponent<TxtFileController>();

        txtFileCntrlr.presImage = presImg;
        txtFileCntrlr.pastImage = pastImg;
        txtFileCntrlr.corrImage = corrImg;

        txtFileCntrlr.UpdateFile();
        
        if (timeCntrlr.IsInPresent() && presImage != null)
        {
            newFile.GetComponent<Image>().sprite = presImage;
        }
        else if (timeCntrlr.IsInPast() && pastImage != null)
        {
            newFile.GetComponent<Image>().sprite = pastImage;
        }
        else if (timeCntrlr.IsInCorrupt() && corrImage != null)
        {
            newFile.GetComponent<Image>().sprite = corrImage;
        }
    }

    void UpdateFiles() 
    {
        openFiles = GameObject.FindGameObjectsWithTag("TxtFile");

        if (openFiles != null)
        {
            foreach (GameObject file in openFiles)
            {
                file.GetComponent<TxtFileController>().UpdateFile();
            }
        }
    }


    
}
