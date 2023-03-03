using UnityEngine;

public class GoalTile : BaseTile
{
    [SerializeField] private Animator _levelCompleted;

    protected override void OnPlayerEnter()
    {
        _levelCompleted.SetTrigger("levelCompleted");
    }

    protected override void OnPlayerExit()
    {
        //Nada.
    }
}
