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
        //���ʸ��콺 ��ư�� �����ٸ� 
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
    IEnumerator FastBullet() // 0.1�ʸ��� �Ѿ� �߻� 
    {       //�����ڰ� �ٸ� ��� Ȥ�� �ٸ� ��������  ������� �Ҷ�
            // �̷��� ��ŸƮ �ڷ�ƾ�� ����. ���� �ð� Ÿ������ ����� �ݺ�
        Fire();
        yield return new WaitForSeconds(0.1f);
        Fire();
        yield return new WaitForSeconds(0.1f);
        Fire();
        yield return new WaitForSeconds(0.1f);
        Fire();
        //���ϴ� �ð��뿡 �Լ��� ȣ��
        Invoke("MuzzleFalashDisable", 0.15f);
                // �Լ���           , 0.15���� ȣ��
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
        //������ �ִϸ��̼� ���� 
        yield return new WaitForSeconds(0.5f);
        isReload = false;
        bulletCount = maxBullet;
        bulletTxt.text = "<color=#ff0000>" + bulletCount.ToString() + "</color>" + " / " + maxBullet.ToString();
    }
}
