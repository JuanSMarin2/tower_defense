using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float lifetime = 5.0f;

void Update()
{
     lifetime -= Time.deltaTime;
     Debug.Log(lifetime);
        if (lifetime >0)
        {
 Destroy(gameObject);
        }
        }
}
