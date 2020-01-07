using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedas : MonoBehaviour
{

    public ControladorPuntajes controllerPuntaje;

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
        if (other.tag == "Player") {
            //Actualizamos el contador de monedas
            controllerPuntaje.SumarMonedas(1);
            //Destruimos la moneda
            Destroy(this.gameObject);
        }

    }
}
