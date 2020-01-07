using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    /// <summary>
    /// nivelActual = nivel global que afecta la velocidad del personaje y porcentaje de obstaculos
    /// </summary>
    public static int numeroPiso = 1, NIVEL_ACTUAL = 0, VIDA_ACTUAL = 1000;
    public static bool debugModePc = true;

    #region Diccionarios

    public enum Carriles
    {
        Izquierdo = 0,
        Central = 1,
        Derecho = 2
    }

    #endregion

    public static void AumentarNumeroPiso(int cantPisos) {

        numeroPiso =numeroPiso +  cantPisos;
       // Debug.Log("PISO AUMENTADO=> " + numeroPiso);
    }

    /// <summary>
    /// Método para obtener el número del piso actual generado y poder generar el siguiente
    /// </summary>
    /// <returns></returns>
    public static int GetNumeroPisoACtual() {
        return numeroPiso;
    }

    /// <summary>
    /// Método para descontar salud
    /// </summary>
    /// <param name="danio"></param>
    /// <returns></returns>
    public static int QuitarVida(int danio) {
        VIDA_ACTUAL = VIDA_ACTUAL - danio;
        return VIDA_ACTUAL;
    }

       
}
/// <summary>
/// Clase que controla las probabilidades de generar obstaculos
/// </summary>
public class ProbabilidadesObstaculos {

    /// <summary>
    /// Nivel de la partida
    /// </summary>
    public int Nivel { get; set; }

    /// <summary>
    /// Probabilidad de que se genere el primer obstaculo en la fila
    /// </summary>
    public int ProbabilidadGeneral { get; set; }

    /// <summary>
    /// Probabilidad de que se genere un segundo obstaculo
    /// </summary>
    public int ProbabilidadSegundoObstaculo { get; set; }

    /// <summary>
    /// Probabilidad de que se genere un tercer obstaculo
    /// </summary>
    public int ProbabilidadTercerObstaculo { get; set; }
}

