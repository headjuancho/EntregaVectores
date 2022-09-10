using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBolita : MonoBehaviour
{
    private MyVector2D position;

    [SerializeField]
    Camera camera;

    [SerializeField]
    private MyVector2D accel;

    [Range(0f, 1f)] [SerializeField]
    private float dampingFactor;

    private MyVector2D velocity;

    private MyVector2D displacement;

    private int currentAcceleration = 0;


    private readonly MyVector2D[] directions = new MyVector2D[4]
    {
        new MyVector2D(0,-9.8f),
        new MyVector2D(9.8f, 0),
        new MyVector2D(0, 9.8f),
        new MyVector2D(-9.8f, 0)
    };

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            accel = directions[(++currentAcceleration) % directions.Length];
            velocity *= 0;
            
        }
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
