using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

public class AIDecisionDetectarRuta : AIDecision
{
    private MMPath mp;

    public override void Initialization()
    {
        mp = this.GetComponentInParent<Ruta>();
    }
    public override bool Decide()
    {
        if(mp == null )
        {
            return false;
        }

        return (mp.PathElements != null)?mp.PathElements.Count > 0:false;
    }

}
