using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed = 2500f;
    public int damage = 34;
    void Start()
    {
      
        rb = GetComponent<Rigidbody>();
                   //로컬방향 전방  * 스피드
        rb.AddForce(transform.forward * Speed);
        //리지디바디 클래스에 AddForce라는 함수가 존재
        //리지디바디의 힘과 방향에 의해 움직인다.
        Destroy(gameObject, 3f);
    }
}
