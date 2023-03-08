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
            _solver.solveModeActive = true;
            LevelController.instance.StartLevelTransition(() =>
            {
                _solver.gameObject.SetActive(true);
                _solver.EnterSolveMode();
            });
        }
    }
}
