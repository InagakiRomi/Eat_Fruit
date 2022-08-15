using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private Animator ani;
    private Player Player;

    void Start()
    {
        ani = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            StartCoroutine(UpUp());
        }
    }

    IEnumerator UpUp()
    {
        ani.SetTrigger("UP");
        Player.JumpImpulse = Player.JumpImpulse * 2;
        yield return new WaitForSeconds(0.5f);
        Player.JumpImpulse = Player.JumpImpulse / 2;
    }
}
