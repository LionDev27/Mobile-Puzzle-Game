using UnityEngine;

public class GoalTile : BaseTile
{
    protected override void OnPlayerEnter()
    {
        Debug.Log("Goal Reached");
    }

    protected override void OnPlayerExit()
    {
        //Nada.
    }
}
