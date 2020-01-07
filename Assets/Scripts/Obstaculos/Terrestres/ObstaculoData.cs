using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoData : MonoBehaviour
{
    public int danoJugador;
    public int casillasLaterales;
    public int casillasVerticales;
    public int vida;
    public bool danoContinuo = false;
    public bool permiteMoneda = false;
    public bool destruible = false;
    public float alturaInicial;
    public Vector3 rotacionInicial;
    public TipoEspacio tipoEspacio;

    private ControladorPuntajes controladorPuntaje;

    public enum TipoEspacio
    {
        //El obstaculo solo ocupa una casilla normal
        unica_casilla= 0,
        //El obstaculo empieza del centro hacia la izquierda
        centro_Izquierda,
        //El obstaculo empieza del centro hacia la derecha
        centro_Derecha,
        //El obstaculo empieza del centro y ocupa los 3 carriles
        centro_Laterales
    };



    // Start is called before the first frame update
    void Start()
    {
        // Setting up the reference.
        GameObject puntaje = GameObject.Find("ControlladorPuntajes");
        controladorPuntaje = puntaje.GetComponent<ControladorPuntajes>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {



        if (other.tag == "DestruirPiso")
        {
            GameObject.Destroy(gameObject);
        }
        else if (other.tag == "Player") {
            this.controladorPuntaje.DisminuirVida(this.danoJugador);
        }

    }
}
