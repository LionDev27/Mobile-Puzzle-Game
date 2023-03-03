using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CharacterScritpableObject")]
public class CharacterNameScriptableObject : ScriptableObject
{
    public string characterName;
    [TextArea(1, 20)]
    public string descritption;
}
