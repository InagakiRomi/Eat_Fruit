using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Vector2 First, Finish;
    public float MoveSpeed, Stop;
    private bool Go = true;

    void FixedUpdate()
    {
        if (Go == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Finish, MoveSpeed);
            StartCoroutine(GoFlase());
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, First, MoveSpeed);
            StartCoroutine(GoTure());
        }
    }

    IEnumerator GoTure()
    {
        yield return new WaitForSeconds(Stop);
        Go = true;
    }
    IEnumerator GoFlase()
    {
        yield return new WaitForSeconds(Stop);
        Go = false;
    }
}
