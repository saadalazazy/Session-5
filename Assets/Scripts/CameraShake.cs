using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class CameraShake : MonoBehaviour
{
    CinemachineVirtualCamera cam;
    public static CameraShake instance;

    private void Awake()
    {
        instance = this;
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    public void setCameraShake(float intensity , float time)
    {
        StartCoroutine(durationCamreaShake(intensity , time));
    }
    IEnumerator durationCamreaShake(float intensity , float time)
    {
        cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = intensity;
        yield return new WaitForSeconds(time);
        cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
    }
}
