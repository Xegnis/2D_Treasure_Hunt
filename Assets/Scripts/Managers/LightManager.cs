using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    [SerializeField]
    Light2D globalLight;

    private SpriteMask lightMask;

    [SerializeField]
    float startIntensity;

    [SerializeField]
    float darkIntensity;

    [SerializeField]
    float lightIntensity;

    void Awake()
    {
        lightMask = globalLight.GetComponent<SpriteMask>();
    }

    void Start()
    {
        if (startIntensity >= lightIntensity)
        {
            lightMask.enabled = true;
        }
        else
        {
            lightMask.enabled = false;
        }
    }

    public void ToggleLight ()
    {
        if (globalLight.intensity == darkIntensity)
        {
            globalLight.intensity = lightIntensity;
            lightMask.enabled = true;
        }
        else
        {
            globalLight.intensity = darkIntensity;
            lightMask.enabled = false;
        }
    }

}
