using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{
    [SerializeField] private int _solveLevel;

    private void GoToNextLevel()
    {
        LevelController.instance.LoadNextLevel();
    }

    private void GoToLoadLevel()
    {
        LevelController.instance.LoadSavedLevel();
    }

    private void GoToLastLevel()
    {
        int level = LevelController.instance.GetCurrentLevel();
        LevelController.instance.SkipToLevel(level);
    }

    private void GoToSolveLevel()
    {
        LevelController.instance.SkipToLevel(_solveLevel);
    }
}
