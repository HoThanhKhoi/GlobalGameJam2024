using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraShake : MonoBehaviour
{   
    public static CameraShake Instance {get; private set;}
    private CinemachineVirtualCamera CinemachineVirtualCamera;
    private float ShakeIntensity = 0.5f;
    private float ShakeTimer = 0.2f;
    private float timer;
    private CinemachineBasicMultiChannelPerlin cbmcp;
    void Awake()
    {   
        Instance = this;
        CinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    void Start()
    {
        StopShake();
    }
    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cbmcp.m_AmplitudeGain = ShakeIntensity;
        timer = ShakeTimer;
    }

    void StopShake()
    {
        CinemachineBasicMultiChannelPerlin cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cbmcp.m_AmplitudeGain = 0f;
        timer = 0;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                StopShake();
            }
        }
    }
}
