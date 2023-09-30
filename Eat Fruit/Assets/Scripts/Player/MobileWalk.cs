using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileWalk : MonoBehaviour
{
    [SerializeField] public float MoveSpeed = 10;
    public Rigidbody2D myRbody;
    private GM GM;
    private LongPressEffect LPEL, LPER;
    private Player Player;

    void Start()
    {
        myRbody = GetComponent<Rigidbody2D>();
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GM>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        LPEL = GameObject.Find("Left").GetComponent<LongPressEffect>();
        LPER = GameObject.Find("Right").GetComponent<LongPressEffect>();
        Player.JumpImpulse = 3f;
    }

    void FixedUpdate()
    {
        if (GM.ClearBool == false)
        {
            LefttWalk();
            RightWalk();
        }
        else
        {
            myRbody.velocity = new Vector2(0 * MoveSpeed, myRbody.velocity.y);
        }
    }

    public void LefttWalk()
    {
        myRbody.velocity = new Vector2(LPEL.PressDownTimer * MoveSpeed, myRbody.velocity.y);
        gameObject.transform.Rotate(new Vector3(0, 0, 0.5f));
    }
    public void RightWalk()
    {
        myRbody.velocity = new Vector2(LPER.PressDownTimer * MoveSpeed, myRbody.velocity.y);
        gameObject.transform.Rotate(new Vector3(0, 0, -0.5f));
    }
}

