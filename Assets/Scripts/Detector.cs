using UnityEngine;

public class Detector : MonoBehaviour
{
    public enum TipoDetector { Auto, Peaton}

    [SerializeField] private Semaforo semaforo; 
    [SerializeField] private TipoDetector tipo;

    private void OnTriggerStay(Collider other)
    {
        if (tipo == TipoDetector.Auto && other.CompareTag("Automovil"))
        {
            Automóvil auto = other.GetComponent<Automóvil>();
            if (auto == null) return;

            if (semaforo.EstaEnVerde())
                auto.Avanzar();
            else
                auto.Detenerse();
        }
        else if (tipo == TipoDetector.Peaton && other.CompareTag("Persona"))
        {
            Persona persona = other.GetComponent<Persona>();
            if (persona == null) return;

            if (semaforo.EstaEnRojo())
                persona.Avanzar();
            else 
                persona.Detenerse();
            if (semaforo.EstaEnVerde())
            {
                semaforo.SolicitarCambio();
            }
        }
    }

}
