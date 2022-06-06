using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulder_Dash;

public enum TileType
{
    Space = 0,
    Rockford,
    Dirt,
    Boulder,
    Diamond,
    Wall,
    TitaniumWall,
    Firefly,
    Butterfly,
    Amoeba,
    Exit
}

public enum Direction
{
    None = 0,
    Up,
    Down,
    Left,
    Right
}

[Flags]
public enum Flag
{
    None = 0,
    Solid = 1,
    CanFall = 2,
    Explodable = 4,
    Rounded = 8,
    Consumable = 16,
}