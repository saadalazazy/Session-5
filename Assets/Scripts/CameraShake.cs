using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    CinemachineVirtualCamera cam;
    public static CameraShake instants;
    private void Start()
    {
        instants = this;
        cam = GetComponent<CinemachineVirtualCamera>();
    }
    public void ShakeCamera(float amplitude ,float duration)
    {
        StartCoroutine(shakeCoroutine(amplitude , duration));
    }
    IEnumerator shakeCoroutine(float amplitude, float duration)
    {
        cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
        yield return new WaitForSeconds(duration);
        cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
    }
}
