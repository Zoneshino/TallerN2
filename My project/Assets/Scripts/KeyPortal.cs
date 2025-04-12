using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyPortal : MonoBehaviour
{
    [Header("Nombre exacto de la escena a cargar")]
    public string nextSceneName = "SceneGame2";  // ?? Escena destino

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("?? Jugador recogió la llave. Cargando " + nextSceneName);
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
