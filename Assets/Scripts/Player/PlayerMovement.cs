using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private float speed = 4f;

    private float randomY;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandlePlayerInput();
    }

    private void FixedUpdate() {
        HandleMovement();
    }

    private void HandlePlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void HandleMovement()
    {
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        rb.velocity = direction * speed;

        // transform.Translate(direction * _speed * Time.deltaTime);
    }


}
