using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;


public class MainLaser : MonoBehaviour
{
    bool isFiring = false;
    [SerializeField] GameObject []lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;
    void Start()
    {
        Cursor.visible= false;
    }
    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }

    public void OnFire(InputValue value)
    {
       isFiring = value.isPressed;
    }
     private void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
       {
          var emissionModule = laser.GetComponent<ParticleSystem>().emission;
          emissionModule.enabled = isFiring;
       }
    }
    void MoveCrosshair()
    {
        if (crosshair == null) return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        crosshair.position = mousePosition;
    }
    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position= Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
   
    void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
           Vector3 FireDirection = targetPoint.position - laser.transform.position;
           Quaternion rotationToTarget = Quaternion.LookRotation(FireDirection);
           laser.transform.rotation = rotationToTarget;
        }
    }   
}