using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{

    public static int numeroPiso = 1;
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

    public static int GetNumeroPisoACtual() {
        return numeroPiso;
    }
}

