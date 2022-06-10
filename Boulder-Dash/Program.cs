using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Boulder_Dash;

static class Program
{
    public static void Main()
    {
        int currentTick = 0;

        InitWindow(1280, 704 + 32, "Boulder Dash");
        SetTargetFPS(60);

        Map map = new(path: "map.txt");

        while (!WindowShouldClose())
        {
            currentTick++;

            BeginDrawing();
            ClearBackground(Color.BLACK);
            DrawText($"DIAMONDS: {map.CollectedDiamonds} / {map.TotalDiamonds}", 8, 8, 20, Color.BLUE);
            DrawText($"FPS: {GetFPS()}", 300, 8, 20, Color.WHITE);
            DrawText($"TICK: {currentTick}", 480, 8, 20, Color.GRAY);

            map.Update(currentTick);
            map.Render();

            EndDrawing();
        }

        CloseWindow();
    }
}