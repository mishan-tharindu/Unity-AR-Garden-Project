using UnityEngine;
using UnityEngine.UI;

public class SelectedMenuUI : MonoBehaviour
{

    public GameObject selectedObjectUI;

    public GameObject colorPickerPrefab; // Prefab for a color picker UI element
    public Transform colorPickerContainer; // Parent object for color pickers
    public GameObject materialDropdownGameObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowSelectedObjectUI()
    {
        colorPickerPrefab.SetActive(true);
        materialDropdownGameObject.SetActive(true);
    }

    public void HideSelectedObjectUI()
    {
        colorPickerPrefab.SetActive(false);
        materialDropdownGameObject.SetActive(false);
    }

    public void ShowSelectedObjectUI(Material[] materials)
    {
        // Clear existing color pickers
        foreach (Transform child in colorPickerContainer)
        {
            Destroy(child.gameObject);
        }

        // Create a color picker for each material
        for (int i = 0; i < materials.Length; i++)
        {
            // Instantiate a color picker UI element
            GameObject colorPicker = Instantiate(colorPickerPrefab, colorPickerContainer);

            // Set up the color picker for the current material
            SetupColorPicker(colorPicker, materials[i]);
        }
    }

    private void SetupColorPicker(GameObject colorPicker, Material material)
    {
        // Get the color picker UI components
        Image colorImage = colorPicker.GetComponentInChildren<Image>();
        Button colorButton = colorPicker.GetComponentInChildren<Button>();

        // Set the initial color of the color picker to the material's color
        if (colorImage != null)
        {
            colorImage.color = material.color;
        }

        // Add a listener to the button to change the material's color
        if (colorButton != null)
        {
            colorButton.onClick.AddListener(() => ChangeMaterialColor(material));
        }
    }

    private void ChangeMaterialColor(Material material)
    {
        // Open a color picker dialog or use a custom color picker
        // For simplicity, let's assume we have a method to open a color picker
        OpenColorPicker((color) =>
        {
            material.color = color;
        });
    }

    private void OpenColorPicker(System.Action<Color> onColorSelected)
    {
        // Implement your color picker logic here
        // For example, you can use Unity's ColorPicker asset or create a custom UI
        Debug.Log("Open color picker...");
        // Simulate a color selection for demonstration
        onColorSelected?.Invoke(Color.red); // Replace with actual color selection logic
    }

}
