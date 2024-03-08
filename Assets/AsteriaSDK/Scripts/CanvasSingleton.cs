using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInstance : MonoBehaviour
{
    public static Canvas canvasRef;
    public static RectTransform canvasRectTransform;
    public static CanvasInstance Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        canvasRef = GetComponent<Canvas>();
        canvasRectTransform = GetComponent<RectTransform>();
    }
}
