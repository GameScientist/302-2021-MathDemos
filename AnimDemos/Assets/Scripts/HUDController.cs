using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    public static float timeScale = 1;
    public LerpDemo lerper;
    
    public TMP_Text textTimeScale;

    public Slider sliderLerp;

    // Start is called before the first frame update
    void Start()
    {
        SliderTimeUpdated(1);
    }

    // Update is called once per frame
    void Update()
    {
        float p = lerper.getCurrentPercent;

        sliderLerp.SetValueWithoutNotify(p);
    }

    public void SliderTimeUpdated(float amt)
    {
        HUDController.timeScale = amt;
        textTimeScale.text = System.Math.Round(timeScale, 2).ToString();
    }

    public void SliderLerpUpdated(float amt)
    {
        lerper.DoTheLerp(amt);
    }
}
