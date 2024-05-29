using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
 public Tower[] towers;
    private int currentIndex = 0;
    [SerializeField] private TMP_Text pointsText; // Usando SerializeField para hacerlo visible en el inspector

    private int points = 20;

    void Start()
    {
        UpdatePointsText();
         
    }

    public void OnButtonClick()
    {
        if (currentIndex < towers.Length)
        {
            towers[currentIndex].Activate();
            currentIndex++;
            ReducePoints(5); // Reduce los puntos en 5 cada vez que se activa una torre
        }
        else
        {
            Debug.Log("Todas las torres ya están activadas");
             SceneManager.LoadScene("Nivel 2");
        }
    }

    private void ReducePoints(int amount)
    {
        points -= amount;
        UpdatePointsText();
    }

    private void UpdatePointsText()
    {
        pointsText.text = points.ToString();
    }
}
