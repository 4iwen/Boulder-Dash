using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Boulder_Dash;

internal class Map
{
    public Tile[,] TileMap { get; private set; }

    private Dictionary<TileType, Texture2D> _textures = new();

    private Tile[,] tiles =
    {

    };

    private Tile rockford;

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
                        tile = new Tile(character, line, TileType.Space, explodable: false, rounded: false, canFall: false, solid: false);
                        break;

                    case 'R':
                        tile = new Tile(character, line, TileType.Rockford, explodable: true, rounded: false, canFall: false, solid: false);
                        rockford = tile;
                        rockfordCount++;
                        break;

                    case 'd':
                        tile = new Tile(character, line, TileType.Dirt, explodable: true, rounded: false, canFall: false, solid: false);
                        break;

                    case 'D':
                        tile = new Tile(character, line, TileType.Diamond, explodable: false, rounded: true, canFall: true, solid: false);
                        break;

                    case 'b':
                        tile = new Tile(character, line, TileType.Boulder, explodable: false, rounded: true, canFall: true, solid: true);
                        break;

                    case 'W':
                        tile = new Tile(character, line, TileType.Wall, explodable: true, rounded: false, canFall: false, solid: true);
                        break;

                    case 'T':
                        tile = new Tile(character, line, TileType.TitaniumWall, explodable: false, rounded: false, canFall: false, solid: true);
                        break;

                    case 'F':
                        tile = new Tile(character, line, TileType.Firefly, explodable: true, rounded: false, canFall: false, solid: false);
                        break;

                    case 'B':
                        tile = new Tile(character, line, TileType.Butterfly, explodable: true, rounded: false, canFall: false, solid: false);
                        break;

                    case 'A':
                        tile = new Tile(character, line, TileType.Amoeba, explodable: false, rounded: false, canFall: false, solid: false);
                        break;

                    case 'E':
                        tile = new Tile(character, line, TileType.Exit, explodable: false, rounded: false, canFall: false, solid: false);
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
