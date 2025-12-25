using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgsContentController : MonoBehaviour
{
    public GameObject valeConvoPrefab;
    public GameObject evanConvoPrefab;
    public GameObject projSummPrefab;
    public GameObject profReflPrefab;
    public GameObject tempErasPrefab;

    public ScrollRect scrollRect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SnapToBottom()
    {
        yield return null;
        scrollRect.verticalNormalizedPosition = 0f;
    }

    public void DisplayValeConvo()
    {
        HideEvanConvo();

        GameObject convo = Instantiate(valeConvoPrefab, transform);

        StartCoroutine(SnapToBottom());
    }

    public void HideValeConvo()
    {
        GameObject currentValeConvo = GameObject.FindWithTag("ValeConvo");

        if (currentValeConvo != null)
        {
            Destroy(currentValeConvo);
        }
    }

    public void DisplayEvanConvo()
    {
        HideValeConvo();

        GameObject convo = Instantiate(evanConvoPrefab, transform);

        StartCoroutine(SnapToBottom());
    }

    public void HideEvanConvo()
    {
        GameObject currentEvanConvo = GameObject.FindWithTag("EvanConvo");

        if (currentEvanConvo != null)
        {
            Destroy(currentEvanConvo);
        }
    }

    public void DisplayProjSumm()
    {
        HideProfRefl();
        HideTempEras();

        GameObject convo = Instantiate(projSummPrefab, transform);

        StartCoroutine(SnapToBottom());
    }

    public void HideProjSumm()
    {
        GameObject currentProjSumm = GameObject.FindWithTag("ProjSumm");

        if (currentProjSumm != null)
        {
            Destroy(currentProjSumm);
        }
    }

    public void DisplayProfRefl()
    {
        HideProjSumm();
        HideTempEras();

        GameObject convo = Instantiate(profReflPrefab, transform);

        StartCoroutine(SnapToBottom());
    }

    public void HideProfRefl()
    {
        GameObject currentProfRefl = GameObject.FindWithTag("ProfRefl");

        if (currentProfRefl != null)
        {
            Destroy(currentProfRefl);
        }
    }

    public void DisplayTempEras()
    {
        HideProjSumm();
        HideProfRefl();

        GameObject convo = Instantiate(tempErasPrefab, transform);

        StartCoroutine(SnapToBottom());
    }

    public void HideTempEras()
    {
        GameObject currentTempEras = GameObject.FindWithTag("TempEras");

        if (currentTempEras != null)
        {
            Destroy(currentTempEras);
        }
    }
}
