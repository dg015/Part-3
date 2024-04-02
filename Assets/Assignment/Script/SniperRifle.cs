using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class SniperRifle : Gun
{
    
    [SerializeField] private CinemachineVirtualCamera Cinemachine;
    [SerializeField] private CinemachineBasicMultiChannelPerlin shake;
    [SerializeField] private float shakeIntensity;
    [SerializeField] private float Shaketime;
    [SerializeField] private float shaketimeMax;
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private bool readyToFire = true;
    // Start is called before the first frame update


    private void Awake()
    {
        shake = Cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    // Update is called once per frame
    void Update()
    {
        lookat();
        CameraShakeTimer();
        if (Input.GetMouseButton(0) && readyToFire)
        {
            StartCoroutine(shootingCycle());
        }

    }


    public void CameraShake()
    {
        //add camera shake 
        shake.m_AmplitudeGain = shakeIntensity;
    }

    private void CameraShakeTimer()
    { 
        // check if theres any shake on the camerea
        if( shake.m_AmplitudeGain > 0)
        {
            //increase shake time
            Shaketime += Time.deltaTime;
           if (Shaketime > shaketimeMax)
            {
                //set camera shake to 0 
                shake.m_AmplitudeGain = 0;
                Shaketime = 0;
            }

        }
    }

    protected override void nockback()
    {
        player.AddForce(-1 * direction * explosionStrenght, ForceMode2D.Force);
        shooot();
        CameraShake();
    }

    private IEnumerator shootingCycle()
    {
        
        nockback();
        readyToFire = false;
        yield return new WaitForSeconds(timeBetweenShots);
        Debug.Log("I'me here");
        readyToFire = true;


    }

}
