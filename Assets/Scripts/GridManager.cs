using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour
{
    [SerializeField] private TileScript Tileprefab;
    
    public int height;
    
    public int width;

    public bool generationDone = false;
    
    private float _willTileBeOccupied;
    
    public TileScript TileInQuestion;
    
    [SerializeField] private GameObject _destructableWallPrefab;

    [SerializeField] private GameObject _indestructableWallPrefab;

    [SerializeField] private GameObject _powerUpPrefab;

    [SerializeField] private GameObject _camera;

    [SerializeField] private GameObject _playerPrefab;

    [SerializeField] private GameObject _goalTile;

    [SerializeField] private bool _goalTileSpawned = false;

    [SerializeField]private bool _playerSpawned = false;

    [SerializeField] private int _xOfGoalTile;
    
    [SerializeField] private int _yOfGoalTile;
    //________________________________________________

    [SerializeField] private int _xOfPlayerTile;

    [SerializeField] private int _yOfPlayerTile;
    //_________________________________________________
    // Start is called before the first frame update
    void Start()
    {
        
            GenerateGrid(generationDone);
        
    }


    public TileScript[,] tileScripts;

    // Update is called once per frame
    public void GenerateGrid(bool done)
    {
        if (done == false)
        {
            Debug.Log("Coucou");

            tileScripts = new TileScript[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    SpawnSomeTiles(x, y, width, height);

                }
            }
            SpawnSomeXBorders(width, height);

            SpawnSomeYBorders(width, height);

            SpawnGoalTile(width, height);

            SpawnAPlayer(width, height);

            _camera.transform.position = new Vector3(width / 2, height / 2, -10f);//Put the camera at the center of the map, to make sure that the player sees the most of it, under the condition that it is not too large of course.
            done = true;
        }
    }



    
    
    
    
    
    
    
    
    
    
    
    
  // The functions. Protect your eyes. They may melt.  
  
    
    
    
    
    
    
    
    
    public TileScript GetTileAtLocation(int x, int y)
    {
        if(x>=0 && x<width && y >=0 && y<height)
        {
            return tileScripts[x, y];
        }
        return null;
    }

    
    //Check if a tile has free spaces around it so the player can move and not die 
    public bool IsTileOpen(TileScript tile)
    {
        return
            !tile.isOccupied
            &&
            (
            TileExistAndIsFree(tile.coordinates.x + 1, tile.coordinates.y)
            ||
            TileExistAndIsFree(tile.coordinates.x - 1, tile.coordinates.y)
            &&
             TileExistAndIsFree(tile.coordinates.x, tile.coordinates.y + 1)
            ||
             TileExistAndIsFree(tile.coordinates.x, tile.coordinates.y - 1)
            );
    }

    public bool TileExistAndIsFree(int x, int y)
    {
        var tile = GetTileAtLocation(x, y);
        return tile != null && !tile.isOccupied;
    }


    //Yeah I know I kinda moved the issue there, but I didn't have the time to clean it all up. Sorry
    private void SpawnSomeTiles(int x, int y,int width,int height)
    {
        var SpawnTile = Instantiate(Tileprefab, new Vector3(x, y, 1), Quaternion.identity);

        SpawnTile.name = $"Tile + {x} + {y}";

        tileScripts[x, y] = SpawnTile;
        _willTileBeOccupied = (Random.Range(-10.0f, 10.0f));
        //End of spawning a tile
        //__________________________________________________________________________________________________________
        //Check if the tile will be occupied by a Destructible wall or not.
        if (_willTileBeOccupied < 0f && _willTileBeOccupied >= -7f)
        {
            //Spawn the wall
            var SpawnAWall = Instantiate(_destructableWallPrefab, new Vector3(x, y, -1), Quaternion.identity);

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

            //________________________________________________________________________________________________________________

            //___________________________________________________________________________________________________________________
            //Check if the tile will be occupied by a power up

            else if (_willTileBeOccupied > 9f && _willTileBeOccupied <= 10f)
            {
                //Spawn the wall
                var SpawnAPowerUp = Instantiate(_powerUpPrefab, new Vector3(x, y, -1), Quaternion.identity);

                SpawnAPowerUp.name = $"PowerUp + {x} + {y}";

                TileInQuestion = SpawnTile.GetComponent<TileScript>();

                if (TileInQuestion == true)
                {
                    TileInQuestion.isOccupied = true; //Make the tile "occupied" so that no other thing can spawn on it.
                }

            }
        }
    }


    private void SpawnSomeXBorders(int width,int height)
    {
        for (int xborder = 0; xborder < width; xborder++)
        {
            var SpawnXTopBorderTile = Instantiate(Tileprefab, new Vector3(xborder, height), Quaternion.identity);

            var SpawnXTopBorderWall = Instantiate(_indestructableWallPrefab, new Vector3(xborder, height, -1), Quaternion.identity);

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
    }





    private void SpawnSomeYBorders(int width, int height)
    {
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

            var SpawnYBotBorderTile = Instantiate(Tileprefab, new Vector3(width, yborder, -1), Quaternion.identity);

            var SpawnYBotBorderWall = Instantiate(_indestructableWallPrefab, new Vector3(width, yborder, -1), Quaternion.identity);

            TileInQuestion = SpawnYBotBorderTile.GetComponent<TileScript>();

            if (TileInQuestion == true)
            {
                TileInQuestion.isOccupied = true;
            }

            SpawnYBotBorderTile.name = $"BorderTile + {-1} + {yborder}";

            SpawnYBotBorderWall.name = $"BorderWall + {-1} + {yborder}";
        }
    }

    private void SpawnGoalTile(int width , int height)
    {
        while (_goalTileSpawned == false)
        {
            _xOfGoalTile = Random.Range(0, width);
            _yOfGoalTile = Random.Range(0, height);
            TileInQuestion = GetTileAtLocation(_xOfGoalTile, _yOfGoalTile);
            if (TileInQuestion.isOccupied == false)
            {
                var SpawnAGoalTile = Instantiate(_goalTile, new Vector3(_xOfGoalTile, _yOfGoalTile, 0), Quaternion.identity);

                SpawnAGoalTile.name = $"GoalTile + {_xOfGoalTile} + {_yOfGoalTile}";

                _goalTileSpawned = true;

                TileInQuestion = SpawnAGoalTile.GetComponent<TileScript>();

                if (TileInQuestion == true)
                {
                    TileInQuestion.isOccupied = true; //Make the tile "occupied" so that no other thing can spawn on it.
                }
            }
            


        }
    }


    private void SpawnAPlayer(int height,int width)
    {
        _xOfPlayerTile = Random.Range(0, width);
        _yOfPlayerTile = Random.Range(0, height);
        TileInQuestion = GetTileAtLocation(_xOfPlayerTile, _yOfPlayerTile);
        int index = 0;
        while (!IsTileOpen(TileInQuestion) && index < 10)
        {
            _xOfPlayerTile = Random.Range(0, width);
            _yOfPlayerTile = Random.Range(0, height);
            TileInQuestion = GetTileAtLocation(_xOfPlayerTile, _yOfPlayerTile);
            index++;
        }

        if (index >= 9)
        {
            var SpawnPlayerDefault = Instantiate(_playerPrefab, new Vector3(_xOfPlayerTile, _yOfPlayerTile, -1), Quaternion.identity);
            _playerSpawned = true;
            IsTileOpen(TileInQuestion);

        }
        print("SpawnPlayer");
        var SpawnPlayer = Instantiate(_playerPrefab, new Vector3(_xOfPlayerTile, _yOfPlayerTile, -1), Quaternion.identity);
        SpawnPlayer.name = $"Player";
        _playerSpawned = true;
    }


}
