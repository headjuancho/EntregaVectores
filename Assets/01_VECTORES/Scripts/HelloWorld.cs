using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class HelloWorld : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private MyVector2D myFirstVector = new MyVector2D(2, 3);

    [SerializeField]
    private MyVector2D mySecondVector = new MyVector2D(3, 4);



    [Range(0, 1)]
    [SerializeField]

    float multiplier = 0;


    [SerializeField]
    private MyVector2D myThirdVector;


    void Start()
    {

        MyVector2D a = new MyVector2D(2,3);
        MyVector2D b = new MyVector2D(4,5);

        MyVector2D f = a * 2f;


        //MyVector2D d = a.Sum(b);
        //Debug.Log(d.x + "," + d.y);
        

        Vector2 au = new Vector2 (2, 3);
        Vector2 bu = new Vector2(4, 5);

        Vector2 dv = au + bu;

    }

    // Update is called once per frame
    void Update()
    {
      

        myFirstVector.Draw(Color.green);
        mySecondVector.Draw(Color.red);

        MyVector2D fourthvector = (mySecondVector - myFirstVector) * multiplier;

        fourthvector.Draw(myFirstVector, Color.yellow);


        myThirdVector = fourthvector + myFirstVector;

        myThirdVector.Draw(Color.blue);


        


    }
}
