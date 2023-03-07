using UnityEngine;
using UnityEngine.UI;

namespace Guess.UI
{
    public abstract class BaseButton : MonoBehaviour
    {
        private Button _b;

        private void Awake()
        {
            _b = GetComponent(typeof(Button)) as Button;
        }

        private void Start()
        {
            _b.onClick.AddListener(OnClick);
        }

        protected abstract void OnClick();
    }
}