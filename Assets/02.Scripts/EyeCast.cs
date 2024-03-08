using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeCast : MonoBehaviour
{
    Transform tr;
    CrossHair _crossHair;
    Ray ray;
    RaycastHit hit;
    private readonly string skeletonTag = "SKELETON";
    private readonly string monsterTag = "MONSTER";
    private readonly string zombieTag = "ZOMBIE";

    void Start()
    {
        tr = transform;
        _crossHair = GameObject.Find("Panel-CrossHair").GetComponent<CrossHair>();
    }
    void Update()
    {
        ray = new Ray(tr.position, tr.forward);
        Debug.DrawRay(ray.origin, ray.direction *25f,Color.blue);
        if(Physics.Raycast(tr.position,tr.forward,out hit,25f))
        {
            if(hit.collider.CompareTag(monsterTag)||
                hit.collider.CompareTag(zombieTag) ||
                hit.collider.CompareTag(skeletonTag))
            {
                _crossHair.isGaze = true;
            }
            else
            {
                _crossHair.isGaze=false;
            }
        }
    }
}
