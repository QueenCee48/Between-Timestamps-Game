using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AssignmentController : MonoBehaviour, IPointerClickHandler
{
    private WndwAreaCntrlr wndwAreaCntrlr;

    void Awake()
    {
        wndwAreaCntrlr = GameObject.Find("WindowArea").GetComponent<WndwAreaCntrlr>();
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
        OpenAssignmentWindow();
    }

    public void OpenAssignmentWindow()
    {
        string appName = gameObject.name;
        wndwAreaCntrlr.OpenWindow(appName);
    }
}
