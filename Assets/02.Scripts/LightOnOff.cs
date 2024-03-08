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
    {     //isTrigger üũ�� �浹 ���� �Լ� �ݹ��Լ�
        if(other.gameObject.CompareTag(playerTag))
        {
            _light.enabled = true;
            //����Ʈ ���۳�Ʈ Ȱ��ȭ
            source.PlayOneShot(OnoffSfx, 1.0f);
        }
    }
    void OnTriggerExit(Collider other)
    {
        //isTrigger üũ�� �浹 �����ϰ� ����������
        //ȣ�� �Ǵ� �Լ� �ݹ��Լ�
        if (other.gameObject.CompareTag(playerTag))
        {
            _light.enabled = false;
            //����Ʈ ���۳�Ʈ ��Ȱ��ȭ
            source.PlayOneShot(OnoffSfx, 1.0f);
        }

    }
}
