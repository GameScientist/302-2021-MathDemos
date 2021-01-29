using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class GenerateRing : MonoBehaviour
{
    [Range(10, 60)] public int num = 10;
    [Range(3, 20)] public float radius = 5;
    LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePath();
    }

    void OnValidate()
    {
        GeneratePath();
    }

    private void GeneratePath()
    {
        line = GetComponent<LineRenderer>();

        // generate a bunch of points!
        int num = 0;
        float dis = 0;
        float rad = 0;

        Vector3[] pts = new Vector3[num];

        for (int i = 0; i < 10; i++)
        {
            pts[i] = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad)) * radius;
            rad += Mathf.PI * 2 / num;
        }
        line.positionCount = num;
        line.SetPositions(pts);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
