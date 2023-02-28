using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private int _currentLevel;
    private Level _level = new Level();

    public static LevelController instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadNextLevel()
    {
        _currentLevel++;
        if (_currentLevel + 1 >= SceneManager.sceneCountInBuildSettings - 1) _currentLevel = 0;

        SceneManager.LoadScene(_currentLevel);

        SaveCurrentLevel();
    }

    [ContextMenu("SaveGame")]
    public void SaveCurrentLevel()
    {
        _level.level = _currentLevel;
        string lastLevel = JsonUtility.ToJson(_level);
        File.WriteAllText(Application.dataPath + "/Savegame.json", lastLevel);
    }

    [ContextMenu("LoadGame")]
    public void LoadSavedLevel()
    {
        _level = JsonUtility.FromJson<Level>(File.ReadAllText(Application.dataPath + "/Savegame.json"));
        _currentLevel = _level.level;
    }

    public void LoadLastLevel()
    {
        if(_currentLevel > SceneManager.sceneCountInBuildSettings - 1) _currentLevel = SceneManager.sceneCountInBuildSettings - 1;
        SceneManager.LoadScene(_currentLevel);
    }
}

public class Level
{
    public int level;
}
