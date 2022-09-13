using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolitaForces : MonoBehaviour
{

    public enum bolitaMode
    {
        Friction,
        FluidFriction,
        Gravity
    }
    private MyVector2D position;

    [SerializeField]
    private bolitaMode mode;

    [SerializeField]
    private BolitaForces otherBall;

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

        if (mode != bolitaMode.Gravity)
        {
            weight = gravity * mass;
            ApplyForce(weight);

            ApplyForce(wind);
        }


        if(mode == bolitaMode.FluidFriction)
        {
            if (transform.localPosition.y >=0)
            {
                ApplyFriction();
            }

            if(transform.localPosition.y <=0)
            {
                ApplyFluid();
            }
          
            
        }
        else if (mode == bolitaMode.Friction)
        {
            ApplyFriction();
        }

        else if (mode == bolitaMode.Gravity)
        {
            MyVector2D diff = otherBall.position - position;
            float distance = diff.magnitude;
            float scalarPart = (mass * otherBall.mass) / (distance * distance);
            MyVector2D gravityForce = diff.normalize * scalarPart;
            ApplyForce(gravityForce);
        }
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


        if(mode != bolitaMode.Gravity)
        {
            CheckBoxBounds();
        }

        else
        {
            if (velocity.magnitude >= 10)
            {
                velocity = 10f * velocity.normalize;
            }
        }

        transform.position = new Vector3(position.x, position.y);
    }

    private void ApplyForce(MyVector2D force)
    {
        netForce += force;
        accel = netForce/mass;
    }

    private void ApplyFriction()
    {
        //Friccion
        float Normal = -mass * gravity.y;
        MyVector2D friction = -frictionCoefficicent * Normal * velocity.normalize;
        ApplyForce(friction);
    }

    private void ApplyFluid()
    {

        if (transform.localPosition.y <= 0)
        {
            float frotalArea = transform.localScale.x;
            float rho = 4;
            float fluidDragCoefficient = 1;
            float velocityMagnitude = velocity.magnitude;

            float scalarPart = -0.5f * rho * velocityMagnitude * velocityMagnitude * frotalArea *
                fluidDragCoefficient;

            MyVector2D fluidFriction = scalarPart * velocity.normalize;
            ApplyForce(fluidFriction);

        }
    }

    private void Gravity()
    {
        
    }

    private void CheckBoxBounds()
    {
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
    }
}
