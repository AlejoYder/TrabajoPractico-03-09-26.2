using UnityEngine;
using UnityEngine.UI;
public class Persona : MonoBehaviour
{
    [SerializeField] private float Velocidad = 2;
    [SerializeField] private Semaforo semaforo;
    [SerializeField] private Button SolicitarPaso;

    private void Update()
    {
        Moverse();
    }

    public void Moverse()
    {
        if (semaforo.PuedeCruzar())
        {
            transform.Translate(Vector3.right * Velocidad * Time.deltaTime);
        }
    }
    public void MandarSolicitud()
    {
        semaforo.SolicitarCruce();
    }
}