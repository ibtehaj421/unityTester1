using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public Slider slide;
    public Gradient gradient;
    public Image fill;
    public void setMax(int health)
    {
        slide.maxValue = health;
        slide.value = health;
        fill.color = gradient.Evaluate(1f);
        
    }
    public void setHealth(int health)
    {
        slide.value = health;
        fill.color = gradient.Evaluate(slide.normalizedValue);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
