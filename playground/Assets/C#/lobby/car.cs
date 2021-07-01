using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    private void Awake()
    {
        speed = Random.Range(2, 10);
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        transform.Translate(speed, 0, 0);
    }
}
