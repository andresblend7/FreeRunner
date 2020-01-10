using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoEspada : MonoBehaviour
{

    private Personaje personaje;

    //variable que controla la velocidad de movimiento del enemigo
    public float velocidadMovimiento;

    //Variable para determinar si se debe mover a la velocidad del personaje
    public bool distanciaOptima = true;



    // Start is called before the first frame update
    void Start()
    {

        // Setting up the reference.
        GameObject puntaje = GameObject.Find("Jugador");
        personaje = puntaje.GetComponent<Personaje>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //movemos al enemigo ligeramente más lento que el personaje si aún no está a la distancia optima
        if (!this.distanciaOptima)
        {

            //Disminuimos ligeramente la velocidad
            if (Globals.NIVEL_ACTUAL < 4)
                this.velocidadMovimiento = (this.personaje.velocidadMovimiento - 0.6f);
            else
                this.velocidadMovimiento = (this.personaje.velocidadMovimiento - 0.4f);

            //Movemos al enemigo a la velocidad de movimiento del personaje
            this.gameObject.transform.Translate(Vector3.left * (Time.deltaTime + (this.velocidadMovimiento)));

        }
        else
        {
            //Movemos al personaje a la misma velocidad que el personaje
            this.velocidadMovimiento = this.personaje.velocidadMovimiento;

            //Movemos al enemigo a la velocidad de movimiento del personaje
            this.gameObject.transform.Translate(Vector3.left * (Time.deltaTime + (this.velocidadMovimiento)));

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger ->enemigo" + other.tag);
        //Actiamos la bandera para mover al enemigo a la misma velocidad que el personaje   
        if (other.tag == "SensorEnemigos")
        {
            this.distanciaOptima = true;
        }
    }
}
