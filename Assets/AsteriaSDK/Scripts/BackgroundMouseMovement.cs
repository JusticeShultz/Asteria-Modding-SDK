//using UnityEngine;

//public class BackgroundMouseMovement : MonoBehaviour
//{
//    public float dampener = 1.5f;
//    public float smoothing = 0.25f;
//    public RectTransform recT;

//    void Update()
//    {
//        Vector3 vect = Input.mousePosition * dampener;
//        recT.anchoredPosition = Vector2.Lerp(recT.anchoredPosition, new Vector2(-vect.x, -vect.y), smoothing);
//    }
//}
using UnityEngine;

public class BackgroundMouseMovement : MonoBehaviour
{
    public float dampener = 1.5f;
    public float smoothing = 0.25f;
    public RectTransform recT;
    public Vector2 minBounds; // Minimum clamping bounds
    public Vector2 maxBounds; // Maximum clamping bounds

    void Update()
    {
        Vector3 vect = Input.mousePosition * dampener;
        Vector2 targetPosition = new Vector2(-vect.x, -vect.y);
        targetPosition.x = Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minBounds.y, maxBounds.y);
        recT.anchoredPosition = Vector2.Lerp(recT.anchoredPosition, targetPosition, smoothing);
    }
}