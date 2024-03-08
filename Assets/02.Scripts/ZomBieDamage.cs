using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZomBieDamage : MonoBehaviour
{
    public Animator animator;
    public Transform zombieTr;
    public GameObject BloodEffect;
    public Image HpBar;
    public Text hpTXT;
    public Canvas canvas;
    public BoxCollider attackTrigger;
    private int hp = 0;
    private int hpMax = 100;
    private string bulletTag = "BULLET";
    private string playerTag = "Player";
    public bool isDie = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        zombieTr = GetComponent<Transform>();
       attackTrigger = transform.GetChild(19).GetComponent<BoxCollider>();
       hp = hpMax;
        HpBar.color = Color.green;
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag(playerTag))
        {
            GetComponent<Rigidbody>().mass = 200f;
            GetComponent<Rigidbody>().isKinematic = true;
        }
        if(col.gameObject.CompareTag(bulletTag))
        {
            Destroy(col.gameObject);
            animator.SetTrigger("HitTrigger");
            CreateBlood(col);
            hp -= col.gameObject.GetComponent<BulletCtrl>().damage;
            hp = Mathf.Clamp(hp, 0, 100);
            HpBar.fillAmount = (float)hp /(float)hpMax;

            if (HpBar.fillAmount <= 0.3f)
                HpBar.color = Color.red;
            else if (HpBar.fillAmount <= 0.5f)
                HpBar.color = Color.yellow;

            hpTXT.text = "HP : " + hp.ToString();
            if(hp <= 0)
            {
                Die();
            }

        }



    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag(playerTag))
        {
            GetComponent<Rigidbody>().mass = 75f;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    void Die()
    {
        isDie = true;
        animator.SetTrigger("DieTrigger");
        GetComponent<CapsuleCollider>().enabled = false;
        // 캡슐콜라이더를 비활성화 
        canvas.enabled = false;
        Destroy(this.gameObject, 5f);
        GameManager.instance.KillScore(1);
    }
    private void CreateBlood(Collision col)
    {
        var blood = Instantiate(BloodEffect, col.transform.position,
                        Quaternion.identity);
        Destroy(blood, 1f);
    }
    public void AttackColliderEnable()
    {

        attackTrigger.enabled = true;

    }
    public void AttackTriggerDisable()
    {
        attackTrigger.enabled = false;
    }
}
