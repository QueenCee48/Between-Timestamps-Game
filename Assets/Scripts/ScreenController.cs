using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour
{
    Image logoScreen;

    bool logoScreenOn;

    // Start is called before the first frame update
    void Start()
    {
        logoScreen = GameObject.Find("LogoScreen").GetComponent<Image>();
        TurnOnLogoScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TurnOnLogoScreen()
    {
        logoScreen.enabled = true;
        Time.timeScale = 0;
        logoScreenOn = true;
    }

    public void TurnOffLogoScreen()
    {
        logoScreen.enabled = false;
        Time.timeScale = 1;
        logoScreenOn = false;
    }

    public bool IsLogoScreenOn()
    {
        return logoScreenOn;
    }
}
