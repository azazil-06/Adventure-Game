using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    //Declarations
    private InputSystem_Actions action;
    Rigidbody2D playerRB;
    Animator playerAnimate;
    [SerializeField] private Vector2 moveInput;
    [SerializeField] private float moveSpeed =5f;
    public int maxHealth = 5;    
    int currentHealth;
    public int health{get {return currentHealth;}}
    private Vector2 moveDirection = new Vector2(1,0);

    //cooldown
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float damageCooldown;


    void Awake()
    {
        action = new InputSystem_Actions();
    }
    void Start()
    {
       playerRB=GetComponent<Rigidbody2D>();
       playerAnimate=GetComponent<Animator>();

       currentHealth=maxHealth;
    }


    void Update()
    {
        action.Player.Enable();

        moveInput = action.Player.Move.ReadValue<Vector2>();

        if(!Mathf.Approximately(moveInput.x, 0.0f) || !Mathf.Approximately(moveInput.y,0.0f))
            {
                moveDirection.Set(moveInput.x, moveInput.y);
      	        moveDirection.Normalize();

            }

        playerAnimate.SetFloat("Look X", moveDirection.x);
        playerAnimate.SetFloat("Look Y", moveDirection.y);
        playerAnimate.SetFloat("Speed", moveInput.magnitude);    

        //sprint
        if(action.Player.Sprint.ReadValue<float>() == 1f){
               moveSpeed=200;
               }
        else
        {
            moveSpeed=5f;
        }       


        //cooldown
        if (isInvincible)
            {
                damageCooldown -= Time.deltaTime;
                if (damageCooldown < 0)
                {
                isInvincible = false;
                }
            }
       
    }

    void FixedUpdate()
    {
        //movement
        Vector2 position = (Vector2)playerRB.position + moveInput * moveSpeed * Time.deltaTime;
        
        playerRB.MovePosition(position);
    }

    public void healthChanger(int amount)
    {
        //cooldown
        if (amount < 0)
        {
            if (isInvincible)
            {
                    return;
            }
            isInvincible = true;
            damageCooldown = timeInvincible;
            playerAnimate.SetTrigger("Hit");
        }

        currentHealth = Mathf.Clamp(currentHealth + amount,0,maxHealth);

        Debug.Log("Current health:" + currentHealth);
    }
}
