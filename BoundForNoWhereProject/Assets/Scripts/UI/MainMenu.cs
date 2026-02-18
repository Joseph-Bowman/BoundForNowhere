using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [Header("Menu Buttons")]
    //Scene to be loaded on play
    [SerializeField] private string sceneName;
    //Object References
    private bool optionsOpen;
    [SerializeField] private AudioClip OnClick;
    private AudioSource audioSource;

    [Header("Options")]
    //Object References
    [SerializeField] private GameObject YouSure; //UI for exit check

    //Other References
    [SerializeField] private ResolutionOptions[] resolutions; //Resolution options in menu
    [SerializeField] private TextMeshProUGUI resolutionText; // Resolution display
    [SerializeField] private Animator optionAnimations;
    public PlayerSettingsData optionData; //Players settings preferences;
    
    //Resolution System
    [System.Serializable]
    public struct ResolutionOptions //Code for the resolutions intX * intY
    {
        public int Width;    
        public int Height;
    }

    private int resolutionIndex; // Used to keep current and future resolution indexed increased on switch
    

    private void Start() 
    { 
        if(resolutionText != null){ resolutionText.text = $"{Screen.width} X {Screen.height}"; } 

        audioSource = GetComponent<AudioSource>();
    } // Sets the text to the current resolution

    //
    //Menu Buttons -- Line 40 <-> 52
    //
    
    public void OnPlay() { SceneManager.LoadScene(sceneName); } //Loads a scene based on a string

    public void OnOptions() //Opens the options if the player presses the buttons
    {
        if (optionsOpen) { optionsOpen = false; }
        else{ optionsOpen = true; }

        optionAnimations.SetBool("isPaused", optionsOpen);
    }

    public void OnQuit() { YouSure.SetActive(true); } //Validates if the player really wants to quit

    public void Quit() { Application.Quit(); } //Closes the game 

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(OnClick, 1);
    }

    //
    //SettingsOptions -- Line 58 <-> 123123
    //

    public void ChangeResolution()//Increases the index by one then if over the current amount of resolutions sets it back to the first one
    {
        resolutionIndex++;
        if(resolutionIndex >= resolutions.Length) { resolutionIndex = 0; }

        ApplyResolution();
    }

    private void ApplyResolution()//Sets the current resolution to the resolution and applies that to the screen // if the text is not null it sets the text to the resolution by width and height
    {
        Screen.SetResolution(resolutions[resolutionIndex].Width, resolutions[resolutionIndex].Height, FullScreenMode.ExclusiveFullScreen);

        if(resolutionText != null) { resolutionText.text = $"{resolutions[resolutionIndex].Width} X {resolutions[resolutionIndex].Height}"; }
    }

    public void InvertY() //Checks the invert then using that value switches the invert based on the player input on a toggle
    {
        bool currInvert = optionData.invert;

        if(currInvert == true) { optionData.invert = false; }
        else { optionData.invert = true; }
    }

    public void SetSensitivity(TMP_InputField input) //Sets the sensitivity using hte user set value checks if its within the range and then applies it to the player settings data
    {
        var sens = int.Parse(input.text);

        if(sens > 15 || sens < 0) {
            input.text = 15.ToString();
            optionData.sensitivity = 15;
        }
        else { optionData.sensitivity = sens; }
    }
    
}