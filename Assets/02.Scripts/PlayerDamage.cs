using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerDamage : MonoBehaviour
{
    public Image HpBar;
    public Text hpTXT;
    private string punchTag1 = "Z_PUNCH";
    private int hp = 0;
    private int hpMax = 100;
    public GameObject sceneChangeImg;
    void Start()
    {
        sceneChangeImg = GameObject.Find("Canvas-UI").transform.GetChild(4).gameObject;

        HpBar = GameObject.Find("Panel-Hp").transform.GetChild(0).GetComponent<Image>();
        //하이라키에서 Panel-Hp 오브젝트명을 찾고 첫번재 하위 이미지 컴퍼넌트를 찾는다.
        hpTXT = GameObject.Find("Panel-Hp").transform.GetChild(1).GetComponent<Text>();
        HpBar.color = Color.green;
        hp = hpMax;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(punchTag1))
        {
            hp -= 5;
            hp = Mathf.Clamp(hp, 0, 100);
            HpBar.fillAmount = (float)hp/(float)hpMax;
            if (HpBar.fillAmount <= 0.3f)
                HpBar.color = Color.red;
            else if (HpBar.fillAmount <= 0.5f)
                HpBar.color = Color.yellow;
            if(hp<=0f)
            {
                GameManager.instance.isGameOver = true;
                Invoke("PlayerDie",3.0f);
                sceneChangeImg.SetActive(true);
            }
        }
    }
    void PlayerDie()
    {
        SceneManager.LoadScene("EndScene");

    }

}
