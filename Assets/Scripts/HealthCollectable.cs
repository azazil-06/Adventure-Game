using Unity.VisualScripting;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{ 

    void OnTriggerEnter2D(Collider2D other)
    {
        
       PlayerController player = other.GetComponent<PlayerController>();
        if(player != null   &&   (player.health < player.maxHealth))
        {
            player.healthChanger(1);
            Destroy(gameObject);
        }
    }
}
