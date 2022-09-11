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

        position = new MyVector2D(transform.position.x, transform.position.y);
        MyVector2D blackHolePos = new MyVector2D(blackHole.position.x, blackHole.position.y);
        accel = blackHolePos - position;

        position.Draw(Color.blue);
        displacement.Draw(position, Color.red);
        accel.Draw(position, Color.green);
        Move();
    }

    public void Move()
    {
        

        velocity += accel * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;


        transform.position = new Vector3(position.x, position.y);
    }
}
