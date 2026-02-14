using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float clampRange = 10f;
    [SerializeField] float maxRollAngle = 30f;
    [SerializeField] float rollSpeed = 5f;
    [SerializeField] float collisionCheckRadius = 0.5f; // Радиус проверки коллизий
    [SerializeField] LayerMask terrainLayer; // Слой террейна
    
    Vector2 movement;
    float currentRollAngle = 0f;
    float currentPitch = 0f;
    
    void Update()
    {
        CalculateMovement();
        ProcessRotation();
    }

    private void CalculateMovement()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawXpoz = transform.localPosition.x + xOffset;
        float rawYpoz = transform.localPosition.y + yOffset;
        float clampedXPoz = Mathf.Clamp(rawXpoz, -clampRange, clampRange);
        float clampedYPoz = Mathf.Clamp(rawYpoz, -clampRange, clampRange);
        
        Vector3 targetPosition = new Vector3(clampedXPoz, clampedYPoz, 0f);
        Vector3 worldTargetPosition = transform.parent.TransformPoint(targetPosition);
        
        // Проверка коллизии
        if (!Physics.CheckSphere(worldTargetPosition, collisionCheckRadius, terrainLayer))
        {
            transform.localPosition = targetPosition;
        }
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    void ProcessRotation()
    {
        float targetRollAngle = -movement.x * maxRollAngle;
        float targetPitchAngle = -movement.y * maxRollAngle;
        
        currentRollAngle = Mathf.Lerp(currentRollAngle, targetRollAngle, rollSpeed * Time.deltaTime);
        currentPitch = Mathf.Lerp(currentPitch, targetPitchAngle, rollSpeed * Time.deltaTime);
        
        float pitch = currentPitch;
        float yaw = 0f;
        float roll = currentRollAngle;
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}