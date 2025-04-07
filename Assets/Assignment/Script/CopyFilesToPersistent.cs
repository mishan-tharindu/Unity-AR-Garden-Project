using UnityEngine;
using System.IO;

public class CopyFilesToPersistent : MonoBehaviour
{
    void Start()
    {
        string sourcePath = Application.dataPath + "/Materials/Cube";
        string destinationPath = Application.persistentDataPath + "/Materials/Cube";

        if (!Directory.Exists(destinationPath))
        {
            Directory.CreateDirectory(destinationPath);
        }

        string[] files = Directory.GetFiles(sourcePath);
        foreach (string file in files)
        {
            string fileName = Path.GetFileName(file);
            string destFile = Path.Combine(destinationPath, fileName);
            File.Copy(file, destFile, true);
        }

        Debug.Log("Files copied to: " + destinationPath);
    }
}
