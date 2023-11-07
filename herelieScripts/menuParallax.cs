using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuParallax : MonoBehaviour
{

    private Transform samurai;
    private Vector3 tempPos, tempPos1;
    //public movement moveX;
    private float limit;
    // Start is called before the first frame update
    void Start()
    {
        // horse = GameObject.FindWithTag("horse").transform;
        samurai = GameObject.FindWithTag("samurai").transform;

    }
    // Update is called once per frame
    void Update()
    {
        //    tempPos = transform.position;
        //    tempPos.x = horse.position.x;
        //    transform.position = tempPos;

        tempPos1 = transform.position;
        tempPos1.x = samurai.position.x;
        tempPos = tempPos1;
        //if (moveX.movementX < 0)
        //{    
        //    limit = limiter.position.x;
        //    if(tempPos1.x < limit)
        //    {
        //        tempPos1.x = limit;
        //    }

        //}

        transform.position = tempPos1;


    }
}
