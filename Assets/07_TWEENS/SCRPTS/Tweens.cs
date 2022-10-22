using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweens : MonoBehaviour
{

    [SerializeField] private Transform target;


    [Header ("Tween related")]

    [SerializeField, Range(0, 1)]
    private float normalizedTime;

    [SerializeField]
    private float duration = 1;

   

    [Header("Colour")]

    [SerializeField] private Color initialColor;
    [SerializeField] private Color finalColor;
    [SerializeField] AnimationCurve curve;


    private float currentTime = 0f;
    private Vector3 initialPosition;
    private Vector3 finalPosition;
    private SpriteRenderer spriteRenderer;






    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartTween();

    }

    // Update is called once per frame
    void Update()
    {
        normalizedTime = currentTime / duration;

        transform.position = Vector3.Lerp(initialPosition, finalPosition,
            EaseIn(normalizedTime));

        //spriteRenderer.color = Color.Lerp(initialColor, finalColor, EaseIn(normalizedTime));

        spriteRenderer.color = Color.Lerp(initialColor, finalColor, curve.Evaluate(normalizedTime));

        currentTime += Time.deltaTime;
      


        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTween();
        }
    }

    private void StartTween()
    {
        currentTime = 0f;
        initialPosition = transform.position;
        finalPosition = target.position;

    }

    private float EaseIn( float x)
    {
        return x * x;
    }

}
