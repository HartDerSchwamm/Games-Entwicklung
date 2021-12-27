using UnityEngine;

public class SkeletonProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private bool fire;
    private float direction;

    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (hit)
        {
            return;
        }
        else if (fire) 
        {
            float movementSpeed = speed * Time.deltaTime * direction;
            transform.Translate(movementSpeed, 0, 0); 
        }       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        fire = false;
        boxCollider.enabled = false;
        anim.SetTrigger("Hit");
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().TakeDamage(1);
        }
    }

    public void Charge()
    {
        gameObject.SetActive(true);
        hit = false;      
    }

    public void Fire()
    {
        boxCollider.enabled = true;
        fire = true;
        anim.SetTrigger("Fire");
    }

    public void SetDirection(float direction)
    {
        this.direction = direction;
        gameObject.SetActive(true);
        hit = false;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) == direction)
        {
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
