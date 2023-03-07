using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Guess.Solver
{
    public class UITextCharacterName : MonoBehaviour
    {
        private Button _b;
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private CharacterSolver _solver;
        [SerializeField] private Animator _anim;

        private void Awake()
        {
            _b = GetComponent(typeof(Button)) as Button;
        }

        private void Start()
        {
            _b.onClick.AddListener(SolveName);
        }

        void SolveName()
        {
            /*if (_solver.TryToSolveName(_inputField.text))
            {
                //LevelController.instance.SaveCurrentLevel();
                _anim.SetTrigger("levelCompleted");
            }
            else
            {
                _anim.SetTrigger("levelRestart");
            }*/
        }
    }
}
