using UnityEngine;
using UnityEngine.UI;
using Guess.LevelManagement;
using Guess.Solver;

namespace Guess.Categories
{
    public class CategoryController : MonoBehaviour
    {
        [SerializeField] private CategoryScriptableObject[] _categories;
        private CategoryScriptableObject _currentCategory;
        private CharacterData _characterData;

        [SerializeField] private Image _background, _transition, _faces;
        [SerializeField] private SpriteRenderer _logo;
        [SerializeField] private SpriteRenderer _characterPrev;
        [SerializeField] private Image _characterHint;

        [SerializeField] private CharacterSolver _characterSolver;

        [SerializeField] private LevelController _levelControllerInstance;

        private int _sillouetteLevel;

        public static CategoryController instance;

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
            SelectNewCategory();
        }

        [ContextMenu("SelectNewCategory")]
        public void SelectNewCategory()
        {
            GetRandomCategory();
        }

        private void GetRandomCategory()
        {
            ResetSillouetteLevel();
            int randomCategory = Random.Range(0, _categories.Length);
            _currentCategory = _categories[randomCategory];
            SetCategory();
            GetRandomCharacter();
            SetInitialCharacter();
        }

        private void SetCategory()
        {
            _background.color = _currentCategory.primaryColor;
            _transition.color = _currentCategory.primaryColor;
            _faces.color = _currentCategory.primaryColor;
            _faces.sprite = _currentCategory.backgroundFaces;
            _logo.color = _currentCategory.secondaryColor;
        }

        private void SetInitialCharacter()
        {
            _characterPrev.sprite = _characterData.characterCompletionLevels[0];
            _characterHint.sprite = _characterData.characterCompletionLevels[1];
        }

        private void GetRandomCharacter()
        {
            int randomCharacter = Random.Range(0, _currentCategory._characterData.Length);
            _characterData = _currentCategory._characterData[randomCharacter];
        }

        public void IncreaseSillouetteLevel()
        {
            if (_characterSolver.solveModeActive) return;

            _sillouetteLevel++;
            _sillouetteLevel = Mathf.Clamp(_sillouetteLevel, 0, _characterData.characterCompletionLevels.Length - 1);
            SetCharacterHints(_sillouetteLevel);
        }

        private void ResetSillouetteLevel()
        {
            _sillouetteLevel = 0;
        }

        public Sprite GetCurrentCharacterLevelSprite()
        {
            return _characterData.characterCompletionLevels[_sillouetteLevel];
        }

        public string GetCharacterName()
        {
            return _characterData.characterName;
        }

        public bool IsSillouetteAtMaxLevel()
        {
            return _sillouetteLevel >= _characterData.characterCompletionLevels.Length - 1;
        }

        private void SetCharacterHints(int level)
        {
            _characterPrev.sprite = _characterData.characterCompletionLevels[level];
            _characterHint.sprite = _characterData.characterCompletionLevels[level];
        }

        public CategoryScriptableObject GetCurrentCategory()
        {
            return _currentCategory;
        }
    }
}
