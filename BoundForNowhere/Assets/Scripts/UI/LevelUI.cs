using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelUI : MonoBehaviour
{
    [Header("UI Objects")]
    [SerializeField] private GameObject pauseUI;
    private bool isPaused;

    //Input Settings
    private InputSystem_Actions playerUIInput;

    [Header("Item UI")]
    [SerializeField] private GameObject imagePrefab;
    [SerializeField] private Transform itemSpriteParent;
    private List<Image> sprites = new List<Image>();

    public ItemBase TempItemToAdd; //Temp Delete Later

    //Enables Input
    private void OnEnable()
    {
        playerUIInput = new InputSystem_Actions();
        playerUIInput.UI.Enable();
        playerUIInput.UI.Pause.performed += PauseGame; //Links the player pause input to the pause function
    }

    //Disables Input
    private void OnDisable()
    {
        playerUIInput.UI.Pause.performed -= PauseGame; //unlinks the player pause input to the pause function
        playerUIInput.UI.Disable();
    }

    //Ensures the game is not paused on start
    private void Start() {  Resume();

        SetUISpriteToItemSprite(TempItemToAdd);
    } 

    void PauseGame(InputAction.CallbackContext context)
    {
        //A simple switch check to look for pause input if paused the game unpauses using the resume function if not then the game pauses using the pause functions
        if (context.performed)
        {
            if (isPaused) { Resume(); }
            else { Pause(); }
        }
    }

    //Resumes the game and hides the UI and cursor
    void Resume()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseUI.SetActive(false);
    }

    //Pauses the game and shows the UI and cursor
    void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseUI.SetActive(true);
    }

    public void SetUISpriteToItemSprite(ItemBase item)
    {
        GameObject newItemSprite = Instantiate(imagePrefab, itemSpriteParent);
        Image itemSprite = newItemSprite.GetComponent<Image>();
        itemSprite.sprite = item.itemSprite;
        sprites.Add(itemSprite);
    }
}
