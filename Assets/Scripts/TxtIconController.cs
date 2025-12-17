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

    WndwAreaCntrlr wndwAreaCntrlr2;

    void Awake()
    {
        wndwAreaCntrlr2 = GameObject.Find("WindowArea").GetComponent<WndwAreaCntrlr>();
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
        wndwAreaCntrlr2.OpenFile(txtFilePrefab, presImg, pastImg, corrImg);
    }

}
