using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LevelAndSprite
{
    [Tooltip("Numero dentro de la build")]
    public int level;
    public Sprite sprite;
}

public class CharacterSolver : MonoBehaviour
{
    [Tooltip("Poner en orden, dependiendo del nivel, las partes que tendría al intentar resolver")]
    [SerializeField] private LevelAndSprite[] _levelAndSprite;
    private SpriteRenderer _sR;
    [SerializeField] private CharacterNameScriptableObject _characterName;

    private void Awake()
    {
        _sR = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
    }

    private void Start()
    {
        foreach (var levelSprite in _levelAndSprite)
        {
            if(levelSprite.level == LevelController.instance.GetCurrentLevel())
            {
                _sR.sprite = levelSprite.sprite;
                break;
            }
        }
    }

    public void TryToSolveName(string name)
    {
        //xd lol.
        if(name == _characterName.characterName)
        {
            Debug.Log("El nombre es correcto");
        }
        else
        {
            Debug.Log("El nombre no es correcto");
        }
    }
}
