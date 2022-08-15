using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float Dead;
    void Start()
    {
        Destroy(gameObject, Dead);
    }
}
