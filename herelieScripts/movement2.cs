using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement2 : MonoBehaviour
{
    public float movementX;
    private SpriteRenderer render;
    private float speed;
    void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        movementX = 0.1f;
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
      
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * speed;
    }
}
