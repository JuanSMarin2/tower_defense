using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;
using UnityEngine.Events;

public class ControlVidas:MonoBehaviour
{
    public void OnQuitarVida(){
        GameManager.Instance.LoseLife();
    }

}
