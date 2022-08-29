using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public GameObject CarDead;
    public float TimerCarDead , CarLife;

    void FixedUpdate()
    {
        TimerCarDead += Time.deltaTime;
        if (TimerCarDead >= CarLife)
        {
            Destroy(CarDead.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "CARDEAD")
        {
            Destroy(CarDead.gameObject);
        }
    }
}
