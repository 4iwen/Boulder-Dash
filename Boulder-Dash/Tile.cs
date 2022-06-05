using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulder_Dash
{
    internal class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public TileType Type { get; private set; }
        public bool Explodable { get; private set; }
        public bool Rounded { get; private set; }
        public bool CanFall { get; private set; }
        public bool Solid { get; private set; }

        public Tile(int x, int y, TileType type, bool explodable, bool rounded, bool canFall, bool solid)
        {
            X = x;
            Y = y;
            Type = type;
            Explodable = explodable;
            Rounded = rounded;
            CanFall = canFall;
            Solid = solid;
        }

        public void Step(Tile[,] map, Tile self, int x = 0, int y = 0)
        {
            switch (self.Type)
            {
                default:
                    break;

                case TileType.Rockford:
                    RockfordStep(map, self, x, y);
                    break;
            }    


        }

        private void RockfordStep(Tile[,] map, Tile self, int x, int y)
        {
            if (!map[self.X + x, self.Y + y].Solid)
            {
                map[self.X, self.Y] = new Tile(self.X, self.Y, TileType.Space, false, false, false, false);
                map[self.X + x, self.Y + y] = self;

                self.X += x;
                self.Y += y;
            }
        }
    }
}
