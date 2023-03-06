using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Guess.Categories
{
    public class CategoryController : MonoBehaviour
    {
        [SerializeField] private CategoryScriptableObject[] _categories;
        private CategoryScriptableObject _currentCategory;

        [SerializeField] private Image _background, _transition, _faces;
        [SerializeField] private SpriteRenderer _logo;

        [ContextMenu("SelectNewCategory")]
        public void SelectNewCategory()
        {
            GetRandomCategory();
        }

        private void GetRandomCategory()
        {
            int randomCategory = Random.Range(0, _categories.Length);
            _currentCategory = _categories[randomCategory];
            SetCategory();
        }

        private void SetCategory()
        {
            _background.color = _currentCategory.primaryColor;
            _transition.color = _currentCategory.primaryColor;
            _faces.color = _currentCategory.primaryColor;
            _faces.sprite = _currentCategory.backgroundFaces;
            _logo.color = _currentCategory.secondaryColor;
        }

        public CategoryScriptableObject GetCurrentCategory()
        {
            return _currentCategory;
        }
    }
}
