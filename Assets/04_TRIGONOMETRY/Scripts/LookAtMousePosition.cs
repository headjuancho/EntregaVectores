using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMousePosition : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {

        Vector4 mousePosition = GetWorldMousePos();

        Look(mousePosition);

        
    }

    private Vector4 GetWorldMousePos()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        return worldPos;

    }

    private void Look(Vector2 targetPosition)
    {
        Vector2 thisPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 forward = targetPosition - thisPosition;

        float radians = (Mathf.Atan2(forward.y, forward.x) - (Mathf.PI / 2));
        Rotate(radians);
    }

    private void Rotate(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
}
