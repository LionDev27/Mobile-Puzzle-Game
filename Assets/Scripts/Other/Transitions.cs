using Guess.LevelManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guess.Other
{
    public class Transitions : MonoBehaviour
    {
        private void OnTransitionAnimationEnd()
        {
            LevelController.instance.EndTransition();
        }
    }
}
