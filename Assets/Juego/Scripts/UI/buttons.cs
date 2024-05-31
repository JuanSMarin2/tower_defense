using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour //Scrip botones
{
public void iniciar()
{
SceneManager.LoadScene("Nivel 1");
Debug.Log("Jugar precionado");
}

public void creditos()
{
SceneManager.LoadScene("Creditos");  
Debug.Log("creditos precionado");
}

public void instrucciones()
{
SceneManager.LoadScene("Instrucciones");    
Debug.Log("instrucciones precionado");
}

public void volverMenu()
{
SceneManager.LoadScene("MenuPrincipal");
Debug.Log("volver al menu precionado");
}

public void salir()
{
Application.Quit();
Debug.Log("salir precionado");
}


}
