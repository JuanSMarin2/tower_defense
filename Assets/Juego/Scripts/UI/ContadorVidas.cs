using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using TMPro;
using UnityEngine;

public class ContadorVidas : MonoBehaviour
{
    [SerializeField]
    private TMP_Text contador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contador.SetText(GameManager.Instance.CurrentLives.ToString());
    }
}
