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


    void Awake()
    {
        action = new InputSystem_Actions();
    }
    void Start()
    {
       playerRB=GetComponent<Rigidbody2D>();
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
}
