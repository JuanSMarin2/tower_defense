using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class AIActionPatrullarOla : AIActionMovePatrol2D
{
    private float xr, yr;
    protected override void InitializePatrol(){
        base.InitializePatrol();
        //xr = Random.Range(0,1);
        //yr = Random.Range(0,1);
    }
    public void Reiniciar(){
        _mmPath.Initialization();
        InitializePatrol();
    }

    protected override void Patrol(){
        try{
            //Lanza excepción si el MMPath no se ha asignado
            base.Patrol();
        }catch(NullReferenceException e){
            Debug.Log("La ruta MMPath no se ha asignado");
            Debug.LogError(e);
        }
    }
}
