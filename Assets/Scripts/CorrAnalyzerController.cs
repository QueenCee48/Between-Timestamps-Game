using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrAnalyzerController : MonoBehaviour
{
    public RectTransform pastBar;
    public RectTransform presBar;
    public RectTransform corrBar;

    public RectTransform pastBarBG;
    public RectTransform presBarBG;
    public RectTransform corrBarBG;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBar(
            pastBar,
            pastBarBG,
            ItemsReadState.Instance.pastIndex,
            ItemsReadState.Instance.pastThreshold
        );

        UpdateBar(
            presBar,
            presBarBG,
            ItemsReadState.Instance.presentIndex,
            ItemsReadState.Instance.presentThreshold
        );

        UpdateBar(
            corrBar,
            corrBarBG,
            ItemsReadState.Instance.corruptionIndex,
            ItemsReadState.Instance.corruptionThreshold
        );
    }

    void UpdateBar(RectTransform bar, RectTransform bg, float index, float threshold)
    {
        float percent = Mathf.Clamp01(index / threshold);
        float fullWidth = bg.rect.width;

        bar.SetSizeWithCurrentAnchors(
            RectTransform.Axis.Horizontal,
            fullWidth * percent
        );
    }
}
