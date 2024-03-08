using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private float rotationSpeed = 60f; // Speed of rotation in degrees per second
    private Quaternion initialRotation;
    private float shakeIntensity;
    private float shakeTimer;

    private void Start()
    {
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            // Calculate the new rotation angle based on the intensity and time
            float angle = Mathf.Sin(Time.time * rotationSpeed) * shakeIntensity;

            // Apply the rotation to the object
            transform.rotation = initialRotation * Quaternion.Euler(0f, 0f, angle);

            shakeTimer -= Time.deltaTime;

            // If the shake time is up, reset the rotation
            if (shakeTimer <= 0)
            {
                transform.rotation = initialRotation;
            }
        }
    }

    // Call this method to start the screen shake with custom intensity and duration
    public void StartShake(float intensity, float duration)
    {
        shakeIntensity = intensity;
        shakeTimer = duration;
    }

    public void StartShake_Simple(float intensity)
    {
        shakeIntensity = intensity;
        shakeTimer = 0.35f;
    }
}