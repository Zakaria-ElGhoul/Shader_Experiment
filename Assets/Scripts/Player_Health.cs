using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Renderer))]
public class Player_Health : MonoBehaviour
{
    
    [SerializeField]float extrusionAmount = 0;
    Renderer renderer;
    public float timeRemaining = 0;
    [SerializeField] Slider healthSlider;
    [SerializeField] Animator animator;
    [SerializeField] bool isDead;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        extrusionAmount = timeRemaining / 200;
        if (timeRemaining >= -10)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            isDead = true;
            Die();
        }
        healthSlider.value = timeRemaining / 10;
        renderer.material.SetFloat("_Amount", extrusionAmount);
    }
    void Die()
    {
        if(isDead)
        {
        animator.SetTrigger("Death");
        }
    }

}
