using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public coinSpawner limiter;
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            limiter.spawnLimit++;
           // Debug.Log("touched collider");
            Destroy(collision.gameObject);
        }
    }
}
