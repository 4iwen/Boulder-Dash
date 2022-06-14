using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Boulder_Dash;

static class Program
{
    static bool GameOver = false;
    static string Message;

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
            if (!GameOver)
            {
                ClearBackground(Color.BLACK);
                map.Update(currentTick);
                map.Render();
                DrawText($"DIAMONDS: {map.CollectedDiamonds} / {map.TotalDiamonds}", 8, 8, 20, Color.BLUE);
                DrawText($"FPS: {GetFPS()}", 300, 8, 20, Color.WHITE);
                DrawText($"TICK: {currentTick}", 480, 8, 20, Color.GRAY);
            }
            else
            {
                DrawRectangle(GetScreenWidth() / 2 - MeasureText(Message, 40) / 2 - 16, GetScreenHeight() / 2 - 16, MeasureText(Message, 40) + 32, 64, Color.BLACK);
                DrawText(Message,
                    GetScreenWidth() / 2 - MeasureText(Message, 40) / 2,
                    GetScreenHeight() / 2, 40, Color.YELLOW);
            }
            EndDrawing();
        }
        
        CloseWindow();
    }

    public static void EndGame(TileType killer, bool lost = true)
    {
        GameOver = true;
        if (lost)
            Message = $"Game Over! You were killed by a {killer}!";
        else
            Message = $"Game Over! You were collected all the diamonds and won!";
    }
}