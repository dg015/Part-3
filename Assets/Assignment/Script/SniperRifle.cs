using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class SniperRifle : Gun
{
    
    [SerializeField] private CinemachineVirtualCamera Cinemachine;
    [SerializeField] private CinemachineBasicMultiChannelPerlin shake;
    [SerializeField] private float shakeIntensity;
    [SerializeField] private float time;
    [SerializeField] private float timeMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Awake()
    {
        shake = Cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    // Update is called once per frame
    void Update()
    {
        
        lookat();
        nockback();
        CameraShakeTimer();
    }


    public void CameraShake()
    {
        
        shake.m_AmplitudeGain = shakeIntensity;
    }

    private void CameraShakeTimer()
    { 
        if( shake.m_AmplitudeGain > 0)
        {
           time += Time.deltaTime;
           if (time > timeMax )
            {

                shake.m_AmplitudeGain = 0;
                time = 0;

            }


        }


    }

    protected override void nockback()
    {
        if (Input.GetMouseButtonUp(0))
        {
            
            player.AddForce(-1 * direction * explosionStrenght, ForceMode2D.Force);
            shooot();
            CameraShake();
            
        }
    }

}
