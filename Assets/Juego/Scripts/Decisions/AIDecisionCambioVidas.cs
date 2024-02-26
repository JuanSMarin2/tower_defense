using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class AIDecisionCambioVidas : AIDecision
{
    private int vidas;

    public override void Initialization()
    {
        vidas = GameManager.Instance.CurrentLives;
    }
    public override bool Decide()
    {
        if(vidas < GameManager.Instance.CurrentLives)
        {
            vidas = GameManager.Instance.CurrentLives;
            return true;
        }
        
        return false;
        
    }

}
