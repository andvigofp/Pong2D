using UnityEngine;

public class IA : MonoBehaviour
{
   [SerializeField] private float speed = 5f;
   [SerializeField] private GameObject ball;
   private Vector2 startPos;

    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float diferencia = ball.transform.position.y - transform.position.y;

        if (Mathf.Abs(diferencia) > 0.2f)
        {
            if (diferencia > 0)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
        }
    }

    public void Reset()
    {
        transform.position = startPos;
    }
}
