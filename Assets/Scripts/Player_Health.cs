using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Renderer))]
public class Player_Health : MonoBehaviour
{
    
    [SerializeField]float extrusionAmount = 0;
    Renderer renderer;
    [SerializeField] float timeRemaining = 0;
    [SerializeField] Slider healthSlider;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        extrusionAmount = timeRemaining / 10;
        if (timeRemaining >= -10)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
            Destroy(this.gameObject);
        healthSlider.value = timeRemaining / 10;
        renderer.material.SetFloat("_Amount", extrusionAmount);
    }
}
