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
    public int TotalDiamonds, CollectedDiamonds;
    public Tile[,] TileMap;

    private readonly Dictionary<TileType, Texture2D> _textures = new();

    public void Update(int currentTick)
    {
        for (int x = 0; x < TileMap.GetLength(0); x++)
        {
            for (int y = 0; y < TileMap.GetLength(1); y++)
            {
                TileMap[x, y].MovedThisTick = false;
            }
        }

        for (int y = TileMap.GetLength(1) - 1; y >= 0; y--)
        {
            for (int x = TileMap.GetLength(0) - 1; x >= 0; x--)
            {
                TileMap[x, y].Update(currentTick, this);
            }
        }
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
        using StreamReader sr = new(path);

        string input = sr.ReadToEnd();
        string[] lines = input.Split(Environment.NewLine,
            StringSplitOptions.RemoveEmptyEntries);

        TileMap = new Tile[lines[0].Length, lines.Length];

        int diamonds = 0;

        for (int line = 0; line < lines.Length; line++)
        {
            for (int character = 0; character < lines[line].Length; character++)
            {
                Tile tile;

                switch(lines[line][character]) 
                {

                    default:
                        tile = new Space(TileType.Space, Flag.None, 1, character, line);
                        break;

                    case 'R':
                        tile = new Rockford(TileType.Rockford, Flag.Explodable, 6, character, line);
                        break;
                    case 'd':
                        tile = new Dirt(TileType.Dirt, Flag.Consumable | Flag.Explodable, 1, character, line);
                        break;
                    case 'D': 
                        tile = new Diamond(TileType.Diamond, Flag.Consumable | Flag.Rounded | Flag.CanFall, 10, character, line);
                        diamonds++;
                        break;
                    case 'b': 
                        tile = new Boulder(TileType.Boulder, Flag.Solid | Flag.Pushable | Flag.CanFall | Flag.Rounded, 10, character, line);
                        break;
                    case 'W': 
                        tile = new Wall(TileType.Wall, Flag.Explodable | Flag.Solid, 1, character, line);
                        break;
                    case 'T':
                        tile = new TitaniumWall(TileType.TitaniumWall, Flag.Solid, 1, character, line);
                        break;
                    case 'F':
                        tile = new Firefly(TileType.Firefly, Flag.Explodable, 5, character, line);
                        break;
                    case 'B': 
                        tile = new Butterfly(TileType.Butterfly, Flag.Explodable, 5, character, line);
                        break;
                    case 'A':
                        tile = new Amoeba(TileType.Amoeba, Flag.Solid, 60, character, line);
                        break;
                    case 'E': 
                        tile = new Exit(TileType.Exit, Flag.Solid | Flag.Consumable, 1, character, line);
                        break;
                }

                TileMap[character, line] = tile;
            }
        }

        TotalDiamonds = diamonds;
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
