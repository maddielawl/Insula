using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[RequireComponent(typeof(SaveManager))]
public class SaveScript : MonoBehaviour
{

    #region Singlton:Profile

    public static SaveScript Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    #endregion

    private string savePath;

    // Start is called before the first frame update
    void Start()
    {
        savePath = Application.persistentDataPath + "/insulasave.rat";
    }

    public void SaveData()
    {
        var save = new Save()
        {
            LevelIdx = SaveManager.Instance.LevelIdx,
            VolumeFloat = SaveManager.Instance.VolumeFloat,
            FullscreenBool = SaveManager.Instance.FullscreenBool,
            CursorState = SaveManager.Instance.CursorState,
            XResolution = SaveManager.Instance.XResolution,
            YResolution = SaveManager.Instance.YResolution
        };

        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))
        {
            binaryFormatter.Serialize(fileStream, save);
        }

        Debug.Log("DataSaved");

    }

    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            Save save;

            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath, FileMode.Open))
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);
            }

            SaveManager.Instance.LevelIdx = save.LevelIdx;
            SaveManager.Instance.VolumeFloat = save.VolumeFloat;
            SaveManager.Instance.FullscreenBool = save.FullscreenBool;
            SaveManager.Instance.FullscreenBool = save.CursorState;
            SaveManager.Instance.XResolution = save.XResolution;
            SaveManager.Instance.YResolution = save.YResolution;

            Debug.Log("Data Loaded");

        }
        else
        {
            Debug.LogWarning("Save file doesn't exist.");
        }
    }

    public void DeleteSaveFile()
    {
        DirectoryInfo directory = new DirectoryInfo(savePath);
        directory.Delete(true);
        // Directory.CreateDirectory(savePath);
    }



}
