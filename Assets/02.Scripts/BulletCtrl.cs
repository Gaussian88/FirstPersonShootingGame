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
                   //���ù��� ����  * ���ǵ�
        rb.AddForce(transform.forward * Speed);
        //������ٵ� Ŭ������ AddForce��� �Լ��� ����
        //������ٵ��� ���� ���⿡ ���� �����δ�.
        Destroy(gameObject, 3f);
    }
}
