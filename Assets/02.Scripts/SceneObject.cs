using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneObject : MonoBehaviour
{
   
    void Start()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("BattleScene");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR //����Ƽ ������ ���� �� //��ũ��(�̸�ó���� ���)
    UnityEditor.EditorApplication.isPlaying = false;
#else
 Application.Quit(); //���� ���� �� ���� 
#endif

    }
}
