using UnityEngine;
using static Detector;

public class Automóvil : MonoBehaviour
{
    [SerializeField] private float velocidad = 5;
   
    private bool puedeMoverse = true;

    public void Avanzar() => puedeMoverse = true;
    public void Detenerse () => puedeMoverse = false;
    private void Update()
    {
        Moverse();
    }
    public void Moverse()
    {
        if (puedeMoverse)
        {
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Detector"))
        {

            if (other.GetComponent<Detector>().GetSemaforo.EstaEnVerde())
                Avanzar();
            else
              Detenerse();
        }
    }
}
