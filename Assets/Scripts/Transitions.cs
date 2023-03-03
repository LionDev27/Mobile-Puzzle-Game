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

    private void GoToLastLevel()
    {
        LevelController.instance.LoadSavedLevel();
    }

    private void GoToSolveLevel()
    {
        LevelController.instance.SkipToLevel(_solveLevel);
    }
}
