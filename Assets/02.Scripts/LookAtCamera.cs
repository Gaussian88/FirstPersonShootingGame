using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public RectTransform CanvasTr;
    public Transform cameraTr;
    void Start()
    {
        CanvasTr = GetComponent<RectTransform>();
        cameraTr = Camera.main.transform;
    }
    void Update()
    {
        CanvasTr.LookAt(cameraTr);
    }
}
