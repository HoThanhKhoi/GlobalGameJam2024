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

    //Dash
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCoolDown;
    private float dashTimeCounter;
    private float dashCoolDownCounter;
    private bool canDash;


    private void Awake()
    {
        player = Player.Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        speed = player.stats.playerStatSO.movementSpeed;

        canDash = true;
    }

    // Update is called once per frame
    private void Update()
    {
        HandlePlayerInput();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            HandleDash();
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();


    }

    private void HandlePlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void HandleMovement()
    {
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        rb.velocity = direction * speed;

        // transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void HandleDash()
    {
        if (dashTimeCounter <= 0 && dashCoolDownCounter <= 0)
        {
            Vector2 dashDir = new Vector2(horizontalInput, verticalInput);
            rb.velocity = dashDir * dashSpeed;
        }
    }

}
