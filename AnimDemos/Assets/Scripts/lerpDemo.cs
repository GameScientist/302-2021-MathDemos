using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDemo : MonoBehaviour
{

    public GameObject objectStart;
    public GameObject objectEnd;

    [Range(-1, 2)] public float percent = 0;

    public float animationLength = 2;
    private float animationPlayheadTime = 0;
    private bool isAnimPlaying = false;

    public AnimationCurve animationCurve;

    public float getCurrentPercent
    {
        get
        {
            return animationPlayheadTime / animationLength;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isAnimPlaying)
        {
            // move playhead forward:
            animationPlayheadTime += Time.deltaTime;
            // calc new value for percent
            percent = getCurrentPercent;
            // clamp in 0 to 1 range:
            percent = Mathf.Clamp(percent, 0, 1);

            float p = animationCurve.Evaluate(percent);

            //percent = percent * percent * (3 -2 * percent); // speeds up, then slows down
            // move objects to lerped position:
            DoTheLerp(p);
            // stop playing
            if (percent >= 1) isAnimPlaying = false;
        }
    }

    public void DoTheLerp(float p)
    {
        transform.position = AnimMath.Lerp(
            objectStart.transform.position,
            objectEnd.transform.position,
            p);
    }

    public void PlayTweenAnim()
    {
        isAnimPlaying = true;
        animationPlayheadTime = 0;
    }

    private void OnValidate()
    {
        DoTheLerp(percent);
    }
}
