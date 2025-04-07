using UnityEngine;
using UnityEngine.UI;

public class MaterialColorChanger : MonoBehaviour
{
    public Dropdown materialDropdown; // Reference to the Dropdown UI
    public FlexibleColorPicker colorPicker; // Reference to the Flexible Color Picker
    private Material[] materials; // Array to store materials of the selected object
    private int selectedMaterialIndex = 0; // Index of the currently selected material



    void Start()
    {
        
    }

    // Call this method when an object is selected
    public void SetupMaterials(GameObject selectedObject)
    {
        if (selectedObject == null)
        {
            Debug.LogError("Selected object is null!");
            return;
        }

        // Get the Renderer component of the selected object
        Renderer renderer = selectedObject.GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogError("Renderer component is missing in selected object!");
            return;
        }

        // Get the materials from the Renderer
        materials = renderer.materials;

        // Clear the dropdown and add material names
        materialDropdown.ClearOptions();
        foreach (Material material in materials)
        {
            materialDropdown.options.Add(new Dropdown.OptionData(material.name));
        }

        // Set the default selected material
        materialDropdown.value = 0;
        materialDropdown.RefreshShownValue();

        // Update the color picker to match the first material's color
        if (materials.Length > 0)
        {
            colorPicker.color = materials[0].color;
        }

        // Add listeners
        materialDropdown.onValueChanged.AddListener(OnMaterialSelected);
        colorPicker.onColorChange.AddListener(OnColorChanged);
    }

    // Called when a new material is selected from the dropdown
    private void OnMaterialSelected(int index)
    {
        selectedMaterialIndex = index;
        colorPicker.color = materials[index].color; // Update the color picker to match the selected material's color
    }

    // Called when the color picker's color changes
    private void OnColorChanged(Color color)
    {
        if (materials != null && selectedMaterialIndex < materials.Length)
        {
            materials[selectedMaterialIndex].color = color; // Update the selected material's color
        }
    }
}