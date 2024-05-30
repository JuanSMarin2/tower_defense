using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
public bool isActive = false;

    void Start()
    {

        gameObject.SetActive(isActive);

    }

    public void Activate()

    {
        isActive = true;

        gameObject.SetActive(true);

        Debug.Log("Torre activada en " + transform.position);
    }
}
