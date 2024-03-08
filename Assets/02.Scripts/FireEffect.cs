using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//1.이펙트를 표현할 스파크 오브젝트 
//2.오디오소스 오디오 클립
//3. 총알 태그  
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
