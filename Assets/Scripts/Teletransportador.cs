using UnityEngine;

public class Teletransportador : MonoBehaviour
{
    public Transform puntoDeDestino; // Arrastra aquí la posición dentro de la nave
    public GameObject objetoATeletransportar; // Puede ser el jugador o la cámara

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objetoATeletransportar)
        {
            objetoATeletransportar.transform.position = puntoDeDestino.position;
            objetoATeletransportar.transform.rotation = puntoDeDestino.rotation;
        }
    }
}
