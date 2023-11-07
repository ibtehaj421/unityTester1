using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundmove : MonoBehaviour
{
    private Transform horse;
    private Vector2 tempPos;
    // Start is called before the first frame update
    void Start()
    {
        horse = GameObject.FindWithTag("samurai").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tempPos = transform.position;
        tempPos.x = horse.position.x;
        transform.position = tempPos;
    }
}
