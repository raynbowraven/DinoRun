using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusControl : MonoBehaviour
{
    public float MoveSpeed = 0f;
    Vector3 movedir;
    Rigidbody2D cactusbody;

    void Start()
    {
        movedir = new Vector3(-1*MoveSpeed,0,0);
        cactusbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        cactusbody.MovePosition(transform.position + movedir * Time.deltaTime);
    }

}
