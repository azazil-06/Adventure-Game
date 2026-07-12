using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private InputSystem_Actions action;
    [SerializeField] private Vector3 moveInput;

    [SerializeField] private float moveSpeed =5f;


    void Awake()
    {
        action = new InputSystem_Actions();
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        action.Player.Enable();
        moveInput = action.Player.Move.ReadValue<Vector2>();

        Debug.Log(action.Player.Sprint.ReadValue<float>());

        if(action.Player.Sprint.ReadValue<float>() == 1f){
               moveSpeed=200;
               }
        else
        {
            moveSpeed=5f;
        }       

        transform.position += Vector3.up *moveSpeed * Time.deltaTime * moveInput.y;

        // r-l movement
        transform.position += Vector3.right * moveSpeed * Time.deltaTime *moveInput.x;
    }
}
