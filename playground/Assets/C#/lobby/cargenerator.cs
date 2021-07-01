using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cargenerator : MonoBehaviour
{    
    public List<GameObject> cars = new List<GameObject>();
    public GameObject canvas;
    public RectTransform rt;
    public float timer;
    public float span;
    


    private void Awake()
    {
        rt = GetComponent<RectTransform>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= span)
        {
            timer = 0;
            span = Random.Range(0.3f, 3);

            GameObject newImage = Instantiate(cars[Random.Range(0, 5)], rt.position,rt.rotation);
            newImage.transform.SetParent(canvas.transform, false);
            newImage.GetComponent<RectTransform>().position =  rt.position;
        }
    }
}
