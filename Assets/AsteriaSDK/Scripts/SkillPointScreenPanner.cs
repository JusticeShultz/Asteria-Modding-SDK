using UnityEngine;
using UnityEngine.EventSystems;

public class SkillPointScreenPanner : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Vector2 offset;
    private Vector2 targetPosition;
    public Vector2 minPosition = new Vector2(-100f, -100f);
    public Vector2 maxPosition = new Vector2(100f, 100f);
    public float smoothTime = 0.2f;
    //public TMPro.TextMeshProUGUI skillPointsRemainingText;

    void Start()
    {
    }

    void Update()
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
    }
}