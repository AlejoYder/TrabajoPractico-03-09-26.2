using UnityEngine;

public class Automóvil : MonoBehaviour
{
    [SerializeField] private float velocidad = 5;
    [SerializeField] private Semaforo semaforo;

    private void Update()
    {
        Moverse();
    }
    private void Moverse()
    {
        if (semaforo.EstaEnVerde())
        {
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        }

    }
}
