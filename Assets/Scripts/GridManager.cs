using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private TileScript Tileprefab;
    
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


    public TileScript[,] tileScripts;

    // Update is called once per frame
   public void GenerateGrid()
    {

        tileScripts = new TileScript[width, height];
      for(int x=0; x <width; x++)
        {
            for (int y = 0; y < width; y++)
            {
                //Spawn a tile
                var SpawnTile = Instantiate(Tileprefab,new Vector3(x, y), Quaternion.identity);
                
                SpawnTile.name = $"Tile + {x} + {y}";

                tileScripts[x, y] = SpawnTile;
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

                //GetTileAtLocation(x,y);
                //IsTileOpen(TileInQuestion);
                
                //End of check
                //___________________________________________________________________________________________________________________
                //Create map border to block the player from going out of bounds.
                for (int xborder = 0; xborder < width; xborder++)
                {
                    var SpawnXTopBorderTile = Instantiate(Tileprefab, new Vector3(xborder, height), Quaternion.identity);

                    var SpawnXTopBorderWall = Instantiate(_indestructableWallPrefab, new Vector3(xborder, height,-1), Quaternion.identity);

                    TileInQuestion = SpawnXTopBorderTile.GetComponent<TileScript>();

                    if (TileInQuestion == true)
                    {
                        TileInQuestion.isOccupied = true;
                    }

                    SpawnXTopBorderTile.name = $"BorderTile + {xborder} + {height}";

                    SpawnXTopBorderWall.name = $"BorderWall + {xborder} + {height}";

                    var SpawnXBotBorderTile = Instantiate(Tileprefab, new Vector3(xborder, -1), Quaternion.identity);

                    var SpawnXBotBorderWall = Instantiate(_indestructableWallPrefab, new Vector3(xborder, -1, -1), Quaternion.identity);

                    TileInQuestion = SpawnXBotBorderTile.GetComponent<TileScript>();

                    if (TileInQuestion == true)
                    {
                        TileInQuestion.isOccupied = true;
                    }

                    SpawnXBotBorderTile.name = $"BorderTile + {xborder} + {-1}";

                    SpawnXBotBorderWall.name = $"BorderWall + {xborder} + {-1}";
                }





                for (int yborder = 0; yborder < height; yborder++)
                {
                    var SpawnYTopBorderTile = Instantiate(Tileprefab, new Vector3(-1, yborder), Quaternion.identity);

                    var SpawnYTopBorderWall = Instantiate(_indestructableWallPrefab, new Vector3(-1, yborder, -1), Quaternion.identity);

                    TileInQuestion = SpawnYTopBorderTile.GetComponent<TileScript>();

                    if (TileInQuestion == true)
                    {
                        TileInQuestion.isOccupied = true;
                    }

                    SpawnYTopBorderTile.name = $"BorderTile + {width} + {yborder}";

                    SpawnYTopBorderWall.name = $"BorderWall + {width} + {yborder}";

                    var SpawnYBotBorderTile = Instantiate(Tileprefab, new Vector3(width,yborder, -1), Quaternion.identity);

                    var SpawnYBotBorderWall = Instantiate(_indestructableWallPrefab, new Vector3(width, yborder, -1), Quaternion.identity);

                    TileInQuestion = SpawnYBotBorderTile.GetComponent<TileScript>();

                    if (TileInQuestion == true)
                    {
                        TileInQuestion.isOccupied = true;
                    }

                    SpawnYBotBorderTile.name = $"BorderTile + {-1} + {yborder}";

                    SpawnYBotBorderWall.name = $"BorderWall + {-1} + {yborder}";
                }

                //__________________________________________________________________________________________________________________

                //Ask Louis to explain how his things work, because it's nearing eldritch level of incomprehension
            }
        }
        _camera.transform.position = new Vector3(width / 2, height / 2, -10f);//Put the camera at the center of the map, to make sure that the player sees the most of it, under the condition that it is not too large of course.
    }



    public TileScript GetTileAtLocation(int x, int y)
    {
        return tileScripts[x, y];
    }

    
    //Check if a tile has free spaces around it so the player can move and not die 
    public bool IsTileOpen(TileScript tile)
    {
        return
            !tile.isOccupied
            &&
            (
            !GetTileAtLocation(tile.coordinates.x + 1, tile.coordinates.y).isOccupied
            ||
             !GetTileAtLocation(tile.coordinates.x - 1, tile.coordinates.y).isOccupied
            &&
             !GetTileAtLocation(tile.coordinates.x, tile.coordinates.y + 1).isOccupied
            ||
             !GetTileAtLocation(tile.coordinates.x, tile.coordinates.y - 1).isOccupied
            );
    }
}
