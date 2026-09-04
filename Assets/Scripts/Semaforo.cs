
using TMPro;
using UnityEngine;

public class Semaforo : MonoBehaviour
{
    [Header("Datos")]
    [SerializeField] private EstadoLuz LuzActual; 
    [SerializeField] private int TiempoActual = 3;
    [SerializeField] public GameObject presenciaAutomovil;
    [SerializeField] public GameObject presenciaPersona;
    [SerializeField] private TextMeshProUGUI TextoTiempo; 
    [SerializeField] private bool SolicitudRecibida;
    [SerializeField] private bool SensorTrafico;

    public enum EstadoLuz
    {
        Rojo,
        Amarillo,
        Verde
    }

    public void Awake()
    {
       LuzActual = EstadoLuz.Verde;
        
       Debug.Log("El semaforo esta Verde");
    }
    public void Start()
    {
        InvokeRepeating(nameof(LogicaCambioLuz),1f, 1f);
    }
 
    public void LogicaCambioLuz()
    {
        TextoTiempo.text = TiempoActual.ToString();
        TiempoActual--;


        if (TiempoActual == 0)
        {

            if (LuzActual == EstadoLuz.Verde)
            {
                LuzActual = EstadoLuz.Amarillo;
                TiempoActual = 3;
                TextoTiempo.color = Color.yellow;
                Debug.Log("El semaforo esta Amarillo");
            }
            else if (LuzActual == EstadoLuz.Amarillo)
            {
                LuzActual = EstadoLuz.Rojo;
                TiempoActual = 27;
                TextoTiempo.color = Color.red;
                Debug.Log("El semaforo esta Rojo");
            }
            else if (LuzActual == EstadoLuz.Rojo)
            {
                LuzActual = EstadoLuz.Verde;
                TiempoActual = 30;
                TextoTiempo.color = Color.green;
                Debug.Log("El semaforo esta Verde");
            }

            
        }
    }
    public void VerEstado()
    {

    }

    public void DetectarSeñal()
    {

    }
}
