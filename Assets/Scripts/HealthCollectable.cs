using Unity.VisualScripting;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerController player;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        player = other.GetComponent<PlayerController>();
        if(player != null)
        {
            player.health(1);
            Destroy(gameObject);
        }
    }
}
