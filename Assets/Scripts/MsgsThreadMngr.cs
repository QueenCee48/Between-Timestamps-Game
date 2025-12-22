using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgsThreadMngr : MonoBehaviour
{
    public MsgsController currentThread;
    public MsgsContentController msgsContentCntrlr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectThread(MsgsController thread)
    {
        if (currentThread != null)
        {
            currentThread.SetUnselected();
        }

        currentThread = thread;
        currentThread.SetSelected();

        if (thread.gameObject.name == "ValeThread")
        {
            msgsContentCntrlr.DisplayValeConvo();
        }
        else if (thread.gameObject.name == "EvanThread")
        {
            msgsContentCntrlr.DisplayEvanConvo();
        }
    }
}
