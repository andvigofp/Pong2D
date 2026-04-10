using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private int playerNumber;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGER DETECTADO");

        if (collision.CompareTag("Ball"))
        {
            Debug.Log("GOL");

            gameManager.GoalScored(playerNumber);
        }
    }
}