using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderBehavoiur : MonoBehaviour
{
     private float speed = 10f;
    public movement moveX;
    private Transform samurai;
    // Start is called before the first frame update
    void Start()
    {
        samurai = GameObject.FindWithTag("samurai").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveX.movementX > 0 )
        {
            transform.position += new Vector3(0.5f, 0f, 0f) * Time.deltaTime * speed;
        }
    }
}
