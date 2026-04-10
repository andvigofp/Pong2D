using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private bool playerleft; 
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] public float speed = 5f; 
    [SerializeField] private float movement = 0f;

    private Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    public void OnMove(InputValue value)
    {
        Debug.Log("INPUT DETECTADO");

        Vector2 input = value.Get<Vector2>();
        movement = input.y;
    }


    private void Update()
    {
        rb.linearVelocityY = movement * speed;

        //Limitar movimiento
        float y = Mathf.Clamp(transform.position.y, -3.5f, 3.5f);
        transform.position = new Vector2(transform.position.x, y);
    }

   
    public void Reset()
    {
        movement = 0f;
        rb.linearVelocity = Vector2.zero;
        transform.position = startPos;
    }
    
}