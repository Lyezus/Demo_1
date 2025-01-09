using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] TMP_Text _infoText;
    [SerializeField] TMP_Text _gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        // pause game
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (UImanagger.currentHealth <= 0) 
        {
            Time.timeScale = 0;
            _gameOverText.gameObject.SetActive(true);
        }

    }

    public void StartGame()
    {
        // start game
        Time.timeScale = 1;

        // turn off info screen
        _infoText.gameObject.SetActive(false);
    }

    public void ReStart()
    {
        string scene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(scene);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
