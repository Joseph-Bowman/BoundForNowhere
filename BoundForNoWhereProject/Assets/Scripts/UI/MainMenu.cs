using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("UI Variables")]

    //Check UI menu
    [SerializeField] private GameObject YouSure;

    //Scene to be loaded on play
    [SerializeField] private string sceneName;

    //Loads a scene based on a string
    public void OnPlay() { SceneManager.LoadScene(sceneName); }

    //Validates if the player really wants to quit
    public void OnQuit() { YouSure.SetActive(true); }

    //Closes the game
    public void Quit() { Application.Quit(); }
}
