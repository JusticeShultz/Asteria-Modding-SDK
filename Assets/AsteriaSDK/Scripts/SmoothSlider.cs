using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSlider : MonoBehaviour
{
    //This component is outdated and should be phased out eventually due to the shader being updated to sample the alpha.

    [Range(0, 1)] public float fillAmount = 1f;
    public Image img;
    
    void Update()
    {
        img.color = new Color(0, 0, 0, fillAmount);
    }
}
