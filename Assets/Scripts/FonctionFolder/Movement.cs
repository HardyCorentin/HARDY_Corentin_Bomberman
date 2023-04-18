using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]private GameObject _actorToMove;
    public bool moveDone = false;
    public int movementSpeed = 1;

    [SerializeField] private LayerMask _cantMoveTowards;

    public void MoveLeft()
    {
        var nextPosition = new Vector3(_actorToMove.transform.position.x - 1, _actorToMove.transform.position.y + 0, _actorToMove.transform.position.z + 0);
        if (!(Physics.OverlapSphere(nextPosition, 0.1f, _cantMoveTowards).Length > 0))
        {
            _actorToMove.transform.position = nextPosition;
        }
        
    }


    public void MoveRight()
    {
        var nextPosition = new Vector3(_actorToMove.transform.position.x + 1, _actorToMove.transform.position.y + 0, _actorToMove.transform.position.z + 0);

        if (!(Physics.OverlapSphere(nextPosition, 0.1f, _cantMoveTowards).Length > 0))
        {
            _actorToMove.transform.position = nextPosition;
        }
        
      
    }



    public void MoveUp()
    {
        var nextPosition = new Vector3(_actorToMove.transform.position.x + 0, _actorToMove.transform.position.y + 1, _actorToMove.transform.position.z + 0);
        if (!(Physics.OverlapSphere(nextPosition, 0.1f, _cantMoveTowards).Length > 0))
        {
            _actorToMove.transform.position = nextPosition;
        }
     
    }



    public void MoveDown()
    {
        var nextPosition = new Vector3(_actorToMove.transform.position.x + 0, _actorToMove.transform.position.y -1 , _actorToMove.transform.position.z + 0);
        if (!(Physics.OverlapSphere(nextPosition, 0.1f, _cantMoveTowards).Length > 0))
        {
            _actorToMove.transform.position = nextPosition;
        }
    }
    
}
