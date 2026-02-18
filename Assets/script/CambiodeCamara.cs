
using UnityEngine;

public class CambiodeCamara : MonoBehaviour
{
    public Camera camara1; // Cámara inicial
    public Camera camara2; // Cámara a la que cambiar
    private bool yaCambio = false; // Para que solo cambie una vez

    private void Start()
    {
        if (camara1 == null || camara2 == null)
        {
            Debug.LogError("Asigna camara1 y camara2 en el Inspector!");
            return;
        }

        camara1.enabled = true;
        camara2.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Solo se dispara una vez y solo si entra el jugador
        if (!yaCambio && other.CompareTag("Player"))
        {
            camara1.enabled = false;
            camara2.enabled = true;
            yaCambio = true;
            Debug.Log("Cambio de cámara activado!");
        }
    }
}
