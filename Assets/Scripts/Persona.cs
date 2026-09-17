using UnityEngine;
using static Detector;

public class Persona : MonoBehaviour
{
    [SerializeField] private float Velocidad = 2;
  
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
    private void OnTriggerStay(Collider other)
    {
        Semaforo s = null;
        if (other.CompareTag("Detector"))
        {
            s = other.GetComponent<Detector>().GetSemaforo;

            if (s.EstaEnRojo())
                
                Avanzar();
            else
               Detenerse();
            if (s.EstaEnVerde())
            {
               s.SolicitarCambio();
            }

        }

    }

}