using Guess.Categories;
using Guess.LevelManagement;
using Guess.Solver;
using UnityEngine;

namespace Guess.UI
{
    public class ButtonGoToSolver : BaseButton
    {
        [SerializeField] private CharacterSolver _solver;

        protected override void OnClick()
        {
            LevelController.instance.CompleteLevel();
            _solver.gameObject.SetActive(true);
            _solver.EnterSolveMode();
        }
    }
}
