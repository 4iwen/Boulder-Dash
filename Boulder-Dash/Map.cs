using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Raylib_cs;
using static Raylib_cs.Raylib;
using Boulder_Dash.Tiles;

namespace Boulder_Dash;

internal class Map
{
    public Tile[,] TileMap { get; private set; }

    private Dictionary<TileType, Texture2D> _textures = new();

    private Dictionary<TileType, Tile> tiles = new()
    {
        {
            TileType.Space,
            new Space(TileType.Space, Flag.None, 1)
        },
        {
            TileType.Rockford,
            new Rockford(TileType.Rockford, Flag.Explodable, 5)
        },
        {
            TileType.TitaniumWall,
            new Rockford(TileType.TitaniumWall, Flag.Solid, 1)
        },
        {
            TileType.Wall,
            new Rockford(TileType.Wall, Flag.Explodable | Flag.Solid, 1)
        },
        {
            TileType.Exit,
            new Rockford(TileType.Exit, Flag.Solid | Flag.Consumable, 1)
        },
        {
            TileType.Dirt,
            new Rockford(TileType.Dirt, Flag.Consumable | Flag.Explodable | Flag.Solid, 1)
        },
        {
            TileType.Boulder,
            new Rockford(TileType.Boulder, Flag.Solid | Flag.Pushable | Flag.CanFall | Flag.Rounded, 10) 
        },
        {
            TileType.Diamond,
            new Rockford(TileType.Diamond, Flag.Solid | Flag.Consumable | Flag.Rounded | Flag.CanFall, 10)
        },
        {
            TileType.Amoeba,
            new Rockford(TileType.Amoeba, Flag.Solid, 60)
        },
        {
            TileType.Firefly,
            new Rockford(TileType.Firefly, Flag.Explodable, 5)
        },
        {
            TileType.Butterfly,
            new Rockford(TileType.Butterfly, Flag.Explodable, 5)
        }
    };

    private Tile rockford;

    private void Update()
    {

    }

    public Map(string path) 
    {
        LoadTextures();
        LoadMapFromFile(path); 
    }

    private void LoadTextures()
    {
        _textures.Add(TileType.Space, LoadTexture(@"Assets\Sprites\space.png"));
        _textures.Add(TileType.Rockford, LoadTexture(@"Assets\Sprites\rockford.png"));
        _textures.Add(TileType.TitaniumWall, LoadTexture(@"Assets\Sprites\titanium_wall.png"));
        _textures.Add(TileType.Wall, LoadTexture(@"Assets\Sprites\wall.png"));
        _textures.Add(TileType.Firefly, LoadTexture(@"Assets\Sprites\firefly.png"));
        _textures.Add(TileType.Exit, LoadTexture(@"Assets\Sprites\exit.png"));
        _textures.Add(TileType.Dirt, LoadTexture(@"Assets\Sprites\dirt.png"));
        _textures.Add(TileType.Diamond, LoadTexture(@"Assets\Sprites\diamond.png"));
        _textures.Add(TileType.Butterfly, LoadTexture(@"Assets\Sprites\butterfly.png"));
        _textures.Add(TileType.Boulder, LoadTexture(@"Assets\Sprites\boulder.png"));
        _textures.Add(TileType.Amoeba, LoadTexture(@"Assets\Sprites\amoeba.png"));
    }

    public void LoadMapFromFile(string path)
    {
        int rockfordCount = 0, exitCount = 0;

        using StreamReader sr = new(path);

        string input = sr.ReadToEnd();
        string[] lines = input.Split(Environment.NewLine,
            StringSplitOptions.RemoveEmptyEntries);

        TileMap = new Tile[lines[0].Length, lines.Length];

        for (int line = 0; line < lines.Length; line++)
        {
            for (int character = 0; character < lines[line].Length; character++)
            {
                Tile tile;

                switch (lines[line][character])
                {
                    default:
                        tile = tiles[TileType.Space];
                        break;

                    case 'R':
                        tile = tiles[TileType.Rockford];
                        rockford = tile;
                        rockfordCount++;
                        break;

                    case 'd':
                        tile = tiles[TileType.Dirt];
                        break;

                    case 'D':
                        tile = tiles[TileType.Diamond];
                        break;

                    case 'b':
                        tile = tiles[TileType.Boulder];
                        break;

                    case 'W':
                        tile = tiles[TileType.Wall];
                        break;

                    case 'T':
                        tile = tiles[TileType.TitaniumWall];
                        break;

                    case 'F':
                        tile = tiles[TileType.Firefly];
                        break;

                    case 'B':
                        tile = tiles[TileType.Butterfly];
                        break;

                    case 'A':
                        tile = tiles[TileType.Amoeba];
                        break;

                    case 'E':
                        tile = tiles[TileType.Exit];
                        exitCount++;
                        break;
                }

                TileMap[character, line] = tile;
            }
        }
    }

    public void Render()
    {
        for (int y = 0; y < TileMap.GetLength(1); y++)
        {
            for (int x = 0; x < TileMap.GetLength(0); x++)
            {
                int pxWidth = _textures[TileMap[x, y].Type].width;
                int pxHeight = _textures[TileMap[x, y].Type].height;
                DrawTexture(_textures[TileMap[x, y].Type], x * pxWidth, y * pxHeight + pxHeight, Color.WHITE);
            }
        }
    }
}
