using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    public Light _light;
    private string playerTag = "Player";
    public AudioSource source ;
    public AudioClip OnoffSfx;
    void Start()
    {
        _light = GetComponent<Light>();
    }
    void OnTriggerEnter(Collider other)
    {     //isTrigger 체크시 충돌 감지 함수 콜백함수
        if(other.gameObject.CompareTag(playerTag))
        {
            _light.enabled = true;
            //라이트 컴퍼넌트 활성화
            source.PlayOneShot(OnoffSfx, 1.0f);
        }
    }
    void OnTriggerExit(Collider other)
    {
        //isTrigger 체크시 충돌 감지하고 빠져나갈때
        //호출 되는 함수 콜백함수
        if (other.gameObject.CompareTag(playerTag))
        {
            _light.enabled = false;
            //라이트 컴퍼넌트 비활성화
            source.PlayOneShot(OnoffSfx, 1.0f);
        }

    }
}
