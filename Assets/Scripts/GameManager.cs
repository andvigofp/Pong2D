using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject pelota, player1, player2;

    public int player1Score = 0;
    public int player2Score = 0;

    public bool pvp;

    public void GoalScored(int playerNumber)
    {
        if (playerNumber == 1)
        {
            player1Score++;
            Debug.Log("Punto para Player 1: " + player1Score);
        }
        else if (playerNumber == 2)
        {
            player2Score++;
            Debug.Log("Punto para Player 2: " + player2Score);
        }

        //Comprobar ganador
        if (player1Score >= 7)
        {
            Debug.Log("GANA PLAYER 1");
            StartCoroutine(ResetGameCoroutine());
            return;
        }
        else if (player2Score >= 7)
        {
            Debug.Log("GANA PLAYER 2");
            StartCoroutine(ResetGameCoroutine());
            return;
        }

        //Reset normal
        StartCoroutine(ResetCoroutine());
    }

    private IEnumerator ResetCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        ResetPosicions();
    }

    private IEnumerator ResetGameCoroutine()
    {
        yield return new WaitForSeconds(0.5f);

        player1Score = 0;
        player2Score = 0;

        ResetPosicions();
    }

    private void ResetPosicions()
    {
        pelota.GetComponent<Ball>().Reset();
        player1.GetComponent<Player>().Reset();

        if (pvp)
        {
            player2.GetComponent<IA>().Reset();
        }
    }
}