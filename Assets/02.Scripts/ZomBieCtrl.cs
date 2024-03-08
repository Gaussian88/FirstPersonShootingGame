using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//�÷��̾� ��ġ�� �ڱ��ڽ� ��ġ�� �־�� �Ѵ�.
public class ZomBieCtrl : MonoBehaviour
{
    public NavMeshAgent navi;
    public Animator animator;
    public Transform zombieTr;
    public float attackDist = 3f;
    public float traceDist = 15f;
    public Transform playerTr;
    public ZomBieDamage damage;
    void Start()
    {
        playerTr = GameObject.FindWithTag("Player").transform;
        navi = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        zombieTr = GetComponent<Transform>();
        damage = GetComponent<ZomBieDamage>();
    }
    void Update()
    {
        if (damage.isDie == true) return;
        // ���� �׾��ٸ�     ������Ʈ������ ��������
        // �� �ڵ� ������ ���� ���� �ʰ� ���� ������.

       float dist = Vector3.Distance(zombieTr.position, playerTr.position);
       if(dist <= attackDist)
        {
            Vector3 targetNomal = playerTr.position - zombieTr.position;

                                 //��� ȸ������   ,�ڱ��ڽ�, Ÿ�ٹ��� , �ӵ�         
            zombieTr.rotation = Quaternion.Slerp(zombieTr.rotation,
                Quaternion.LookRotation(targetNomal), Time.deltaTime * 10f);
                //���Ͱ��� ȸ�������� ���� �Լ�
            animator.SetBool("IsAttack", true);
            navi.isStopped = true; //���� ����
        }
        else if(dist <= traceDist)
        {  
            // �׺���  ���� �����  �÷��̾ �ȴ�.
            navi.destination = playerTr.position;
            navi.isStopped = false; //���� ����
            animator.SetBool("IsTrace", true);
            animator.SetBool("IsAttack", false);
        }
        else
        {
            navi.isStopped = true;
            animator.SetBool("IsTrack", false);

        }


    }
}
