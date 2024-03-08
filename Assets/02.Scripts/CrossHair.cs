using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHair : MonoBehaviour
{
    [SerializeField] private Transform tr;
    [SerializeField] private Image crosshair;
    private float startTime;
    private float duration = 0.2f;
    public float minSize = 0.8f;
    public float maxSize = 1.4f;
    Color originColor = new Color(1f,1f,1f,0.8f);
    Color gazeColor = Color.red;
    public bool isGaze = false;
    
    void Start()
    {
        tr = GetComponent<Transform>();
        crosshair = GetComponent<Image>();
        crosshair.color = originColor;
        tr.localScale = Vector3.one * minSize;
        startTime = Time.time;
    }
    void Update()
    {
        if(isGaze ==true)
        {
           float t = (Time.time - startTime)/duration;
            tr.localScale = Vector3.one * Mathf.Lerp(minSize, maxSize, t );
            crosshair.color = gazeColor;
        }
        else
        {
            tr.localScale = Vector3.one * minSize;
            crosshair.color = originColor;
            startTime = Time.time;
        }
    }
}
