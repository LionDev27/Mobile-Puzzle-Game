using System;
using System.IO;
using UnityEngine;
using Guess.Categories;
using Guess.Solver;

namespace Guess.LevelManagement
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private Animator _transition;
        private GameObject _currentLevel;

        public Action onLevelComplete;

        [SerializeField] private CategoryController _categoryInstance;
        [SerializeField] private CharacterSolver _characterSolver;

        public static LevelController instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            SelectNewLevel();
        }

        private void OnEnable()
        {
            onLevelComplete += StartLevelTransition;
        }

        private void OnDisable()
        {
            onLevelComplete -= StartLevelTransition;
        }

        private void SelectNewLevel()
        {
            if (_currentLevel != null)
            {
                Destroy(_currentLevel);
            }

            //Por alguna razón me sale error si no.
            int randomLevel = UnityEngine.Random.Range(0, _categoryInstance.GetCurrentCategory().levels.Length);
            _currentLevel = Instantiate(_categoryInstance.GetCurrentCategory().levels[randomLevel]);
        }

        public void CompleteLevel()
        {
            onLevelComplete?.Invoke();
        }

        private void StartLevelTransition()
        {
            if (!_characterSolver.solveModeActive)
            {
                _transition.SetTrigger("levelCompleted");
            }
        }

        public void EndTransition()
        {
            if (_characterSolver.solveModeActive)
            {
                Destroy(_currentLevel);

                return;
            }
            SelectNewLevel();
        }

        //Fuck this shit
        /*private int _currentLevel = 1;
        private Level _level = new Level();

        public static LevelController instance;

        [SerializeField] private int _devLevelToSkipTo;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            if (!File.Exists(Application.persistentDataPath + "/Savegame.json"))
            {
                SaveCurrentLevel();
                Debug.Log("New Save Created");
            }
        }

        public void LoadNextLevel()
        {
            if (_currentLevel + 1 >= SceneManager.sceneCountInBuildSettings)
            {
                _currentLevel = 0;
            }
            else
            {
                _currentLevel++;

            }

            SceneManager.LoadScene(_currentLevel);

            SaveCurrentLevel();
        }

        [ContextMenu("SaveGame")]
        public void SaveCurrentLevel()
        {
            _level.level = _currentLevel;
            string lastLevel = JsonUtility.ToJson(_level);

            //TODO: CAMBIAR A PERSISTENT
            File.WriteAllText(Application.persistentDataPath + "/Savegame.json", lastLevel);
        }

        [ContextMenu("LoadGame")]
        public void LoadSavedLevel()
        {
            //Load Data.
            _level = JsonUtility.FromJson<Level>(File.ReadAllText(Application.persistentDataPath + "/Savegame.json"));
            _currentLevel = _level.level;

            //Change Scene.
            if (_currentLevel > SceneManager.sceneCountInBuildSettings - 1) _currentLevel = SceneManager.sceneCountInBuildSettings - 1;
            SceneManager.LoadScene(_currentLevel);
        }

        [ContextMenu("DevToolSkipToLevel")]
        private void DevToolSkipToLevel()
        {
            SceneManager.LoadScene(_devLevelToSkipTo);
            _currentLevel = _devLevelToSkipTo;
        }

        [ContextMenu("DevToolSkipToLevel")]
        public void SkipToLevel(int level)
        {
            SceneManager.LoadScene(level);
        }

        public int GetCurrentLevel()
        {
            return _currentLevel;
        }*/
    }
}
