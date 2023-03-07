using UnityEngine;
using Guess.Solver;
using TMPro;

namespace Guess.UI
{
    public class ButtonSolveCharacter : BaseButton
    {
        [SerializeField] private CharacterSolver _solver;
        [SerializeField] private TMP_InputField _inputField;

        protected override void OnClick()
        {
            _solver.TryToSolveName(_inputField.text);
        }
    }
}