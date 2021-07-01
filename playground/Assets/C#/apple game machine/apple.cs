using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, speed);

        if(transform.position.y <= -5)
        {
            gamemanager.instance.missapple();

            gamemanager.instance.playsound(1);

            Destroy(gameObject);
        }
    }
}
