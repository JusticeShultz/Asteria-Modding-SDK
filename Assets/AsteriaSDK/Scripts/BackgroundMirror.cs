using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMirror : MonoBehaviour
{
    public RectTransform self;
    public RectTransform backgroundA;
    public RectTransform backgroundB;

    void Update()
    {
        if(backgroundA.gameObject.activeSelf)
        {
            self.position = backgroundA.position;
        }
        else
        {
            self.position = backgroundB.position;
        }
    }
}
