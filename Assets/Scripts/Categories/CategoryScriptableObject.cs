using UnityEngine;

namespace Guess.Categories
{
    [System.Serializable]
    public struct CharacterData
    {
        public string characterName;
        [Tooltip("Aqui poner en orden los niveles de completación de la figura")]
        public Sprite[] characterCompletionLevels;
        [TextArea(1, 20)]
        public string descritption;
    }

    [CreateAssetMenu(menuName = "ScriptableObjects/CategoryScritpableObject")]
    public class CategoryScriptableObject : ScriptableObject
    {
        public string categoryLabel;
        public CharacterData[] _characterData;
        [Tooltip("Color del fondo y las caras")]
        public Color primaryColor;
        [Tooltip("Color del logo y otras cosas secundarias")]
        public Color secondaryColor;
        public Sprite backgroundFaces;
        public GameObject[] levels;
    }
}
