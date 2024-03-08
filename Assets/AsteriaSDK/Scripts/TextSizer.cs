using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TextSizer : MonoBehaviour
{
    //public TMP_Text Text;
    public bool ResizeTextObject = true;
    public Vector2 Padding;
    public Vector2 MaxSize = new Vector2(1000, float.PositiveInfinity);
    public Vector2 MinSize;
    public Mode ControlAxes = Mode.Both;

    [Flags]
    public enum Mode
    {
        None = 0,
        Horizontal = 0x1,
        Vertical = 0x2,
        Both = Horizontal | Vertical
    }

    private string _lastText;
    private Mode _lastControlAxes = Mode.None;
    private Vector2 _lastSize;
    private bool _forceRefresh;
    private bool _isTextNull = true;
    private RectTransform _textRectTransform;
    private RectTransform _selfRectTransform;

    protected virtual float MinX
    {
        get
        {
            return 0;
        }
    }

    protected virtual float MinY
    {
        get
        {
            return 0;
        }
    }

    protected virtual float MaxX
    {
        get
        {
            return 0;
        }
    }

    protected virtual float MaxY
    {
        get
        {
            return 0;
        }
    }

    public virtual void Start()
    {
    }

    protected virtual void Update()
    {
    }
    
    public virtual void Refresh()
    {
    }

    private void OnValidate()
    {
    }
}