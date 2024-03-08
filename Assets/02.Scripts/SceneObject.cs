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
#if UNITY_EDITOR //유니티 에디터 에서 만 //매크로(미리처리된 기능)
    UnityEditor.EditorApplication.isPlaying = false;
#else
 Application.Quit(); //빌드 했을 때 중지 
#endif

    }
}
