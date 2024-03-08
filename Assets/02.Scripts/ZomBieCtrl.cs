using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//플레이어 위치랑 자기자신 위치가 있어야 한다.
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
        // 좁비가 죽었다면     업데이트로직을 빠져나감
        // 이 코드 밑으로 내려 가지 않고 빠져 나간다.

       float dist = Vector3.Distance(zombieTr.position, playerTr.position);
       if(dist <= attackDist)
        {
            Vector3 targetNomal = playerTr.position - zombieTr.position;

                                 //곡면 회전보간   ,자기자신, 타겟방향 , 속도         
            zombieTr.rotation = Quaternion.Slerp(zombieTr.rotation,
                Quaternion.LookRotation(targetNomal), Time.deltaTime * 10f);
                //벡터값을 회전값으로 변경 함수
            animator.SetBool("IsAttack", true);
            navi.isStopped = true; //추적 중지
        }
        else if(dist <= traceDist)
        {  
            // 네비의  추적 대상은  플레이어가 된다.
            navi.destination = playerTr.position;
            navi.isStopped = false; //추적 시작
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
