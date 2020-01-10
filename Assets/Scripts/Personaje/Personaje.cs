using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Personaje : MonoBehaviour // 2
{

   // public GameObject personaje;
    [Range(0.25f, 0.70f)]
    public float velocidadMovimiento;

    //Movimiento
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
    public Text textoDebugger;
    public RawImage flechaIzquierda, flechaDerecha;

    //Movimiento entre carriles
    public int carrilActual = (int)Globals.Carriles.Central;
    private bool moverAlCarrilCentral = false, moverAlCarrilIzquierdo = false,  moverAlCarrilDerecho = false;
    public bool saltarPersonaje = false, caerPersonaje = false;
    private float velocidadCambio = 5, velocidadSalto = 9f, velocidadCaida = 1f;
    private float alturaSalto = 1.3f;




    //Controllador de animaciones 
    private Animaciones animacionesController;

    
    // Start is called before the first frame update
    void Start()
    {
        this.velocidadMovimiento = 0.25f;
        dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen

        textoDebugger.text = "Started";

        this.animacionesController = this.GetComponent<Animaciones>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Línea encargada de mover el personaje hacia adelante todo el tiempo
        this.gameObject.transform.Translate(Vector3.forward * (Time.deltaTime + this.velocidadMovimiento));


        if (Globals.debugModePc)
        {

            if (Input.GetKeyDown("a"))
            {
                textoDebugger.text = "left - PC";
                this.MoverPersonajeIzquierda();
            }

            if (Input.GetKeyDown("d"))
            {
                textoDebugger.text = "right - PC";
                this.MoverPersonajeDerecha();
            }

            if (Input.GetKeyDown("w"))
            {
                textoDebugger.text = "up - PC";
                this.Saltar();
            }

            if (Input.GetKeyDown("e"))
            {
                this.AtacarEspada();
            }
          
        }

        if (this.moverAlCarrilCentral)
        {

            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position,
                                                    new Vector3(0, this.gameObject.transform.position.y,
                                                    this.gameObject.transform.position.z), Time.deltaTime * this.velocidadCambio);

            this.carrilActual = (int)Globals.Carriles.Central;

            if (this.gameObject.transform.position.x == 0)
                this.moverAlCarrilCentral = false;
        }

        if (this.moverAlCarrilDerecho)
        {

            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position,
                                                       new Vector3(1, this.gameObject.transform.position.y,
                                                       this.gameObject.transform.position.z), Time.deltaTime * this.velocidadCambio);

            this.carrilActual = (int)Globals.Carriles.Derecho;

            if (this.gameObject.transform.position.x == 1)
                this.moverAlCarrilDerecho = false;

        }

        if (this.moverAlCarrilIzquierdo)
        {

            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position,
                                                    new Vector3(-1, this.gameObject.transform.position.y,
                                                    this.gameObject.transform.position.z), Time.deltaTime * this.velocidadCambio);


            this.carrilActual = (int)Globals.Carriles.Izquierdo;

            if (this.gameObject.transform.position.x == -1)
                this.moverAlCarrilIzquierdo = false;

        }

        if (this.saltarPersonaje) {

            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position,
                                                    new Vector3(this.gameObject.transform.position.x, this.alturaSalto,
                                                    this.gameObject.transform.position.z), Time.deltaTime * this.velocidadSalto);


            if (this.velocidadSalto >= 4f)
                this.velocidadSalto -= 1f;

            if (this.gameObject.transform.position.y > (this.alturaSalto - 0.2f)) {
                this.saltarPersonaje = false;
                this.caerPersonaje = true ;
                this.velocidadSalto = 9;
            }
        }

        if (this.caerPersonaje) {

            //Movemos el personaje hasta el piso
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position,
                                                  new Vector3(this.gameObject.transform.position.x, 0,
                                                  this.gameObject.transform.position.z), Time.deltaTime * this.velocidadCaida);

            //Aumentamos progresivamente la velocidad de caida
           

                if (this.velocidadCaida < 4f)
                    this.velocidadCaida += 1f;
         
           

            //Deteneos todo cuando llega al piso.
            if (this.gameObject.transform.position.y == 0) {
                this.caerPersonaje = false;
                this.velocidadCaida = 0;
            }
        }
            
    }

    public void BloquearEscudo(bool bloquear)
    {
        this.animacionesController.AnimBloquearEscudo(bloquear);

    }

    public void AtacarEspada()
    {
        this.animacionesController.AnimAtacarEspada();
    }

    public void Saltar()
    {
        this.saltarPersonaje = true;
    }


    /// <summary>
    /// Método para mover el personaje un carril hacia la derecha
    /// </summary>
    public void MoverPersonajeDerecha()
    {
        Debug.Log($"Carril Actual => {this.carrilActual}");

        //Personaje se encuentra en el centro
        if (this.gameObject.transform.position.x == 0)
        {
            Debug.Log("Se moverá a carril de la derecha");
            this.moverAlCarrilDerecho = true;

        }
        else if (this.gameObject.transform.position.x == -1)
        {
            Debug.Log("Se moverá a carril del centro");
            this.moverAlCarrilCentral = true;
        }
        else
        {
            Debug.Log("Imposible mover hacia la derecha");
        }


    }

    public void MoverPersonajeIzquierda()
    {
        Debug.Log($"Carril Actual => {this.carrilActual}");


        if (this.gameObject.transform.position.x == 0)
        {
            Debug.Log("Se moverá a carril de la Izquierda");
            this.moverAlCarrilIzquierdo = true;

        }
        else if (this.gameObject.transform.position.x == 1)
        {
            Debug.Log("Se moverá a carril del centro");
            this.moverAlCarrilCentral = true;

        }
        else
        {
            Debug.Log("Imposible mover hacia la izquierda");
        }

    }
}
