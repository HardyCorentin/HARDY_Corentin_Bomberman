using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutTheBombDown : MonoBehaviour
{
    [SerializeField] private GameObject _actortoTakePositionFrom;
    [SerializeField] private GameObject _bombPrefab;
    // Start is called before the first frame update
    public void DropBomb()
    {
        var SpawnBomb = Instantiate(_bombPrefab, new Vector3(_actortoTakePositionFrom.transform.position.x, _actortoTakePositionFrom.transform.position.y, - 1), Quaternion.identity);
    }
}
