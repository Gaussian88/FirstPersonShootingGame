using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
      //전역 변수 
    public static GameManager instance;
    public bool isGameOver = false;
    public GameObject skeletonPrefab;
    public GameObject monterPrefab;
    public GameObject zombiePrefab;
    public Transform[] Points;  //배열(하나 이상을 저장한다)
    public Text killTXT;
    public int totalScore = 0;
    private float timePrev1;
    private float timePrev2;
    private float timePrev3;
    private string zombieTag = "ZOMBIE";
    private string monsterTag = "MONSTER";
    private string skeletonTag = "SKELETON";
    private int maxCount = 5;
    void Start()
    {
        instance = this;
        timePrev1 = Time.time;
        timePrev2 = Time.time;
        timePrev3 = Time.time;
    }
    void Update()
    {
        if (isGameOver == true) return;

        if(Time.time - timePrev1 >= 2.5f)
        {
            int zombieCount = (int)GameObject.FindGameObjectsWithTag(zombieTag).Length;
            if (zombieCount < maxCount)
            {

                int idx = Random.Range(0, Points.Length);
                Instantiate(zombiePrefab, Points[idx].position,
                    Points[idx].rotation);
            }
            timePrev1= Time.time;
        }
        if (Time.time - timePrev2 >= 3f)
        {
            int monsterCount = (int)GameObject.FindGameObjectsWithTag(monsterTag).Length;
            if (monsterCount < maxCount)
            {

                int idx = Random.Range(0, Points.Length);
                Instantiate(monterPrefab, Points[idx].position,
                    Points[idx].rotation);
            }
            timePrev2 = Time.time;
        }
        if (Time.time - timePrev3 >= 5f)
        {
            int skeletonCount = (int)GameObject.FindGameObjectsWithTag(skeletonTag).Length;
            if (skeletonCount < maxCount)
            {

                int idx = Random.Range(0, Points.Length);
                Instantiate(skeletonPrefab, Points[idx].position,
                    Points[idx].rotation);
            }
            timePrev3 = Time.time;
        }
    }
    public void KillScore(int score)
    {
        totalScore += score;

        killTXT.text = "KILL :" + totalScore.ToString("000");
    }
}
