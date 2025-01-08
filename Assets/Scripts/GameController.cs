using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] TMP_Text _infoText;

    // Start is called before the first frame update
    void Start()
    {
        // pause game
        Time.timeScale = 0;
    }

    public  void StartGame()
    {
        Time.timeScale = 1;
        _infoText.gameObject.SetActive(false);
    }
}
