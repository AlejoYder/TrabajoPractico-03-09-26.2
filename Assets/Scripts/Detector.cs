using UnityEngine;

public class Detector : MonoBehaviour
{
    public enum TipoDetector { Auto, Peaton}

    [SerializeField] private Semaforo semaforo; 
    [SerializeField] private TipoDetector tipo;

    public Semaforo GetSemaforo => semaforo;
    
}
