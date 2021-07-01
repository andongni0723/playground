using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketcontroller : MonoBehaviour
{
    Rigidbody2D rb;
    
    public float speed;
    public float movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //movement = Input.GetAxisRaw("Horizontal");

        //rb.velocity = new Vector2(movement * speed, rb.velocity.y);   
    }

    public void movein(int index)
    {
        //Debug.Log("f");

        switch (index)
        {
            case 1://left
                movement = -1;                
                break;
            case 2:
                movement = 1;             
                break;
        }

        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }
    public void moveout(int index)
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("apple"))
        {
            gamemanager.instance.addpoint();

            gamemanager.instance.playsound(0);

            Destroy(other.gameObject);
        }
    }
}
