using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("Other")]
    [SerializeField] private float attackCooldown;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private PlayerGunAttack playerGunAttack;
    private float cooldownTimer = Mathf.Infinity;
    private bool isDead;
    private bool isAttacking;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    private float horizontalInput;

    [Header("Wall Jump")]
    [SerializeField] private bool onWall;
    [SerializeField] private int id;


    [Header("Portal Positions")]
    public VectorValue statingPosition;


    [Header("Damage Popup")]
    public Transform damagePopup;
    void Start()
    {
        transform.position = statingPosition.initialValue;
    }
    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        playerGunAttack = GetComponent<PlayerGunAttack>();
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(1) && cooldownTimer > attackCooldown && CanAttack() && !isDead)
        {
            anim.SetTrigger("gunAttack");
            cooldownTimer = 0;
        }
        cooldownTimer += Time.deltaTime;
        horizontalInput = Input.GetAxis("Horizontal");

        //Flip player when moving left-right
        if (!onWall && !isDead && !isAttacking)
        {
            if (horizontalInput > 0.01f)
                transform.localScale = new Vector3(-1, 1, 1);
            else if (horizontalInput < -0.01f)
                transform.localScale = new Vector3(1, 1, 1);
        }


        //Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", IsGrounded());
        anim.SetBool("walled", onWall);
        anim.SetBool("swordAttack", Input.GetKeyDown(KeyCode.Mouse0));
        if (!isDead && !isAttacking)
        {

            if (onWall)
            {
                body.velocity = Vector2.zero;
            }
            else
            {
                body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
            }
        }
        //Wall jump logic

        if (onWall && !IsGrounded())
        {
            body.gravityScale = 0;
            body.velocity = Vector2.zero;
        }
        else
            body.gravityScale = 3;

        //Key Input logic

        if (Input.GetKeyDown(KeyCode.Space) && !isDead)
        {
            if (IsGrounded() && !isAttacking)
            {
                body.velocity = new Vector2(body.velocity.x, jumpPower);
                anim.SetTrigger("jump");
            }
            else if (onWall && !IsGrounded())
            {
                if (horizontalInput.Equals(0))
                {
                    onWall = false;
                    body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);

                }
                else if (horizontalInput != 0)
                {
                    onWall = false;
                    body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 6, 12);
                    transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            if (!id.Equals(col.GetInstanceID()))
            {
                if (!IsGrounded())
                {
                    onWall = true;
                    anim.SetTrigger("onWall");
                    id = col.GetInstanceID();
                }
            }
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D groundCheckHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return groundCheckHit.collider != null;
    }

    public bool CanAttack()
    {
        return IsGrounded() && !onWall && !isDead;
    }

    public void GetDamage()
    {
        anim.SetTrigger("getDamage");
        isAttacking = false;

    }

    public void Die()
    {
        if (!isDead)
        {
            anim.SetTrigger("dead");
            isDead = true;
        }
        
    }
    public void engageAttack()
    {
        isAttacking = true;
    }

    public void disengageAttack()
    {
        isAttacking = false;
    }
}

