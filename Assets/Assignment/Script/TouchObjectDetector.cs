using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TouchObjectDetector : MonoBehaviour
{

    GameObject selectedgameObject;
    public SelectedMenuUI selectedMenuUI;



    void Start()
    {
        if (selectedMenuUI == null)
        {
            Debug.LogError("selectedMenuUI is not assigned in TouchObjectDetector!");
        }

    }

    void Update()
    {


    }

    public void getSelectedObject(GameObject selectedObject)
    {
        if (selectedObject == null)
        {
            Debug.LogError("Selected object is null!");
            return;
        }

        Debug.Log("TouchObjectDetector :: Select Object :: " + selectedObject.name);
        selectedMenuUI.ShowSelectedObjectUI();

        //// Get the Renderer component of the selected object
        //Renderer renderer = selectedObject.GetComponent<Renderer>();
        //if (renderer == null)
        //{
        //    Debug.LogError("Renderer component is missing in selected object!");
        //    return;
        //}

        //// Get the materials from the Renderer
        //Material[] materials = renderer.materials;

        //// Pass the materials to the UI
        //if (selectedMenuUI != null)
        //{
        //    selectedMenuUI.ShowSelectedObjectUI(materials);
        //    Debug.Log("TouchObjectDetector :: Object Materials :: " + materials.Length);
        //}
        //else
        //{
        //    Debug.LogError("selectedMenuUI is null in TouchObjectDetector!");
        //}

        // Pass the selected object to the MaterialColorChanger script
        MaterialColorChanger materialColorChanger = GetComponent<MaterialColorChanger>();
        if (materialColorChanger != null)
        {
            materialColorChanger.SetupMaterials(selectedObject);
        }
        else
        {
            Debug.LogError("MaterialColorChanger component is missing!");
        }

    }

    internal void getSelectedObject(IXRFocusInteractable currentFocusedObject)
    {
        //throw new NotImplementedException();
        Debug.Log("Select XR Object :: " + currentFocusedObject.transform.name);
    }
}
