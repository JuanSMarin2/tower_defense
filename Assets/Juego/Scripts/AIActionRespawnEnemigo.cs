using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using Unity.VisualScripting;
using UnityEngine;

public class AIActionRespawnEnemigo : AIAction
{
    
    private GameObject enemigo;
    private Vector3 inicio;
    private AIActionPatrullarOla ai;
    
    public override void Initialization (){
        //enemigo = this.transform.parent.gameObject;
        if(enemigo!=null){
            inicio = enemigo.transform.position;
            ai = this.GetComponentInParent<AIActionPatrullarOla>();
        }
    }

    public override void PerformAction()
	{
        VolverAlInicio();
    }

    public void VolverAlInicio(){
        
        //c.RespawnAt(inicio,Character.FacingDirections.North);
        //c.transform.position = inicio;
        Character character = this.GetComponentInParent<Character>();
        character.RespawnAt(inicio,Character.FacingDirections.East);
        ai.Reiniciar();
        /*character.Freeze();
        gameObject.SetActive(false);*/
                
    }

    /*public void OnPlayerRespawn(CheckPoint checkpoint, Character player)
    {
        Debug.Log("Respawn!!!");
    }*/

}
