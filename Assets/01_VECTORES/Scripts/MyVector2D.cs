using System;
using UnityEngine;

[Serializable]
public struct MyVector2D
{
    public float x;

    public float y;
 
    public float magnitude
    {
        get
        {
            return Mathf.Sqrt((x * x) + (y * y));
        }
    }

    public MyVector2D normalize
    {
        get
        {
            if (magnitude <= 0.0001)
            {
                return new MyVector2D(0, 0);
            }
            return new MyVector2D(x / magnitude, y / magnitude);
        }

    }

    public MyVector2D(float x, float y)
    {
        this.x = x;
        this.y = y;
    }


    public void Normalize()

    {

        float tolerance = 0.0001f;
        if(magnitude <= tolerance)
        {
            x = 0;
            y = 0;
            return;
        }

        x /= magnitude;
        y /= magnitude;
    }


    public static MyVector2D operator +(MyVector2D a, MyVector2D b)
    {
        return new MyVector2D(a.x + b.x, a.y + b.y);
    }
    public static MyVector2D operator -(MyVector2D a, MyVector2D b)
    {
        return new MyVector2D(a.x - b.x, a.y - b.y);
    }
    public static MyVector2D operator *(MyVector2D a, float b)
    {
        return new MyVector2D(a.x * b, a.y * b);
    }
    public static MyVector2D operator *(float b, MyVector2D a)
    {
        return new MyVector2D(a.x * b, a.y * b);
    }
    public static MyVector2D operator /(MyVector2D a, float b)
    {
        return new MyVector2D(a.x / b, a.y / b);
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