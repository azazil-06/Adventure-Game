using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    
    //Declarations
    private Rigidbody2D enemyRB;
    private Animator enemyAnimate;
    public bool isVertical;


    //direction, speed related
    public float enemySpeed = 5f;
    public float directionChangeTime = 3.0f;
    float directionTimer;
    int direction = 1;
    
    
    
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnimate = GetComponent<Animator>();


        directionTimer = directionChangeTime;        
    }

  
    void FixedUpdate()
    {
        Vector2 position = enemyRB.position;
        directionTimer -= Time.deltaTime;

            if(directionTimer < 0)
            {
                direction = -direction;
                directionTimer=directionChangeTime;
            } 

        if (isVertical)
        {
            position.y = position.y + enemySpeed *Time.deltaTime *direction;

            enemyAnimate.SetFloat("Move X",0);
            enemyAnimate.SetFloat("Move Y",direction);

        }
        else
        {
            position.x = position.x + enemySpeed * Time.deltaTime *direction;

            enemyAnimate.SetFloat("Move X",direction);
            enemyAnimate.SetFloat("Move Y",0);
        }
        enemyRB.MovePosition(position);
    }


    void OnTriggerEnter2D(Collider2D other) //colliding with enemy reduces health
    {
        PlayerController playerBody = other.GetComponent<PlayerController>();
        
        if(playerBody!=null)
        {
            playerBody.healthChanger(-1);
        }
    }


}
