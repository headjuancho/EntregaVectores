using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolitaForces : MonoBehaviour
{
    private MyVector2D position;

    [SerializeField]
    Camera camera;

    [SerializeField]
    private MyVector2D accel;

    [SerializeField]
    private MyVector2D velocity;

    [SerializeField]
    private float mass = 1f;
    //holii
    [Range(0f, 1f)] [SerializeField]
    private float dampingFactor = 0.9f;

    //hol
    [Range(0f, 1f)]
    [SerializeField]
    private float frictionCoefficicent =0.9f;


    private MyVector2D displacement;

    private MyVector2D weight;
   


    [SerializeField]
    private MyVector2D gravity;


    [SerializeField]
    private MyVector2D wind;


    private MyVector2D netForce;

    //hola

    private void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        //Reinicio Accel
        accel *= 0f;
        //reinicio netforce
        netForce = new MyVector2D(0, 0);

        //mg
        weight = gravity * mass;
        ApplyForce(weight);

        //ApplyForce(wind);

        //Friccion

        //MyVector2D friction = -frictionCoefficicent * weight.magnitude * velocity.normalize;
        //ApplyForce(friction);

        //integrate acceleration and velocity
        Move();
    }


    void Update()
    {
        
        position.Draw(Color.blue);
        displacement.Draw(position, Color.red);
        //accel.Draw(position, Color.green);
        Move();

     
    }

    public void Move()
    {
        velocity = velocity + accel * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;

        if (Mathf.Abs(position.x) > camera.orthographicSize)
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

    private void ApplyForce(MyVector2D force)
    {
        netForce += force;
        accel = netForce/mass;
    }
}
