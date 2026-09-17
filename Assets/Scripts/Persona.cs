using UnityEngine;
using UnityEngine.UI;
public class Persona : MonoBehaviour
{
    [SerializeField] private float Velocidad = 2;
    [SerializeField] private Semaforo semaforo;
    [SerializeField] private Button SolicitarPaso;
    public bool puedeMoverse = true; 
    public void Avanzar() => puedeMoverse = true;
    public void Detenerse() => puedeMoverse = false;
    private void Update()
    {
        Moverse();
    }

    public void Moverse()
    {
        if (puedeMoverse)
        {
            transform.Translate(Vector3.right * Velocidad * Time.deltaTime);
        }
    }
    public void MandarSolicitud()
    {
        semaforo.SolicitarCruce();
    }
}