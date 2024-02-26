using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EstadosGrupo{
    EN_COLA,SIN_EMPEZAR,EJECUCION,TERMINADO
}

[Serializable]
public class OlaGrupo : MonoBehaviour
{
    private Ola ola_actual;
    private EstadosGrupo estado;
    //private GameObject padre;
    [SerializeField]
    private List<Enemigo> enemigos;
    private int enemigo_actual;
    //Tiempo de salida entre enemigos de un grupo
    public const float TIEMPO_SALIDA_ENEMIGO = 1f;
    private float tiempo_salida;

    public float Tiempo_salida { get => tiempo_salida; set => tiempo_salida = value; }
    public Ola OlaActual { get => ola_actual; set => ola_actual = value; }

    public void Start(){
        Debug.Log(estado);
    }

    public void IniciarGrupo(){
        //Crear la ola, con la información de OlaData
        estado = EstadosGrupo.SIN_EMPEZAR;
    }

    public void Update(){
        if(estado != EstadosGrupo.EN_COLA)
        {
            if(Time.timeSinceLevelLoad > Tiempo_salida && estado == EstadosGrupo.SIN_EMPEZAR)
            {
                EmpezarGrupo();
                estado = EstadosGrupo.EJECUCION;
            }
        }
    }

    public void CrearGrupo(OlaData data){
        enemigos = new List<Enemigo>();
        AgregarEnemigos(data);
    }

    public void EmpezarGrupo(){
        StartCoroutine(DespacharEnemigo(TIEMPO_SALIDA_ENEMIGO));
    }

    private IEnumerator DespacharEnemigo(float tiempo)
    {
        yield return new WaitForSecondsRealtime(tiempo);
        ActivarEnemigo();
    }

    private void ActivarEnemigo()
    {
        Enemigo e;
        //AIBrain brain;

        if(enemigo_actual<enemigos.Count)
        {
            e = enemigos[enemigo_actual];//Oleadas.Instance.BuscarEnemigoDisponible();
            e.Obj.gameObject.SetActive(true);
            /*brain = e.Obj.GetComponent<AIBrain>();
            if(brain!=null)
            {
                brain.BrainActive = true;
            }*/
            if(++enemigo_actual < enemigos.Count)
            {
                StartCoroutine(DespacharEnemigo(TIEMPO_SALIDA_ENEMIGO));
            }
            else
            {
                //Fin de la ola
                //Despachar evento fin de ola, para que la oleado controle la 
                //siguiente ola
                estado = EstadosGrupo.TERMINADO;
                ola_actual.DespacharGrupo();
                //Acá se indica que todos los enemigos de un grupo fueron
                //despachados, se debe tener un contador en la ola
            }
        }        
    }

     public void AgregarEnemigos(OlaData e)
    {
        GameObject obj = e.Prefab;//GameObject.Find(e.Tipo.ToString());
        Enemigo enemigo;
        //AIBrain brain;
        int cantidad = e.Cantidad;

        if(obj!=null)
        {
            for(int i=0;i<cantidad;i++)
            {
                
                //obj.gameObject.SetActive(false);
                GameObject newGameObject = (GameObject)Instantiate(obj);
                obj.gameObject.SetActive(false);
                newGameObject.transform.localScale = (newGameObject.transform.localScale * 0) + new Vector3(1,1,1);
                newGameObject.transform.localPosition = (newGameObject.transform.localPosition)+new Vector3(0,i,0);
                /*brain = newGameObject.GetComponent<AIBrain>();
                if(brain!=null)
                {   //No funciono, revisar ubicación de los scripts
                    //Debug.Log("Desactivar cerebro");
                    brain.BrainActive = false;
                }*/
                enemigo = new Enemigo(newGameObject);
                enemigos.Add(enemigo);
                ConfigurarRuta(enemigo,e.Ruta);
                SceneManager.MoveGameObjectToScene(newGameObject, this.gameObject.scene);
                newGameObject.transform.SetParent(this.gameObject.transform);          
            }
        }
    }

    //Crea la ola a partir de la información de configuración, nombre enemigo, 
    public void ConfigurarRuta(Enemigo enemigo,MMPath ruta)
    {
        MMPath temp = enemigo.Obj.GetComponent<Ruta>();
        if(temp!=null)
        {
            temp.ReferenceMMPath = ruta;
            //temp.Initialization();//No es necesario inicializar una ruta asignada
        }
        
    }
}