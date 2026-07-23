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

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyBehavior enemy = other.GetComponent<EnemyBehavior>();
        if(enemy != null)
        {
            enemy.Fix();
        }
        Debug.Log("Collided with:" + other.gameObject.name);
        Destroy(gameObject);
        
    }


    //also destroy on collision with non trigger objects
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
