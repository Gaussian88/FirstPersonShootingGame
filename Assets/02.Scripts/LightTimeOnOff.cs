using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//1. ����Ʈ ��� �׸�,��� 
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
        // ��ŸƮ �ڷ�ƾ �ð������� � ��ɵ��� �������ִ� �Լ�
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
