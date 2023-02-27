using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int _currentLevel;
    private Level _level = new Level();

    [ContextMenu("SaveGame")]
    public void SaveCurrentLevel()
    {
        _level.level = _currentLevel;
        string lastLevel = JsonUtility.ToJson(_level);
        File.WriteAllText(Application.dataPath + "/Savegame.json", lastLevel);
    }

    [ContextMenu("LoadGame")]
    public void LoadLastLevel()
    {
        _level = JsonUtility.FromJson<Level>(File.ReadAllText(Application.dataPath + "/Savegame.json"));
        _currentLevel = _level.level;
    }
}

public class Level
{
    public int level;
}
