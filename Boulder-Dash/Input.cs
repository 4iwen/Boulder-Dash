using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Boulder_Dash
{
    internal static class Input
    {
        public static Direction GetDirection()
        {
            if (IsKeyDown(KeyboardKey.KEY_LEFT)) return Direction.Left;
            if (IsKeyDown(KeyboardKey.KEY_RIGHT)) return Direction.Right;
            if (IsKeyDown(KeyboardKey.KEY_UP)) return Direction.Up;
            if (IsKeyDown(KeyboardKey.KEY_DOWN)) return Direction.Down;
            return Direction.None;
        }
    }
}
