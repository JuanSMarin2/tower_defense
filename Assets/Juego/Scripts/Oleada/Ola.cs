using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

public class Ola : MonoBehaviour
{
    private Oleadas oleadas_nivel;
    [SerializeField]
    private List<OlaData> data;
    private List<OlaGrupo> ola_grupos;
    private GameObject grupos;
    private int grupo_actual;
    private float tiempo_total_ola;
    [SerializeField]
    private float tiempo_entre_olas;
    private bool ola_despachada;
    [SerializeField]
    //Esta es la ruta que seguiran todos los enemigos de la ola
    [Header("Debug")]
    [MMInspectorButton("AgregarUnEnemigo")]
    /// a test button to spawn an object
    public bool PuedeAgregarButton;
    
    public Oleadas OleadasNivel { get => oleadas_nivel; set => oleadas_nivel = value; }


    public void Start(){
        
    }

    //TODO: Temporalmente, se crearan las instancias necesarias para
    //representar todos los enemigos, esta pendiente realizar
    //pooling de objetos
    public void AlistarGrupo(){
        grupos = Oleadas.Instance.ContenedorGrupos;
        grupos.transform.SetParent(this.transform);
        CrearGrupos();
    }

    public void CrearGrupos(){
        OlaGrupo temp;
        ola_grupos = new List<OlaGrupo>();

        foreach(OlaData d in data)
        {
            temp = grupos.AddComponent<OlaGrupo>();
            temp.CrearGrupo(d);
            temp.OlaActual = this;
            temp.Tiempo_salida = d.TiempoSalida;
            tiempo_total_ola += d.TiempoSalida;
            ola_grupos.Add(temp);
        }
        Debug.Log("Tiempo total de la ola "+tiempo_total_ola); 
    }

    public void EmpezarOla(){
        AlistarGrupo();
        DespacharGrupo();
    }

    public void DespacharGrupo(){
        if(grupo_actual<ola_grupos.Count)
        {
            OlaGrupo temp = ola_grupos[grupo_actual];
            temp.IniciarGrupo();
            grupo_actual++;
        }
        else{
            //Se despacharon todos los grupos de la ola,
            //Se pide la siguiente ola
            ola_despachada = true;
        }
    }

    public void Update(){
        //El tiempo entre olas indica el tiempo que se debe esperar para que salga la siguiente ola
        if(Time.timeSinceLevelLoad>(tiempo_total_ola+tiempo_entre_olas) && ola_despachada)
        {
            OleadasNivel.DespacharOla();
            ola_despachada = false;//Pendiente gestionar ejecución de este script
        }
    }

    //Metodo de prueba desde el inspector que agrega Koalas
    public void AgregarUnEnemigo(){
        //AgregarEnemigo(new OlaData(TipoEnemigo.Koala));
    }

}
