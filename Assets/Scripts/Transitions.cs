using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{
    private void GoToNextLevel()
    {
        LevelController.instance.LoadNextLevel();
    }
}
