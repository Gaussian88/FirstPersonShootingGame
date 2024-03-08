using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//1.����Ʈ�� ǥ���� ����ũ ������Ʈ 
//2.������ҽ� ����� Ŭ��
//3. �Ѿ� �±�  
public class FireEffect : MonoBehaviour
{
    public GameObject Spark;
    public AudioSource source;
    public AudioClip effectSfx;
    public string bulletTag = "BULLET";
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {     
        if(col.collider.CompareTag(bulletTag))
        {
            Destroy(col.gameObject);
            var spk =Instantiate(Spark,col.transform.position,
                Quaternion.identity);
            Destroy(spk,1.0f);
            source.PlayOneShot(effectSfx, 1.0f);
        }
       
    }

}
