using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgMirror : MonoBehaviour
{
    public Image toCopy;
    public Image copyTo;

    void Update()
    {
        copyTo.sprite = toCopy.sprite;
    }
}
