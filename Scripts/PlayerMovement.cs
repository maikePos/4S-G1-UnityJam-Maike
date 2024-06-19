using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    PlayerInput playerInput;
    InputAction moveAction;
    private Rigidbody rb;

   [SerializeField] float speed = 3.14159265f;

    public GameObject flashLight;
    public bool isOn;

    public GameObject winGame;

    private void Start()
    {
        flashLight.SetActive(false);
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");

        winGame.SetActive(false);
    }

    private void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (isOn)
            {
                FlashLightOff();
            }

            else
            {
                FlashLightOn();
            }
           
        }
    }

    private void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime;
    }

    private void FlashLightOn()
    {
        flashLight.SetActive(true);
        isOn = true;
    }

    private void FlashLightOff()
    {
        flashLight.SetActive(false);
        isOn = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            winGame.SetActive(true);

            Debug.Log("you won!");
            Time.timeScale = 0f;
        }


        
    }
}
