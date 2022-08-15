using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerate : MonoBehaviour
{
    public GameObject Box, Car;
    public GameObject[] Point;

    void Update()
    {
        if (Box.transform.childCount < 1)
        {
            Transform tr = Point[Random.Range(0, Point.Length)].transform;
            GameObject m = Instantiate(Car, tr.position, tr.rotation);
            m.transform.parent = Box.transform;
        }
    }
}
