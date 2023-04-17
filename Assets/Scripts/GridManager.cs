using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject Tileprefab;
    
    public int height;
    
    public int width;
    
    private float _willTileBeOccupied;
    
    public TileScript TileInQuestion;
    
    [SerializeField] private GameObject _destructableWallPrefab;

    [SerializeField] private GameObject _indestructableWallPrefab;

    [SerializeField] private GameObject _powerUpPrefab;

    [SerializeField] private GameObject _camera;
    
    private bool _isPlayerSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
   public void GenerateGrid()
    {
      for(int x=0; x <width; x++)
        {
            for (int y = 0; y < width; y++)
            {
                //Spawn a tile
                var SpawnTile = Instantiate(Tileprefab,new Vector3(x, y), Quaternion.identity);
                
                SpawnTile.name = $"Tile + {x} + {y}";
                
                _willTileBeOccupied = (Random.Range(-10.0f, 10.0f));
                //End of spawning a tile
                //__________________________________________________________________________________________________________
                //Check if the tile will be occupied by a Destructible wall or not.
                if (_willTileBeOccupied < 0f && _willTileBeOccupied >= -7f)
                {
                    //Spawn the wall
                    var SpawnAWall  = Instantiate(_destructableWallPrefab,new Vector3(x, y,-1), Quaternion.identity);
                    
                    SpawnAWall.name = $"DestructibleWall + {x} + {y}";
                    
                    TileInQuestion = SpawnTile.GetComponent<TileScript>();
                    
                    if (TileInQuestion == true)
                    {
                        TileInQuestion.isOccupied = true; //Make the tile "occupied" so that no other thing can spawn on it. (will be usefull for the player spawn later.)
                    }

                }
                //End of check
                //_____________________________________________________________________________________________________________
                //Check if the tile will be occupied by an indestrucable wall
                else if (_willTileBeOccupied > 0f && _willTileBeOccupied <= 2f)
                {
                    //Spawn the wall
                    var SpawnASolidWall = Instantiate(_indestructableWallPrefab, new Vector3(x, y, -1), Quaternion.identity);

                    SpawnASolidWall.name = $"IndestructibleWall + {x} + {y}";

                    TileInQuestion = SpawnTile.GetComponent<TileScript>();

                    if (TileInQuestion == true)
                    {
                        TileInQuestion.isOccupied = true; //Make the tile "occupied" so that no other thing can spawn or walk on it.
                    }

                }
                //End of check
                //___________________________________________________________________________________________________________________
                //Check if the tile will be occupied by an indestrucable wall
                else if (_willTileBeOccupied > 9f && _willTileBeOccupied <= 10f)
                {
                    //Spawn the wall
                    var SpawnAPowerUp = Instantiate(_powerUpPrefab, new Vector3(x, y, -1), Quaternion.identity);

                    SpawnAPowerUp.name = $"PowerUp + {x} + {y}";

                    TileInQuestion = SpawnTile.GetComponent<TileScript>();

                    if (TileInQuestion == true)
                    {
                        TileInQuestion.isOccupied = true; //Make the tile "occupied" so that no other thing can spawn or walk on it.
                    }

                }
                //End of check
                //___________________________________________________________________________________________________________________
                //Ask Louis about ho to check an entire layer
            }
        }
        _camera.transform.position = new Vector3(width / 2, height / 2, -10f);//Put the camera at the center of the map, to make sure that the player sees the most of it, under the condition that it is not too large of course.
    }
}
