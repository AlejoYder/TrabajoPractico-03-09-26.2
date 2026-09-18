using UnityEngine;

public class RedElectrica : MonoBehaviour
{
    public static RedElectrica instance;
    [SerializeField] private bool on = true;
    public bool On {  
        get
        { return on; } 

        private set 
        { on = value; }
    }

    private void Awake()
    {
        instance = this;
    }
    public void ActivarRed()
    {
        on = true;
    }
}
