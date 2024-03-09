using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HealthVolume : MonoBehaviour
{
    [SerializeField]
    private Volume volume;

    private ColorAdjustments color;
    private Vignette vignette;

    public void Start()
    {
        color = volume.profile.components[0] as ColorAdjustments;
        vignette = volume.profile.components[1] as Vignette;
    }


    public void updateVolume(float healthPercentage)
    {
        // map percentage to color saturation 0 -> -100
        color.saturation.value = -100 + healthPercentage * 100;

        // map percentage to vignette intensity 0 -> 0.5
        vignette.intensity.value = (1-healthPercentage) * 0.5f;
    }
}
