using System;
using UnityEngine;

[Serializable]
public struct MyVector2D
{
    public float x;

    public float y;

    public MyVector2D(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public static MyVector2D operator + (MyVector2D a, MyVector2D b)
    {
        return a.Sum(b);
    }

    public static MyVector2D operator -(MyVector2D a, MyVector2D b)
    {
        return a.Sub(b);
    }


    public static MyVector2D operator *(MyVector2D a, float b)
    {
        return a.Scale(b);
    }


    public MyVector2D Sum (MyVector2D sum1)
    {
        MyVector2D result = new MyVector2D((sum1.x + x), (sum1.y + y));

        return result;

    }

    public MyVector2D Sub(MyVector2D sum1)
    {
        MyVector2D result = new MyVector2D((x- sum1.x ), (y- sum1.y));

        return result;

    }

    public MyVector2D Scale(float sum1)
    {
        MyVector2D result = new MyVector2D((sum1*x), (sum1*y));

        return result;

    }


    public void Draw(Color color)
    {
        Debug.DrawLine(Vector3.zero, new Vector3(x, y, 0), color);

    }

     public void Draw(MyVector2D newOrigin, Color color)
    {
        Debug.DrawLine(
            new Vector3(newOrigin.x, newOrigin.y, 0),
            new Vector3(newOrigin.x + x, newOrigin.y + y, 0),
            color
            );
    }


}