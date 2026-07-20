using UnityEngine;

public class DamageZone : MonoBehaviour
{
    //Script for Damage heat panel
     void OnTriggerStay2D(Collider2D other)
    {
      PlayerController player = other.GetComponent<PlayerController>(); 

       if( player != null)
        {
            player.healthChanger(-1);
        }
    }

}
