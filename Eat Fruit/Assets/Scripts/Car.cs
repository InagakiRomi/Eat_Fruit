using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public GameObject CarDead;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "CARDEAD")
        {
            Destroy(CarDead.gameObject);
        }
    }
}
