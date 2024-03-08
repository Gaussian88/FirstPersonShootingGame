using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//1. 라이트 노란 그린,블루 
public class LightTimeOnOff : MonoBehaviour
{
    public Light blueLight;
    public Light greenLight;
    public Light yellowLight;
   
    void Start()
    {
        TurnOn();
    }
    public void TurnOn()
    {
        StartCoroutine(LightShowOnOff());
        // 스타트 코루틴 시간간격을 어떤 기능들을 구현해주는 함수
    }
    IEnumerator LightShowOnOff()
    {
        greenLight.enabled = true;
        blueLight.enabled = false;
        yellowLight.enabled = false;

        yield return new WaitForSeconds(3.0f);

        greenLight.enabled = false;
        blueLight.enabled = true;
        yellowLight.enabled = false;

        yield return new WaitForSeconds(3.0f);

        greenLight.enabled = false;
        blueLight.enabled = false;
        yellowLight.enabled = true;

        yield return new WaitForSeconds(3.0f);

        TurnOn();
    }
 
}
