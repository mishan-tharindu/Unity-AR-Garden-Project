using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
public class MaterialLoader : MonoBehaviour
{
    public GameObject buttonPrefab; // Assign a UI Button prefab
    public Transform scrollViewContent; // Assign the Content of Scroll View

    private string folderPath;

    void Start()
    {
        //folderPath = Path.Combine(Application.streamingAssetsPath, "Materials/Cube");

        //folderPath = Application.persistentDataPath + "/Materials/Cube"; //C:/Users/vmish/AppData/LocalLow/DefaultCompany/AR Project - 01/Materials/Cube
        folderPath = Application.dataPath + "/Assignment/Materials/Cube";

        Debug.Log(" MaterialLoader ::: Assets Folder Path: " + folderPath);
        if (Directory.Exists(folderPath))
        {
            string[] materialFiles = Directory.GetFiles(folderPath, "*.mat") // Get only .mat files
                                            .Select(Path.GetFileNameWithoutExtension)
                                            .ToArray();

            foreach (string matName in materialFiles)
            {
                CreateButton(matName);
            }
        }
        else
        {
            Debug.LogWarning("Material folder not found: " + folderPath);
        }
    }

    public void CreateButton(string matName)
    {
        GameObject newButton = Instantiate(buttonPrefab);
        newButton.transform.SetParent(scrollViewContent.transform);
        Debug.Log("Material Name ::: " + matName);
        newButton.GetComponentInChildren<Text>().text = matName; // Set button text
        newButton.GetComponent<Button>().onClick.AddListener(() => ApplyMaterial(matName));
    }

    public void ApplyMaterial(string matName)
    {
        Debug.Log("Selected Material: " + matName);
        // Load the material and apply it to the selected object (next step)
    }


}
