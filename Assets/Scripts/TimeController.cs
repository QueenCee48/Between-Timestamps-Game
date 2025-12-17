using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    Image corruptButton;
    Image presentButton;
    Image pastButton;

    Image corruptDesktop;
    Image presentDesktop;
    Image pastDesktop;

    bool isOpen;
    bool inPast;
    bool inPresent;
    bool inCorrupt;

    public string currentLayer;

    // Start is called before the first frame update
    void Start()
    {
        corruptButton = GameObject.Find("CorruptButton").GetComponent<Image>();
        presentButton = GameObject.Find("PresentButton").GetComponent<Image>();
        pastButton = GameObject.Find("PastButton").GetComponent<Image>();

        corruptDesktop = GameObject.Find("CorruptDesktop").GetComponent<Image>();
        presentDesktop = GameObject.Find("PresentDesktop").GetComponent<Image>();
        pastDesktop = GameObject.Find("PastDesktop").GetComponent<Image>();

        isOpen = false;
        inPast = false;
        inPresent = true;
        inCorrupt = false;

        currentLayer = "Present";

        TurnOffButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerButtons() {
        if (Time.timeScale != 0) {
            if (!isOpen) {
                TurnOnButtons();
            }
            else {
                TurnOffButtons();
            }
        }
    }

    public void GoToPast() {
        if (!inPast && Time.timeScale != 0) {
            pastDesktop.enabled = true;
            presentDesktop.enabled = false;
            corruptDesktop.enabled = false;
            inPast = true;
            inPresent = false;
            inCorrupt = false;
            currentLayer = "Past";
        }
    }

    public void GoToPresent() {
        if (!inPresent && Time.timeScale != 0) {
            pastDesktop.enabled = false;
            presentDesktop.enabled = true;
            corruptDesktop.enabled = false;
            inPresent = true;
            inPast = false;
            inCorrupt = false;
            currentLayer = "Present";
        }
    }

    public void GoToCorrupt() {
        if (!inCorrupt && Time.timeScale != 0) {
            pastDesktop.enabled = false;
            presentDesktop.enabled = false;
            corruptDesktop.enabled = true;
            inCorrupt = true;
            inPast = false;
            inPresent = false;
            currentLayer = "Corrupt";
        }
    }

    void TurnOnButtons() {
        corruptButton.enabled = true;
        presentButton.enabled = true;
        pastButton.enabled = true;
        isOpen = true;
    }

    void TurnOffButtons() {
        corruptButton.enabled = false;
        presentButton.enabled = false;
        pastButton.enabled = false;
        isOpen = false;
    }

    public bool IsInPast()
    {
        return inPast;
    }

    public bool IsInPresent()
    {
        return inPresent;
    }

    public bool IsInCorrupt()
    {
        return inCorrupt;
    }
}
