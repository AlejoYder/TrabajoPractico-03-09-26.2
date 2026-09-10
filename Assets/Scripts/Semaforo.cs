
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class Semaforo : MonoBehaviour
{
    [Header("Datos semaforo")]
    [SerializeField] private EstadoLuz LuzActual;
    [SerializeField] private int TiempoActual = 5;
    [Header("GameObject")]
    [SerializeField] public GameObject presenciaAutomovil;
    [SerializeField] public GameObject presenciaPersona;
    [Header("Luces")]
    [SerializeField] private Renderer luzVerde;
    [SerializeField] private Renderer luzAmarillo;
    [SerializeField] private Renderer luzRojo;
    [SerializeField] private Material materialApagado;
    [SerializeField] private Material materialRojoEncendido;
    [SerializeField] private Material materialAmarilloEncendido;
    [SerializeField] private Material materialVerdeEncendido;
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI TextoTiempo;
    [SerializeField] private Button BotonAutomovil;
    [SerializeField] private Button BotonPeaton;
    [Header("bool")]
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
        luzVerde.material = materialVerdeEncendido;
        // Debug.Log("El semaforo esta Verde");
    }
    public void Start()
    {
        InvokeRepeating(nameof(LogicaCambioLuz),1f, 1f);
    }

    private void CambiarEstado(EstadoLuz nuevoEstado)
    {
        LuzActual = nuevoEstado;
        TiempoActual = 5;

        luzVerde.material = materialApagado;
        luzAmarillo.material = materialApagado;
        luzRojo.material = materialApagado;

        switch (nuevoEstado)
        {
            case EstadoLuz.Verde:
                TextoTiempo.color = Color.green;
                luzVerde.material = materialVerdeEncendido;

                break;
            case EstadoLuz.Amarillo:
                TextoTiempo.color = Color.yellow;
                luzAmarillo.material = materialAmarilloEncendido;

                break;
            case EstadoLuz.Rojo:
                TextoTiempo.color = Color.red;
                luzRojo.material = materialRojoEncendido;
                break;
        }

        Debug.Log("El semaforo esta " + nuevoEstado);
    }

    public void LogicaCambioLuz()
    {
        TiempoActual--;

        if (TiempoActual < 0 && !SolicitudRecibida)
        {
            if 
                (LuzActual == EstadoLuz.Verde) CambiarEstado(EstadoLuz.Amarillo);
            else if 
                (LuzActual == EstadoLuz.Amarillo) CambiarEstado(EstadoLuz.Rojo);
            else if 
                (LuzActual == EstadoLuz.Rojo) CambiarEstado(EstadoLuz.Verde);

            VerEstado();
        }

        TextoTiempo.text = TiempoActual.ToString();
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
            CambiarEstado(EstadoLuz.Amarillo);
            SolicitudRecibida = false;
        }
        else if (LuzActual == EstadoLuz.Amarillo)
        {
            Debug.Log("Solicitud recibida. El semaforo ya esta cambiando.");
        }
        else if (LuzActual == EstadoLuz.Rojo)
        {
            Debug.Log("El semaforo ya esta Rojo. La persona puede cruzar.");
            SolicitudRecibida = false;
        }
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
    public void VerEstadoPeaton()
    {
        if (PuedeCruzar())
            Debug.Log("El peaton puede cruzar.");
        else
            Debug.Log("El peaton debe esperar.");
    }

    public void VerEstadoAuto()
    {
        if (EstaEnVerde())
            Debug.Log("El auto puede avanzar.");
        else
            Debug.Log("El auto debe detenerse.");
    }
}