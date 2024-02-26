using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using UnityEngine;

//Esta decisión activará al enemigo si es requerido, sino lo desactiva
public class AIDecisionActivarEnemigo : AIDecision
{
    private Character character;

    public override void Initialization()
    {
        Character character = this.GetComponentInParent<Character>();
    }
    public override bool Decide()
    {
        return character.ConditionState.CurrentState == CharacterStates.CharacterConditions.Frozen;
    }

}
