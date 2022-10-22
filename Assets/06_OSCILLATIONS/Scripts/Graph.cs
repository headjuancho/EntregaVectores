using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{

    [SerializeField] int m_totalPoints;
    [SerializeField] float m_distanceFactor;
    [SerializeField] float m_amplitude;
    [SerializeField] GameObject m_prefab;

    GameObject[] gameObjects;


    // Start is called before the first frame update
    void Start()
    {

        gameObjects = new GameObject[m_totalPoints];


        for (int i = 0; i < m_totalPoints; i++)
        {
           gameObjects[i] = Instantiate(m_prefab, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            float x = i * m_distanceFactor;
            float y = m_amplitude * Mathf.Sin(x + Time.time);

            gameObjects[i].transform.localPosition = new Vector3(x, y);
        }
    }
}
