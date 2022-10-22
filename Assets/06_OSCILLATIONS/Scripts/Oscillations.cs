using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillations : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float amplitud = 1;
    [SerializeField] private float periodo = 1;

    Vector3 posInicial;

    void Start()
    {
        posInicial = new Vector3(transform.position.x, transform.position.y);

    }

    // Update is called once per frame
    void Update()
    {
        /*
        float x = amplitud * Mathf.Sin(2f * Mathf.PI * (Time.time / periodo));

        transform.position = new Vector3(x, x, 0);
        */

        //CAOS

        float y = Mathf.Sin(5f * Time.time) + Mathf.Cos(Time.time / 3f) + Mathf.Sin(Time.time/13f);

        transform.position =  posInicial + new Vector3(y, 0, 0);

    }
}
