using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenController : MonoBehaviour
{
    Image logoScreen;
    public Image endingScreen;

    public Text endingText;
    public Text endingTitle;
    public Text playAgainText;

    public Sprite completeEndingBG;
    public Sprite corruptedEndingBG;
    public Sprite partialEndingBG;

    bool logoScreenOn;
    bool endingScreenOn;

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

    public void SubmitReport()
    {
        if (!logoScreenOn) {
            endingScreen.enabled = true;
            Time.timeScale = 0;
            endingScreenOn = true;

            if (ItemsReadState.Instance.endingTitle == "Ending: ARCHIVE SECURED")
            {
                endingScreen.sprite = completeEndingBG;
            }
            else if (ItemsReadState.Instance.endingTitle == "Ending: TOTAL DATA LOSS")
            {
                endingScreen.sprite = corruptedEndingBG;
            }
            else if (ItemsReadState.Instance.endingTitle == "Ending: TEMPORAL CONTAINMENT: PRESENT" || ItemsReadState.Instance.endingTitle == "Ending: PARTIAL CONTAINMENT" ||
                        ItemsReadState.Instance.endingTitle == "Ending: TEMPORAL CONTAINMENT: PAST" || ItemsReadState.Instance.endingTitle == "Ending: ERODED FOUNDATIONS" ||
                        ItemsReadState.Instance.endingTitle == "Ending: STABLE, BUT INCOMPLETE" || ItemsReadState.Instance.endingTitle == "Ending: MISALIGNED EXTRACTION" ||
                        ItemsReadState.Instance.endingTitle == "Ending: ASSIGNMENT FAILED")
            {
                endingScreen.sprite = partialEndingBG;
            }

            endingScreen.type = Image.Type.Tiled;
            endingScreen.pixelsPerUnitMultiplier = 0.04f;
            playAgainText.enabled = true;
            endingTitle.enabled = true;
            endingText.enabled = true;
            endingTitle.text = ItemsReadState.Instance.endingTitle;
            endingText.text = ItemsReadState.Instance.endingText;
            
        }
    }

    public void PlayAgain()
    {
        if (!logoScreenOn && endingScreenOn) {
            SceneManager.LoadScene("Game");
        }
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
