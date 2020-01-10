using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generadores : MonoBehaviour
{
    public GameObject prefabContenedorPiso;
    bool pisoGenerado = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter(Collider other)
    {

        //Solo se genera el piso una única vez
        if (!this.pisoGenerado)
        {
            this.pisoGenerado = true;

            if (other.tag == "GenerarPiso")
            {

                Instantiate(prefabContenedorPiso, new Vector3(0, 0, (Globals.GetNumeroPisoACtual() * 100)), Quaternion.identity);
                Globals.AumentarNumeroPiso(1);

            }

        }
         //Debug.Log("COLLISIONÓ : "+ other.tag);

        if (other.tag == "DestruirPiso")
        {
            GameObject.Destroy(prefabContenedorPiso);
        }
    }
}
