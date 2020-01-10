using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

/// <summary>
/// Clase encargada de generar cada obstáculo en la posición del generador
/// </summary>
public class GeneradorObstaculos : MonoBehaviour
{

    public GameObject[] obstaculos;

    Random randomGenerator;

    private int carrilIzquierdo = -1, carrilCentral = 0, carrilDerecho = 1;

    //var debug, borrar
    public bool generarObstaculos;

    /// <summary>
    /// Array que contentiene las probabilidades de primer, segundo y tercer intento de generación de obstáculo
    /// </summary>
    private ProbabilidadesObstaculos[] probabilidadesObstaculos = new ProbabilidadesObstaculos[10];

    private void Awake()
    {
        //Instantiate random number generator using system-supplied value as seed.
        this.randomGenerator = new Random();

        #region PorcentajesProbabilidades
        //Instanciamos las probabilidades
        probabilidadesObstaculos[0] = new ProbabilidadesObstaculos() { Nivel = 0, ProbabilidadGeneral = 7, ProbabilidadSegundoObstaculo = 0, ProbabilidadTercerObstaculo = 0 }; 
        probabilidadesObstaculos[1] = new ProbabilidadesObstaculos() { Nivel = 1, ProbabilidadGeneral = 6, ProbabilidadSegundoObstaculo = 6, ProbabilidadTercerObstaculo = 0 }; 
        probabilidadesObstaculos[2] = new ProbabilidadesObstaculos() { Nivel = 2, ProbabilidadGeneral = 7, ProbabilidadSegundoObstaculo = 5, ProbabilidadTercerObstaculo = 1 }; 
        probabilidadesObstaculos[3] = new ProbabilidadesObstaculos() { Nivel = 3, ProbabilidadGeneral = 8, ProbabilidadSegundoObstaculo = 7, ProbabilidadTercerObstaculo = 3 }; 
        probabilidadesObstaculos[4] = new ProbabilidadesObstaculos() { Nivel = 4, ProbabilidadGeneral = 10, ProbabilidadSegundoObstaculo = 8, ProbabilidadTercerObstaculo = 2 }; 
        probabilidadesObstaculos[5] = new ProbabilidadesObstaculos() { Nivel = 5, ProbabilidadGeneral = 11, ProbabilidadSegundoObstaculo = 8, ProbabilidadTercerObstaculo = 4 }; 
        probabilidadesObstaculos[6] = new ProbabilidadesObstaculos() { Nivel = 6, ProbabilidadGeneral = 12, ProbabilidadSegundoObstaculo = 9, ProbabilidadTercerObstaculo = 5 }; 
        probabilidadesObstaculos[7] = new ProbabilidadesObstaculos() { Nivel = 7, ProbabilidadGeneral = 15, ProbabilidadSegundoObstaculo = 10, ProbabilidadTercerObstaculo = 7 }; 
        probabilidadesObstaculos[8] = new ProbabilidadesObstaculos() { Nivel = 8, ProbabilidadGeneral = 15, ProbabilidadSegundoObstaculo = 10, ProbabilidadTercerObstaculo = 7 }; 
        probabilidadesObstaculos[9] = new ProbabilidadesObstaculos() { Nivel = 9, ProbabilidadGeneral = 16, ProbabilidadSegundoObstaculo = 12, ProbabilidadTercerObstaculo = 8 };

        #endregion
    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    /// <summary>
    /// Método para obtener lógicamente un gameObject según el nivel y velocidad del personaje
    /// </summary>
    /// <param name="posicion"></param>
    /// <param name="obstaculo"></param>
    private void GenerarObstaculo(float posicionSpawn_Z, Quaternion rotacionSpawn)
    {
        if (this.generarObstaculos) {

            //Obtenemos un obstáculo al azar
            var obstaculo = this.obstaculos[this.randomGenerator.Next(0, this.obstaculos.Length)];

            //Obtenemos la altura del objeto
            ObstaculoData dataObstaculo = obstaculo.GetComponent(typeof(ObstaculoData)) as ObstaculoData;



            //Obtenemos las probabilidades resueltas de generar un obstáculo
            var obstaculosGerados = ResolverObstaculos();

            if (obstaculosGerados[0])
            {
                //Invocamos el obstaculo en la posición del spawn y rotación del prefab
                Instantiate(obstaculo, new Vector3(carrilIzquierdo, dataObstaculo.alturaInicial, posicionSpawn_Z), obstaculo.transform.rotation);
            }

            if (obstaculosGerados[1])
            {
                //Invocamos el obstaculo en la posición del spawn y rotación del prefab
                Instantiate(obstaculo, new Vector3(carrilCentral, dataObstaculo.alturaInicial, posicionSpawn_Z), obstaculo.transform.rotation);
            }

            if (obstaculosGerados[2])
            {
                //Invocamos el obstaculo en la posición del spawn y rotación del prefab
                Instantiate(obstaculo, new Vector3(carrilDerecho, dataObstaculo.alturaInicial, posicionSpawn_Z), obstaculo.transform.rotation);
            }

        }




    }


    /// <summary>
    /// Mpetodo para obtener la lista de los 3 carrilles con su respectiva resolución de probabilidades
    /// </summary>
    /// <returns></returns>
    private  List<bool> ResolverObstaculos() {

        var obstaculoKeyPar = new List<bool>();

        //Generamos las 3 posibilidades aleatorias 
        var prob1G = (this.randomGenerator.Next(0, 100) <= this.probabilidadesObstaculos[Globals.NIVEL_ACTUAL].ProbabilidadGeneral && this.probabilidadesObstaculos[Globals.NIVEL_ACTUAL].ProbabilidadGeneral != 0);
        var prob2G = (this.randomGenerator.Next(0, 100) <= this.probabilidadesObstaculos[Globals.NIVEL_ACTUAL].ProbabilidadGeneral );
        var prob3G = (this.randomGenerator.Next(0, 100) <= this.probabilidadesObstaculos[Globals.NIVEL_ACTUAL].ProbabilidadGeneral );



        //Añadimos posibilidad de aparecer el obstáculo del primer carril
        obstaculoKeyPar.Add(prob1G);

        //Obtenemos la posibilidad del segundo obstaculo
        if (prob1G)
        {
            //Efectuamos el descuento de probabilidad para el segundo carril consecutivamente
            var prob2D = (this.probabilidadesObstaculos[Globals.NIVEL_ACTUAL].ProbabilidadSegundoObstaculo != 0) ? (this.randomGenerator.Next(0, 100) <= this.probabilidadesObstaculos[Globals.NIVEL_ACTUAL].ProbabilidadSegundoObstaculo) : false;

            //Añadimos posibilidad de aparecer un segundo obstáculo en simultáneo
            obstaculoKeyPar.Add(prob2D);

            if (prob2D)
            {
                //Efectuamos el descuento de probabilidad para el tercer carril consecutivamente
                var prob3D = (this.probabilidadesObstaculos[Globals.NIVEL_ACTUAL].ProbabilidadTercerObstaculo != 0) ? (this.randomGenerator.Next(0, 100) <= this.probabilidadesObstaculos[Globals.NIVEL_ACTUAL].ProbabilidadTercerObstaculo) : false;

                //Añadimos posibilidad de aparecer un tercer obstáculo en simultáneo
                obstaculoKeyPar.Add(prob3D);
            }
            else {

                //Añadimos posibilidad de aparecer el obstáculo del tercer carrill
                obstaculoKeyPar.Add(prob3G);
            }

        }
        else {

            //Añadimos posibilidad de aparecer el obstáculo del segundo carril
            obstaculoKeyPar.Add(prob2G);

            if (prob2G)
            {

                //Efectuamos el descuento de probabilidad para el segundo carril consecutivamente
                var prob2D = (this.probabilidadesObstaculos[Globals.NIVEL_ACTUAL].ProbabilidadSegundoObstaculo != 0) ? (this.randomGenerator.Next(0, 100) <= this.probabilidadesObstaculos[Globals.NIVEL_ACTUAL].ProbabilidadSegundoObstaculo) : false;

                //Añadimos posibilidad de aparecer un segundo obstáculo en simultáneo
                obstaculoKeyPar.Add(prob2D);

            }
            else {

                //Añadimos posibilidad de aparecer el obstáculo del tercer carrill
                obstaculoKeyPar.Add(prob3G);
            }


        }



        //Retornamos la lista desordenada
        return OrdenarObstaculosAleatorio(obstaculoKeyPar);       

    }


    private List<T> OrdenarObstaculosAleatorio<T>(List<T> inputList)
    {
        List<T> randomList = new List<T>();

        Random r = new Random();
        int randomIndex = 0;
        while (inputList.Count > 0)
        {
            //Choose a random object in the list
            randomIndex = r.Next(0, inputList.Count);
            //add it to the new, random list
            randomList.Add(inputList[randomIndex]);
            //remove to avoid duplicates
            inputList.RemoveAt(randomIndex); 
        }

        //return the new random list
        return randomList;
    }


    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "SpawnObstaculo")
        {
            this.GenerarObstaculo(other.gameObject.transform.position.z, other.gameObject.transform.rotation);
        }

    }

}


