using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public  class UImanagger : MonoBehaviour
{
    [SerializeField] TMP_Text _healthText;
    [SerializeField] TMP_Text _scoreText;
    [SerializeField] HpController _playerHp;

    public static int  score = 0;
    int currentHealth;

    
    // Start is called before the first frame update
    void Start()
    {      
        currentHealth = _playerHp.currentHealth;
        _healthText.text = "Health:" + " " + currentHealth;
        _scoreText.text = "Score:" + " " + score; 
    }

    private void Update()
    {
        currentHealth = _playerHp.currentHealth;
        _healthText.text = "Health:" + " " + currentHealth;
        _scoreText.text = "Score:" + " " + score;
    }


}
