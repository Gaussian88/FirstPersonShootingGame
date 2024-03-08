using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireCtrl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePos;
    public Animation CombatSG;
    public AudioClip fireSound;
    public AudioSource source;
    public Text bulletTxt;
    public ParticleSystem MuzzleFlash;
    public  HandCtrl handCtrl;
    int bulletCount = 0;
    int maxBullet = 10;
    bool isReload = false;
    void Start()
    {
        handCtrl = GetComponent<HandCtrl>();
        bulletCount = maxBullet;
        MuzzleFlash.Stop();
    }
    void Update()
    {         
        //왼쪽마우스 버튼을 눌렀다면 
        if(Input.GetMouseButtonDown(0)&&!isReload)
        {
            
            if (handCtrl.isHaveM4A1 == false)
                Fire();
            else if(handCtrl.isHaveM4A1 == true)
                StartCoroutine(FastBullet());

           
        }
        else if(Input.GetMouseButtonUp(0))
        {
            MuzzleFlash.Stop();

        }
    }
    private void Fire()
    {
        if (isReload==true|| handCtrl.isRun ==true) return; 
        --bulletCount;
        Instantiate(bulletPrefab, firePos.position,
            firePos.rotation);
        CombatSG.Play("fire");
        MuzzleFlash.Play();
        source.PlayOneShot(fireSound, 1.0f);
        if (bulletCount == 0)
        {
            StartCoroutine(Reloading());
        }
        bulletTxt.text ="<color=#ff0000>"+bulletCount.ToString()+"</color>" + " / " + maxBullet.ToString();

    }
    IEnumerator FastBullet() // 0.1초마다 총알 발사 
    {       //개발자가 다른 장면 혹은 다른 프레임을  만들고자 할때
            // 이렇케 스타트 코루틴을 쓴다. 여러 시간 타임으로 기능을 반복
        Fire();
        yield return new WaitForSeconds(0.1f);
        Fire();
        yield return new WaitForSeconds(0.1f);
        Fire();
        yield return new WaitForSeconds(0.1f);
        Fire();
        //원하는 시간대에 함수를 호출
        Invoke("MuzzleFalashDisable", 0.15f);
                // 함수명           , 0.15초후 호출
    }
    void MuzzleFalashDisable()
    {
        MuzzleFlash.Stop();
    }
    IEnumerator Reloading()
    {
        MuzzleFlash.Stop();
        isReload = true;
        CombatSG.Play("pump3");
        //재장전 애니메이션 실행 
        yield return new WaitForSeconds(0.5f);
        isReload = false;
        bulletCount = maxBullet;
        bulletTxt.text = "<color=#ff0000>" + bulletCount.ToString() + "</color>" + " / " + maxBullet.ToString();
    }
}
