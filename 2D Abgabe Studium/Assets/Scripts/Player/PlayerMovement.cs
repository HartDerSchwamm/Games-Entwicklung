using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("Other")]
    [SerializeField] private float gunCooldown;
    [SerializeField] private float swordCooldown;
    [SerializeField] private string activeWeapon = "Hades_sword";
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private PlayerGunAttack playerGunAttack;
    private float gunCooldownTimer = Mathf.Infinity;
    private float swordCooldownTimer = Mathf.Infinity;
    private bool isDead;
    private bool isShooting;
    private bool isMeeleing;
    

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

        gunCooldownTimer += Time.deltaTime;
        swordCooldownTimer += Time.deltaTime;
        horizontalInput = Input.GetAxis("Horizontal");

        //Flip player when moving left-right
        if (!onWall && !isDead && !isShooting && !isMeeleing)
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

        if (!isDead && !isShooting && !isMeeleing)
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

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetActiveWeapon("Hades_sword");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetActiveWeapon("ygg_sword");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetActiveWeapon("Tantalus_sword");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetActiveWeapon("Remment_sword");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetActiveWeapon("Demeres_sword");
        }

        if (Input.GetMouseButtonDown(0) && swordCooldownTimer > swordCooldown && CanAttack() && !isDead && !isShooting)
        {
            isMeeleing = true;
            anim.SetTrigger("swordAttack");
            swordCooldownTimer = 0;
        }

        if (Input.GetMouseButtonDown(1) && gunCooldownTimer > gunCooldown && CanAttack() && !isDead && !isMeeleing)
        {
            isShooting = true;
            anim.SetTrigger("gunAttack");
            gunCooldownTimer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isDead)
        {
            if (IsGrounded() && !isShooting && !isMeeleing)
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
        isShooting = false;
        isMeeleing = false;
        gameObject.transform.GetChild(2).GetChild(0).GetChild(2).GetChild(0).GetChild(1).transform.Find(activeWeapon).gameObject.GetComponent<PolygonCollider2D>().enabled = false;

    }

    public void Die()
    {
        if (!isDead)
        {
            anim.SetTrigger("dead");
            isDead = true;
        }
        
    }

    public void SetActiveWeapon(string newWeapon)
    {
        GameObject oldWeaponObj = gameObject.transform.GetChild(2).GetChild(0).GetChild(2).GetChild(0).GetChild(1).transform.Find(activeWeapon).gameObject;
        oldWeaponObj.SetActive(false);
        GameObject newWeaponObj = gameObject.transform.GetChild(2).GetChild(0).GetChild(2).GetChild(0).GetChild(1).transform.Find(newWeapon).gameObject;
        newWeaponObj.SetActive(true);
        activeWeapon = newWeapon;
    }

    public void deactivateRangedAttack()
    {
        isShooting = false;
    }
    public void activateMeeleAttack()
    {
        gameObject.transform.GetChild(2).GetChild(0).GetChild(2).GetChild(0).GetChild(1).transform.Find(activeWeapon).gameObject.GetComponent<PolygonCollider2D>().enabled = true;
    }

    public void deactivateMeeleAttack()
    {
        isMeeleing = false;
        gameObject.transform.GetChild(2).GetChild(0).GetChild(2).GetChild(0).GetChild(1).transform.Find(activeWeapon).gameObject.GetComponent<PolygonCollider2D>().enabled = false;
    }
}

