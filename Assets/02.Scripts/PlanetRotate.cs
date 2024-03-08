using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotate : MonoBehaviour
{
    public float RotSpeed = 10f;
    public Transform tr;
    void Start()
    {
        tr = transform;
    }
    void Update()
    {
        tr.Rotate(0f,Time.deltaTime * RotSpeed, 0f);

    }
}
