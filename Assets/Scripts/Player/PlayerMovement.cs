using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Reference
    private Player player;

    //Component
    private Rigidbody2D rb;

    //Input
    private float horizontalInput;
    private float verticalInput;

    private float speed;


    private void Awake()
    {
        player = Player.Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        speed = player.stats.playerStatSO.movementSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        HandlePlayerInput();
    }

    private void FixedUpdate()
    {
        HandleMovement();


    }

    private void HandlePlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Debug.Log(horizontalInput + " " + verticalInput);
    }

    private void HandleMovement()
    {
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        rb.velocity = direction * speed;
    }

}
