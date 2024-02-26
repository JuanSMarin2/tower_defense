using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

[Serializable]
//Identifica el prefab correspondiente de tipo de enemigo
public enum TipoEnemigo{
    Koala, Ninja
}

[Serializable]
public class Enemigo
{
    [SerializeField]
    private GameObject obj;
    //[SerializeField]
    //private MMPath camino;
    public Enemigo(GameObject obj){
        Obj = obj;
    }
    public GameObject Obj { get => obj; set => obj = value; }
    //public MMPath Camino { get => camino; set => camino = value; }
}

