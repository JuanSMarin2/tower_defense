using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

public class Ruta : MMPath
{
    /*public void Start(){
        //foreach(MMPathMovementElement e in PathElements){
        //    Debug.Log(e.PathElementPosition.x+","+e.PathElementPosition.y);
        //}
    }*/

    //Para que esta clase funcione, la ruta debe tener cycle option only once
    public bool FinRuta(){
        return _endReached;
    }

    /*
    Pendiente que la ruta se pueda mover independientemente
    protected virtual void OnDrawGizmos()
    {	
        #if UNITY_EDITOR
        //MMDebug.DrawGizmoPoint(this.transform.position,.2f,Color.yellow);
        #endif
    }*/
}
