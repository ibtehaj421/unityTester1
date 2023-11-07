using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyReference;
    [SerializeField] private Transform Pos1, Pos2;
    private int randomIndex;
    private int randomSide;
    private GameObject spawnedEnemy;
    public int limiter;
    public bool spawn = true;
    private bool Pos1Full = false;
    private bool Pos2Full = false;
    private float spawnTimer = 0;
    void Start()
    {
        StartCoroutine(SpawnedEnemies());
        //enemyspawn();
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }
    IEnumerator SpawnedEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, enemyReference.Length);
            randomSide = Random.Range(0, 2);


            spawnedEnemy = Instantiate(enemyReference[randomIndex]);
            if (randomSide == 0)
            {
               
                spawnedEnemy.transform.position = Pos1.position;
                limiter--;
                //Debug.Log("limiter: " + limiter);
            }
            else
            {
               
                spawnedEnemy.transform.position = Pos2.position;
                limiter--;
                //Debug.Log("limiter: " + limiter);
            }
        }
            
        
    }
    //void enemyspawn()
    //{
    //    //Debug.Log("spawn value is: "+spawn);
    //    spawnTimer = 0;
    //    float randomTime = Random.Range(1, 5);
    //    while (spawnTimer <= randomTime)
    //    {
    //        spawnTimer += 0.001f;
    //    }
        

    //        if (spawn)
    //        {
    //            randomIndex = Random.Range(0, enemyReference.Length);
    //            randomSide = Random.Range(0, 2);
                
    //            if (randomSide == 0)
    //            {
    //            spawnedEnemy[0] = Instantiate(enemyReference[randomIndex]);
    //            spawnedEnemy[0].transform.position = Pos1.position;
    //            limiter--;
    //                Pos1Full = true;
    //            }
    //            else
    //            {
    //            spawnedEnemy[1] = Instantiate(enemyReference[randomIndex]);
    //            spawnedEnemy[1].transform.position = Pos1.position;
    //            limiter--;
    //               // Pos1Full = false;
    //            }
    //            if (limiter == 1)
    //            {
    //            Debug.Log("false");
    //            spawn = false;
    //            }
    //        }
    //    }
    
        
    
}
