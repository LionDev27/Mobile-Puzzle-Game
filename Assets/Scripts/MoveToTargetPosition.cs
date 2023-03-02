using System.Collections;
using UnityEngine;

public class MoveToTargetPosition : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _timeToReach;
    [SerializeField] private float _timeToWaitUntilTransition;

    public void StartMoveToTarget()
    {
        StartCoroutine(nameof(MoveToTargetPosition));
    }

    IEnumerator MoveToTarget()
    {
        if (_target != null)
        {
            float elapsedTime = 0f;
            while (elapsedTime < _timeToReach)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target.position, elapsedTime / _timeToReach);
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }

        yield return new WaitForSeconds(_timeToWaitUntilTransition);

        LevelController.instance.LoadNextLevel();
    }
}
