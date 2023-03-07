using Guess.Categories;
using Guess.LevelManagement;
using UnityEngine;

namespace Guess.Solver
{
    public class CharacterSolver : MonoBehaviour
    {
        private SpriteRenderer _sR;
        [HideInInspector] public bool solveModeActive;
        [SerializeField] private GameObject[] objectsToHide, objectsToShow;
        [SerializeField] private Animator _transition;
        private string _characterName;

        private void Awake()
        {
            _sR = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        }

        public void EnterSolveMode()
        {
            solveModeActive = true;
            _characterName = CategoryController.instance.GetCharacterName();

            foreach (GameObject obj in objectsToHide)
            {
                obj.SetActive(false);
            }

            foreach (GameObject obj in objectsToShow)
            {
                obj.SetActive(true);
            }

            _sR.sprite = CategoryController.instance.GetCurrentCharacterLevelSprite();
        }

        private void ExitSolveMode()
        {
            solveModeActive = false;

            foreach (GameObject obj in objectsToHide)
            {
                obj.SetActive(true);
            }

            foreach (GameObject obj in objectsToShow)
            {
                obj.SetActive(false);
            }

            gameObject.SetActive(false);
        }

        public void TryToSolveName(string name)
        {
            if (name == _characterName)
            {
                CategoryController.instance.SelectNewCategory();
                LevelController.instance.CompleteLevel();
                _transition.SetTrigger("correct");
                ExitSolveMode();
            }
            else if (CategoryController.instance.IsSillouetteAtMaxLevel())
            {
                CategoryController.instance.SelectNewCategory();
                LevelController.instance.CompleteLevel();
                _transition.SetTrigger("notCorrect");
                ExitSolveMode();
            }
            else
            {
                LevelController.instance.CompleteLevel();
                _transition.SetTrigger("notCorrect");
                ExitSolveMode();
            }
        }
    }
}
