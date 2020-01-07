using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Clase para controlar los puntajes de nivel, monedas y demás 
/// </summary>
public class ControladorPuntajes : MonoBehaviour
{

    public Text txtContadorMonedas, txtContadorMetros, txtVidaActual;
    public Text txtDebugger;
    public Personaje personaje;

    private float posicionInicialPersonaje;


    private int contadorMonedas = 0, contadorMetros = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        this.posicionInicialPersonaje = personaje.gameObject.transform.position.z;

        //Creamos el job para actualizar los metros recorridos  cada x tiempo
        InvokeRepeating("AumentarMedidorMetros", 0.40f, 0.40f);
    }

    // Update is called once per frame
    void Update()
    {



    }

    /// <summary>
    /// Método para incrementar el puntaje de metros recorridos
    /// </summary>
    private void AumentarMedidorMetros()
    {

        //Incrementamos el medidor
        this.contadorMetros = (int)Math.Round(personaje.gameObject.transform.position.z - this.posicionInicialPersonaje);

        //Actualizamos la interfaz
        this.txtContadorMetros.text = (this.contadorMetros).ToString() + " m";

        //Comprobamos si debemos actualizar la velocidad del personaje
        this.AumentarVelocidadPersonaje(this.contadorMetros);
    }


    /// <summary>
    /// Método para aumentar la velocidad del personaje según los metros recorridos
    /// </summary>
    /// <param name="metrosRecorridos"></param>
    public void AumentarVelocidadPersonaje(int metrosRecorridos)
    {

        if (metrosRecorridos <= 150)
        {
            this.personaje.velocidadMovimiento = 0.25f;
            Globals.NIVEL_ACTUAL = 0;
        }
        else if (metrosRecorridos <= 270)
        {
            this.personaje.velocidadMovimiento = 0.30f;
            Globals.NIVEL_ACTUAL = 1;
        }
        else if (metrosRecorridos <= 560)
        {
            this.personaje.velocidadMovimiento = 0.35f;
            Globals.NIVEL_ACTUAL = 2;
        }
        else if (metrosRecorridos <= 900)
        {
            this.personaje.velocidadMovimiento = 0.40f;
            Globals.NIVEL_ACTUAL = 3;
        }
        else if (metrosRecorridos <= 1450)
        {
            this.personaje.velocidadMovimiento = 0.45f;
            Globals.NIVEL_ACTUAL = 4;
        }
        else if (metrosRecorridos <= 2400)
        {
            this.personaje.velocidadMovimiento = 0.50f;
            Globals.NIVEL_ACTUAL = 5;
        }
        else if (metrosRecorridos <= 4000)
        {
            this.personaje.velocidadMovimiento = 0.55f;
            Globals.NIVEL_ACTUAL = 6;
        }
        else if (metrosRecorridos <= 6500)
        {
            this.personaje.velocidadMovimiento = 0.60f;
            Globals.NIVEL_ACTUAL = 7;
        }
        else if (metrosRecorridos <= 10000)
        {
            this.personaje.velocidadMovimiento = 0.65f;
            Globals.NIVEL_ACTUAL = 8;
        }
        else if (metrosRecorridos > 10001)
        {
            this.personaje.velocidadMovimiento = 0.70f;
            Globals.NIVEL_ACTUAL = 9;
        }

        //Debug Nivel
        this.txtDebugger.text = Globals.NIVEL_ACTUAL.ToString();

    }



    /// <summary>
    /// Método para incrementar el contador de monedas
    /// </summary>
    /// <param name="cantidad"></param>
    public void SumarMonedas(int cantidad)
    {
        this.contadorMonedas += cantidad;
        this.txtContadorMonedas.text = this.contadorMonedas.ToString();
    }

    public void DisminuirVida(int danio) {

        txtVidaActual.text = Globals.QuitarVida(danio).ToString();

    }

}
