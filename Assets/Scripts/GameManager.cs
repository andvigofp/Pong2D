using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Referencias a objetos del juego
    public GameObject pelota, player1, player2;

    // Variables de puntuación
    public int player1Score = 0, player2Score = 0;

    // Referencias a los textos UI (TextMeshPro)
    public TMPro.TextMeshProUGUI player1ScoreText, player2ScoreText;

    // Indica si es jugador vs jugador o contra IA
    public bool pvp;

    // Método que se llama cuando alguien marca un gol
    public void GoalScored(int playerNumber)
    {
        // Si marca el jugador 1
        if (playerNumber == 1)
        {
            player1Score++; // Aumenta su puntuación
            player1ScoreText.text = player1Score.ToString(); // Actualiza el texto en pantalla
            Debug.Log("Punto para Player 1: " + player1Score);
        }
        // Si marca el jugador 2
        else if (playerNumber == 2)
        {
            player2Score++; // Aumenta su puntuación
            player2ScoreText.text = player2Score.ToString(); // Actualiza el texto en pantalla
            Debug.Log("Punto para Player 2: " + player2Score);
        }

        // Comprobación de victoria (primero en llegar a 7)
        if (player1Score >= 7)
        {
            Debug.Log("GANA PLAYER 1");
            StartCoroutine(ResetGameCoroutine()); // Reinicia todo el juego
            return;
        }
        else if (player2Score >= 7)
        {
            Debug.Log("GANA PLAYER 2");
            StartCoroutine(ResetGameCoroutine()); // Reinicia todo el juego
            return;
        }

        // Si no hay ganador, solo reinicia posiciones
        StartCoroutine(ResetCoroutine());
    }

    // Coroutine para reiniciar posiciones tras un gol
    private IEnumerator ResetCoroutine()
    {
        yield return new WaitForSeconds(0.5f); // Pequeña pausa
        ResetPosicions(); // Reinicia posiciones de pelota y jugadores
    }

    // Coroutine para reiniciar todo el juego (cuando alguien gana)
    private IEnumerator ResetGameCoroutine()
    {
        yield return new WaitForSeconds(0.5f); // Pausa antes de reiniciar

        // Reinicia puntuaciones
        player1Score = 0;
        player2Score = 0;

        // Actualiza el marcador en pantalla
        player1ScoreText.text = "0";
        player2ScoreText.text = "0";

        ResetPosicions(); // Reinicia posiciones
    }

    // Método que resetea posiciones de todos los elementos
    private void ResetPosicions()
    {
        // Reinicia la pelota
        pelota.GetComponent<Ball>().Reset();

        // Reinicia jugador 1
        player1.GetComponent<Player>().Reset();

        // Si es modo contra IA, reinicia jugador 2 como IA
        if (pvp)
        {
            player2.GetComponent<IA>().Reset();
        }
    }
}