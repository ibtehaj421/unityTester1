using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] positions;
    [SerializeField] private GameObject[] coinReference;
    private GameObject[] spawnedCoin;
    public int spawnLimit = 5;
    private bool spawn = true;
    private float spawnTime;
    private float spawnInterval = 5;
    // Start is called before the first frame update
    void Start()
    {
        spawnedCoin = new GameObject[5];
       // StartCoroutine(coinSpawn());    
    }

    // Update is called once per frame
    void Update()
    {
       spawnCoins();
       if(spawnLimit == 5)
        {
            spawn = true;
        }
    }
    IEnumerator coinSpawn()
    {
        while(true)
        {
           
                yield return new WaitForSeconds(5);
            //if (spawnLimit == 0)
            //{
                
                for (int i = 0; i < 5; i++)
                {
                    spawnedCoin[i] = Instantiate(coinReference[i]);
                    spawnLimit++;
                }
                for (int i = 0; i < 5; i++)
                    spawnedCoin[i].transform.position = positions[i].position;

            //}
           
        }
    }
    private void spawnCoins()
    {
        if(spawn)
        {
            for (int i = 0; i < 5; i++)
            {
                spawnedCoin[i] = Instantiate(coinReference[i]);
                spawnLimit--;
            }
            for (int i = 0; i < 5; i++)
            {
                spawnedCoin[i].transform.position = positions[i].position;
            }
            
            if(spawnLimit == 0)
            spawn = false;
        }
    }
    
}
