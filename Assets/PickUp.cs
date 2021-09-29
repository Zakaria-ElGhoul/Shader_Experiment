using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float time;
    public Player_Health health;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            health.timeRemaining += time;
            Destroy(this.gameObject);
        }
    }
}
