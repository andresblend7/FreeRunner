using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControlesUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public RawImage[] flechasUi;
    public Personaje personaje;
    // Start is called before the first frame update1
    void Start()
    {
        foreach (var image in flechasUi)
            image.CrossFadeAlpha(0.6f, 0, false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        var pointerClickName = eventData.pointerCurrentRaycast.gameObject.name;
        Debug.Log("Pointer Enter" + pointerClickName);

        switch (pointerClickName)
        {

            case "FlechaIzquierda":
                personaje.MoverPersonajeIzquierda();
                break;

            case "FlechaDerecha":
                personaje.MoverPersonajeDerecha();
                break;

            case "FlechaSaltar":
                personaje.Saltar();
                break;

            case "BotonAtacar":
                personaje.AtacarEspada();
                break;

            case "BotonBloquear":
                personaje.BloquearEscudo(true);
                break;
        }
    }

    //Do this when the cursor exits the rect area of this selectable UI object.
    public void OnPointerExit(PointerEventData eventData)
    {
        var pointerClickName = eventData.pointerEnter.gameObject.name;

        switch (pointerClickName)
        {
            case "BotonBloquear":
                personaje.BloquearEscudo(false);
                break;
        }
    }

        public void OnPointerClick(PointerEventData eventData)
        {
            //
        }
}
