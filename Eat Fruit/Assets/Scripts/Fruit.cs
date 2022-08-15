using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject PS1;
    private GM GM;

    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GM>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            GM.EatFruit();
            Instantiate(PS1, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
