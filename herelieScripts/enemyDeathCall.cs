using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDeathCall : MonoBehaviour
{
    public SpawnBehaviour limit;
    // Start is called before the first frame update
    private void Death()
    {
        //limit.limiter--;
       // Debug.Log("this is the limter value: "+limit.limiter);
        Destroy(this.gameObject);
    }
}
