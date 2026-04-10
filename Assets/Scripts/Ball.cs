using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector2 startPos;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody2D rb;
    public float speedIncrease = 0.1f;
    private bool hasLaunched = false;

    private void Start()
    {
        startPos = transform.position;
    }

   public void OnLanzarPelota()
    {
        if (!hasLaunched)
        {
            Launch();
            hasLaunched = true;
        }
    }
    public void Launch()
    {
        float x = Random.Range(0,2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.linearVelocity = new Vector2(x * speed, y * speed);
    }

    public bool IsMoving()
    {
        return hasLaunched;
    }

    public void Reset()
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        transform.position = startPos;

        hasLaunched = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            rb.linearVelocity *= 1 + speedIncrease;
        }
       
    }
}

