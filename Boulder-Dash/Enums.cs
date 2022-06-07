using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulder_Dash;

public enum TileType
{
    Space,
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
    None,
    Up,
    Down,
    Left,
    Right
}

[Flags]
public enum Flag
{
    None = 0,
    Pushable = 1,
    CanFall = 2,
    Explodable = 4,
    Rounded = 8,
    Consumable = 16,
    Solid = 32
}