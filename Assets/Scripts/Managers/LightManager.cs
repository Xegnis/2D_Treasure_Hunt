using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LightManager : MonoBehaviour
{
    [SerializeField]
    Light globalLight;

    private Collider2D lightCollider;

    [SerializeField]
    float startIntensity;

    [SerializeField]
    float darkIntensity;

    [SerializeField]
    float lightIntensity;

    void Awake()
    {
        lightCollider = GetComponent<Collider2D>();
    }

    void Start()
    {
        globalLight.intensity = startIntensity;
        if (startIntensity >= lightIntensity)
        {
            lightCollider.enabled = true;
        }
        else
        {
            lightCollider.enabled = false;
        }
    }

    public void toggleLight ()
    {
        if (globalLight.intensity == darkIntensity)
        {
            globalLight.intensity = lightIntensity;
            lightCollider.enabled = true;
        }
        else
        {
            globalLight.intensity = darkIntensity;
            lightCollider.enabled = false;
        }
    }

}
