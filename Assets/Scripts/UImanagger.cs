using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public  class UImanagger : MonoBehaviour
{
    [SerializeField] TMP_Text _healthText;
    [SerializeField] TMP_Text _scoreText;

    public static int  score = 0;
    public static int startingHealth = 100;
    int currentHealth;

    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        _healthText.text = "Health:" + " " + currentHealth;
        _scoreText.text = "Score:" + " " + score; 
    }

    private void Update()
    {
        _healthText.text = "Health:" + " " + currentHealth;
        _scoreText.text = "Score:" + " " + score;
    }


}
