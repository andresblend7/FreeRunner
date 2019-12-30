using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase para manejar las animaciones del personaje
/// </summary>
public class Animaciones : MonoBehaviour
{

    public GameObject espada, escudo;
    private Animator animEspada, animEscudo;
    // Start is called before the first frame update
    void Start()
    {
        this.animEspada = this.espada.GetComponent<Animator>(); 
        this.animEscudo = this.escudo.GetComponent<Animator>();
    }

    public void AnimAtacarEspada() {
        //Animación de espada
        this.animEspada.SetTrigger("AtacarTr");
        //Animación de Escudo
        this.animEscudo.SetTrigger("AtacarEspadaTr");
        Debug.Log("Ejecutando animación atacar");
    }

    public void AnimBloquearEscudo(bool bloquear) {
        this.animEscudo.SetBool("Bloqueando", bloquear);
        //Animación de espada
        this.animEspada.SetBool("EscudoBloqueando", bloquear);
    }


  

    // Update is called once per frame
    void Update()
    {
        
    }
}
