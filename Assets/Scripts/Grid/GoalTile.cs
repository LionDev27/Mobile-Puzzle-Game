using Guess.LevelManagement;
using UnityEngine;

namespace Guess.Grid
{
    public class GoalTile : BaseTile
    {
        protected override void OnPlayerEnter()
        {
            LevelController.instance.StartLevelTransition(() => { });
        }

        protected override void OnPlayerExit()
        {
            //Nada.
        }
    }
}
