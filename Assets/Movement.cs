using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update    public float speed = 5.0f;
    [SerializeField] private PlayerInput playerInput;
    InputAction movement;

    public float speed;

    void Start()
    {
        movement = playerInput.actions.FindAction("Move");
    }

    void Update()
    {
         movePlayer();
    }

    void movePlayer(){
        Vector2 direction = movement.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;

    }
}
