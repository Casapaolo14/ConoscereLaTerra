using UnityEngine;
using UnityEngine.UIElements; // Required for UI Toolkit
using UnityEngine.SceneManagement; // Required for Changing Scenes

public class MainMenuController : MonoBehaviour
{
    private void OnEnable()
    {
        // 1. Get the UIDocument component from the Cube
        var uiDocument = GetComponent<UIDocument>();

        // 2. Find the button by its name (set in UI Builder)
        // Change "MyButtonName" to the actual name you gave your button
        Button playButton = uiDocument.rootVisualElement.Q<Button>("Inizia");

        // 3. Register the click event
        if (playButton != null)
        {
            Debug.LogWarning("Button found", this);   
            playButton.clicked += OnPlayButtonClicked;
        }
         Debug.LogWarning("Button not found", this);   
    }

    private void OnPlayButtonClicked()
    {
        // 4. Load the next scene by name or index
        SceneManager.LoadScene("SampleScene");
    }
}