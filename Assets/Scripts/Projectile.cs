using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D projectileRB;

    void Awake() 
    {
        projectileRB=GetComponent<Rigidbody2D>();        
    }

    public void Launch(Vector2 direction, float force)
    {
        projectileRB.AddForce(direction * force);
    }
    
    
}
