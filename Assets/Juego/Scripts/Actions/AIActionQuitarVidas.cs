using System;
using MoreMountains.TopDownEngine;
using MoreMountains.Tools;
using UnityEngine;

public class AIActionQuitarVidas:AIAction{
    
    [SerializeField]
    private int vidasADescontar;

    public override void Initialization(){
        
    }
    public override void PerformAction()
    {
        GameManager.Instance.LoseLife();
    }
}