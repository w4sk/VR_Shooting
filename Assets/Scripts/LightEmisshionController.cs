using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightEmisshionController : MonoBehaviour
{
    private const int lightNum = 2;

    [SerializeField] GameObject[] spotLights = new GameObject[lightNum]; 
    [SerializeField] GameObject[] pointLights = new GameObject[lightNum];

    [SerializeField] float lowPowerSpotIntensity = 0.0f;
    [SerializeField] float highPowerSpotIntensity = 0.0f;

    [SerializeField] float lowPowerPointIntensity = 0.0f;
    [SerializeField] float highPowerPointIntensity = 0.0f;


    public void toHighPower()
    {
        if(!SelectMotionController.AvatarSelectComplete)
        {
            for(int i = 0; i < lightNum; i++)
            {
                spotLights[i].GetComponent<Light>().intensity = highPowerSpotIntensity;
                pointLights[i].GetComponent<Light>().intensity = highPowerPointIntensity;
            }
            Debug.Log("Light Power ON");
        }
    }

    public void toLowPower()
    {
        if(!SelectMotionController.AvatarSelectComplete)
        {
            for(int i = 0; i < lightNum; i++)
            {
                spotLights[i].GetComponent<Light>().intensity = lowPowerSpotIntensity;
                pointLights[i].GetComponent<Light>().intensity = lowPowerPointIntensity;
            }
            Debug.Log("Light Power OFF");
        }
    }
}
