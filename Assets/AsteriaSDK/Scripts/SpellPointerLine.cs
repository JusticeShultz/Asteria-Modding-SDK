using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellPointerLine : MonoBehaviour
{
   // public UnityEngine.UI.Extensions.UILineRenderer uILineRenderer;
    public Canvas canvas;
    public Image cursorStart;
    public Image cursorEnd;
    public Animator targetSelf;

    public Vector3 startOfPoint = Vector3.zero;
    public Vector3 bezierMiddle = Vector3.zero;
    public Vector3 bezierEnd = Vector3.zero;
    public Vector2 bezierEndOffset = Vector2.zero;

    public bool activated = false;
    public bool mouseDown = false;

    void Update()
    {
    }
    
    public Vector3 MultiplyVector3(Vector3 a, Vector3 b)
    {
        return Vector3.zero;
    }
}