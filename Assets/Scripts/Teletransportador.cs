using System.Collections;
using UnityEngine;

public class Teletransportador : MonoBehaviour
{
    public Transform teleportDestination; // Lugar al que se teletransportará el jugador
    public OVRScreenFade screenFade; // Para hacer un efecto de desvanecimiento
    public GameObject player; // OVRCameraRig (se asigna en Unity)
    public Animator anim;

    private void Start()
    {
        // Si el jugador no está asignado, intenta encontrarlo automáticamente
        if (player == null)
        {
            player = GameObject.Find("OVRCameraRig"); // Asegúrate de que se llama así en la jerarquía
        }

        if (player == null)
        {
            Debug.LogError("No se encontró OVRCameraRig en la escena. Asigna el objeto manualmente en el Inspector.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Objeto entró en el trigger: " + other.gameObject.name);

        if (other.gameObject == player)
        {
            Debug.Log("Jugador detectado, iniciando teletransporte...");
            StartCoroutine(TeleportPlayer(player.transform));
        }
    }


    IEnumerator TeleportPlayer(Transform playerTransform)
    {
        if (screenFade != null)
        {
            screenFade.FadeOut(); // Pantalla negra para suavizar la transición
            yield return new WaitForSeconds(0.5f); // Espera un poco antes de teletransportar
        }

        playerTransform.position = teleportDestination.position;
        playerTransform.rotation = teleportDestination.rotation; // Teletransporta al jugador
        Debug.Log("Jugador teletransportado a " + teleportDestination.position);

        Collider collider = GetComponent<Collider>();
        collider.enabled = false;

        anim.SetTrigger("Recorrido");

        if (screenFade != null)
        {
            screenFade.FadeIn(); // Vuelve a mostrar la pantalla
        }

        

        yield return null;

    }
}
