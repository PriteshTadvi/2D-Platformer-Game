using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float playerSpeed = 10f;
    public InputAction moveAction;
    public InputAction jumpAction;
    [SerializeField] private float jumpforce = 10f;
    public Vector2 moveInput;
    private Rigidbody2D rb;
    public Transform groundcheck;
    public float groundcheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();
        jumpAction.Enable();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        transform.Translate(Vector2.right * moveInput.x * Time.deltaTime * playerSpeed);

        if (jumpAction.triggered && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckRadius, groundLayer);
    }
}

