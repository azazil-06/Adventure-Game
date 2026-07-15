using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private InputSystem_Actions action;
    Rigidbody2D playerRB;
    [SerializeField] private Vector2 moveInput;

    [SerializeField] private float moveSpeed =5f;

    public int maxHealth = 5;
    int currentHealth;


    void Awake()
    {
        action = new InputSystem_Actions();
    }
    void Start()
    {
       playerRB=GetComponent<Rigidbody2D>();

       currentHealth=maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        action.Player.Enable();
        moveInput = action.Player.Move.ReadValue<Vector2>();

        //sprint
        if(action.Player.Sprint.ReadValue<float>() == 1f){
               moveSpeed=200;
               }
        else
        {
            moveSpeed=5f;
        }       

       
    }

    void FixedUpdate()
    {
        Vector2 position = (Vector2)playerRB.position + moveInput * moveSpeed * Time.deltaTime;
        
        playerRB.MovePosition(position);
    }

    public void health(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount,0,maxHealth);
    }
}
