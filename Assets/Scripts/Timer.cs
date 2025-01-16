using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float countdownTime = 300f; // Tiempo inicial en segundos (5 minutos)
    public Text timerText; // Texto en la UI para mostrar el tiempo restante

    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;

        // Resta tiempo al contador
        countdownTime -= Time.deltaTime;

        // Si el tiempo llega a 0, termina la partida
        if (countdownTime <= 0)
        {
            countdownTime = 0;
            GameOver();
        }

        // Actualiza el texto del temporizador
        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(countdownTime / 60);
        int seconds = Mathf.FloorToInt(countdownTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        isGameOver = true;
        Debug.Log("¡Has perdido la partida!");
        // Aquí puedes agregar más lógica, como cargar una escena de Game Over o mostrar un mensaje en pantalla.
    }
}
