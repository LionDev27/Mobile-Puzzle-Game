using Guess.Categories;
using UnityEngine;



public class CharacterSolver : MonoBehaviour
{
    [Tooltip("Poner en orden, dependiendo del nivel, las partes que tendría al intentar resolver")]
    //[SerializeField] private LevelAndSprite[] _levelAndSprite;
    private SpriteRenderer _sR;
    [SerializeField] private CategoryScriptableObject _characterName;

    private void Awake()
    {
        _sR = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
    }

    private void Start()
    {
        /*foreach (var levelSprite in _levelAndSprite)
        {
            if(levelSprite.level == LevelController.instance.GetCurrentLevel())
            {
                _sR.sprite = levelSprite.sprite;
                break;
            }
        }*/
    }

    /*public bool TryToSolveName(string name)
    {
        //xd lol.
        if(name == _characterName)
        {
            return true;
        }

        return false;
    }*/
}
