using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oleadas : MonoBehaviour
{
    [SerializeField]
    private List<Ola> olas;
    private int ola_actual;
    [SerializeField]
    private GameObject contenedor_grupos;
    public static Oleadas Instance { get; private set; }
    public GameObject ContenedorGrupos { get => contenedor_grupos; set => contenedor_grupos = value; }


    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public void Start(){
        DespacharOla();
    }

    public void DespacharOla(){
        Ola ola;
        if(ola_actual < olas.Count)
        {
            ola = olas[ola_actual];
            ola.EmpezarOla();
            ola.OleadasNivel = this;
            ola_actual++; //Acá se acualiza el contador de olas
            Debug.Log("Ola "+ola_actual+"/"+olas.Count);
        }
        else{
            //Se termina la partida indicar que gano y mostrar ventana fin de nivel
            Debug.Log("Fin de oleadas");
        }

    }

    /*public Enemigo BuscarEnemigoDisponible(TipoEnemigo tipo)
    {
        return null;
    }*/
}
