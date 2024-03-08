using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameScore : MonoBehaviour
{
    public Text KillScoreTXT;
       
  
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        KillScoreTXT =GameObject.Find("Panel-End").transform.GetChild(2).GetComponent<Text>();
        KillScoreTXT.text ="KILL : "+ GameManager.instance.totalScore.ToString();
    }

}
