using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFall : MonoBehaviour
{
    private MyVector2D position;

    [SerializeField]
    Camera camera;

    [SerializeField]
    Transform blackHole;

    [SerializeField]
    private MyVector2D accel;

    [Range(0f, 1f)] [SerializeField]
    private float dampingFactor;

    private MyVector2D velocity;

    private MyVector2D displacement;

 


    private void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        Move();
    }


    void Update()
    {
        
        position.Draw(Color.blue);
        displacement.Draw(position, Color.red);
        accel.Draw(position, Color.green);
        Move();
    }

    public void Move()
    {
        velocity += accel * Time.deltaTime;

        displacement = velocity * Time.deltaTime;
        position = position + displacement;

        if(Mathf.Abs(position.x) > camera.orthographicSize)
        {
            velocity.x = velocity.x * -1;
            position.x = Mathf.Sign(position.x) * camera.orthographicSize;
            velocity *= dampingFactor;

        }

        if (Mathf.Abs(position.y) > camera.orthographicSize)
        {
            velocity.y = velocity.y * -1;
            position.y = Mathf.Sign(position.y) * camera.orthographicSize;
            velocity *= dampingFactor;

        }


        transform.position = new Vector3(position.x, position.y);
    }
}
