using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]private GameObject _actorToMove;
    public bool moveDone = false;
    public int movementSpeed = 1;

    public void MoveLeft()
    {
        _actorToMove.transform.position = new Vector3(_actorToMove.transform.position.x - 1, _actorToMove.transform.position.y + 0, _actorToMove.transform.position.z + 0);
        moveDone = true;
}
    public void MoveRight()
    {
        _actorToMove.transform.position = new Vector3(_actorToMove.transform.position.x + 1, _actorToMove.transform.position.y + 0, _actorToMove.transform.position.z + 0);
        moveDone = true;
    }
    public void MoveUp()
    {
        _actorToMove.transform.position = new Vector3(_actorToMove.transform.position.x + 0, _actorToMove.transform.position.y + 1, _actorToMove.transform.position.z + 0);
        moveDone = true;
    }
    public void MoveDown()
    {
        _actorToMove.transform.position = new Vector3(_actorToMove.transform.position.x+0, _actorToMove.transform.position.y-1, _actorToMove.transform.position.z + 0);
        moveDone = true;
    }
}
