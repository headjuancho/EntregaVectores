using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingToBall : MonoBehaviour
{
    
    private enum MovementMode
    {
        ConstantVelocity = 0,

        Accel
    }

    [SerializeField] private float speed;
    [SerializeField] private MovementMode movement;
    private Vector3 velocity;
    private Vector3 acceleration;

   

    // Update is called once per frame
    void Update()
    {


        UpdateMovementMode();

        //velocity.Normalize();

        //calculo posicion
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
        Rotate(Mathf.Atan2(velocity.y, velocity.x) - Mathf.PI / 2f);
    }


    private void UpdateMovementMode()
    {
        if (movement == MovementMode.ConstantVelocity)
        {
            velocity = GetWorldMousePosition() - transform.position;
            velocity.Normalize();

            velocity *= speed;

            acceleration *= 0;

        }
        else if (movement == MovementMode.Accel)
        {
            acceleration = GetWorldMousePosition() - transform.position;

            velocity.z = 0;

        }


    }

    private Vector3 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
        Vector3 worldPos = camera.ScreenToWorldPoint(screenPos);
        return worldPos;

    }


    private void Rotate(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
}
