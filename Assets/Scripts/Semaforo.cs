
using TMPro;
using UnityEngine;

public class Semaforo : MonoBehaviour
{
    [Header("Datos")]
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
    public void SolicitarCruce()
    {
      
        if (SensorTrafico)
        {
            Debug.Log("Hay un automovil. No se puede solicitar el cruce.");
            return;
        }

        DetectarSeñal();
    }
    public void LogicaCambioLuz()
    {
        VerEstado();
        TextoTiempo.text = TiempoActual.ToString();
        TiempoActual--;


        if (TiempoActual == 0)
        {

            if (LuzActual == EstadoLuz.Verde)
            {
                LuzActual = EstadoLuz.Amarillo;
                TiempoActual = 3;
                TextoTiempo.color = Color.yellow;
                //Debug.Log("El semaforo esta Amarillo");
            }
            else if (LuzActual == EstadoLuz.Amarillo)
            {
                LuzActual = EstadoLuz.Rojo;
                TiempoActual = 3;
                TextoTiempo.color = Color.red;
                //Debug.Log("El semaforo esta Rojo");
            }
            else if (LuzActual == EstadoLuz.Rojo)
            {
                LuzActual = EstadoLuz.Verde;
                TiempoActual = 3;
                TextoTiempo.color = Color.green;
                //Debug.Log("El semaforo esta Verde");
            }
            VerEstado();
        }
    }

    
    public void VerEstado()
    {
        TextoTiempo.text = TiempoActual.ToString();

        Debug.Log(
            "Estado del semaforo: " + LuzActual +
            " | Tiempo restante: " + TiempoActual
        );
    }


  
    public void DetectarSeñal()
    {
        SolicitudRecibida = true;

        Debug.Log("Señal peatonal detectada.");

    
        if (LuzActual == EstadoLuz.Verde)
        {
            LuzActual = EstadoLuz.Amarillo;
            TiempoActual = 3;

            TextoTiempo.color = Color.yellow;

            SolicitudRecibida = false;

            Debug.Log("Solicitud aceptada. El semaforo pasa a Amarillo.");
        }

  
        else if (LuzActual == EstadoLuz.Amarillo)
        {
            Debug.Log("Solicitud recibida. El semaforo ya esta cambiando.");
        }

        // Si está rojo, la persona ya puede cruzar.
        else if (LuzActual == EstadoLuz.Rojo)
        {
            Debug.Log("El semaforo ya esta Rojo. La persona puede cruzar.");

            SolicitudRecibida = false;
        }
    }


    // Comprueba si el semáforo está en rojo.
    // Lo utiliza Automóvil.
    public bool EstaEnRojo()
    {
        return LuzActual == EstadoLuz.Rojo;
    }


    // Comprueba si el semáforo está en verde.
    public bool EstaEnVerde()
    {
        return LuzActual == EstadoLuz.Verde;
    }


    // Comprueba si la persona puede cruzar.
    public bool PuedeCruzar()
    {
        return LuzActual == EstadoLuz.Rojo;
    }


    // DETECTAR AUTOMÓVIL

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Automovil"))
        {
            SensorTrafico = true;

            Debug.Log("Automovil detectado por el sensor.");
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Automovil"))
        {
            SensorTrafico = false;

            Debug.Log("Automovil salio del sensor.");
        }
    }
}