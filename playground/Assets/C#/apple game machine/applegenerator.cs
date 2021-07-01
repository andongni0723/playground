using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applegenerator : MonoBehaviour
{
    public GameObject apple;

    float timer;
    public float span;

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= span)
        {
            timer = 0;

            Instantiate(apple, new Vector2(Random.Range(-6, 6), 3.15f), Quaternion.identity);
        }
    }
}
