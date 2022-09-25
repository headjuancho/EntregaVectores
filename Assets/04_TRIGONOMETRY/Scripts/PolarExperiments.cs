using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PolarExperiments : MonoBehaviour
{

    [SerializeField] float radius;


    [SerializeField] float angleDeg;


    [SerializeField] float radialSpeed;


    [SerializeField] float angularSpeed;


    [SerializeField] Transform bolita;


    void Start()
    {
        Assert.IsNotNull(bolita, "bolita reference is required");
    }

    void Update()
    {
        radius += radialSpeed*Time.deltaTime;
        angleDeg += angularSpeed*Time.deltaTime;

        

        Vector3 newPosition = PolarToCartesian(radius, angleDeg);

        bolita.position = newPosition;

        Debug.DrawLine(Vector3.zero, newPosition );
        
    }


    private Vector3 PolarToCartesian(float currentRadius, float angle)
    {

        float x, y;

        x = currentRadius * Mathf.Cos(angle * Mathf.Deg2Rad);

        y = currentRadius * Mathf.Sin(angle * Mathf.Deg2Rad);


        return new Vector3(x, y, 0);

    }
}
