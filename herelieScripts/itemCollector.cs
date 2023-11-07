using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{
    private int coins = 0;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private AudioSource collectEffect;
    public coinSpawner limiter;
 
     // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            limiter.spawnLimit++;
           
            Destroy(collision.gameObject);  
            collectEffect.Play();
            coins++;
            coinsText.text = " " + coins;
        }
    }
}
