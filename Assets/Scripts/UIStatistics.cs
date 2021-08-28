using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIStatistics : MonoBehaviour
{
    [SerializeField] private Text _coinsText;
    [SerializeField] private GameObject _menu;

    private void Update()
    {
        _coinsText.text = "Coins: " + Statistic._coins;
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Menu()
    {
        _menu.SetActive(true);
    }
    public void CloseMenu()
    {
        _menu.SetActive(false);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Levels()
    {
        SceneManager.LoadScene(4);
    }

    public void Level1()
    {
        SceneManager.LoadScene(1);
    }
    public void Level2()
    {
        SceneManager.LoadScene(2);
    }
    public void Level3()
    {
        SceneManager.LoadScene(3);
    }
}
