using System;
using SFML.Learning;
using SFML.System;
using SFML.Window;

class BrainTeaser : Game
{
    static string sound = LoadSound("sound.wav");
    static string crachSound = LoadSound("crashSound.wav");

    static string[] colorNames = new string[] { "Красный", "Синий", "Зеленый", "Желтый" };
    static string[] colors = new string[] { "Зеленый", "Желтый", "Красный", "Синий" };


    static string nameNow = "";
    static string colorNow = "";

    static string playerAnswer = "";
    static int playerScore = 0;
    static int playerRecord = 0;

    static void InitColorName()
    {
        Random rnd = new Random();
        nameNow = colorNames[rnd.Next(0, colorNames.Length)];
    }
    static void InitColor()
    {
        Random rand = new Random();
        colorNow = colors[rand.Next(0, colors.Length)];                    
    }
    static void SetColorText()
    {
        if (colorNow == "Красный") SetFillColor(255, 0, 0);
        if (colorNow == "Синий") SetFillColor(0, 0, 255);
        if (colorNow == "Зеленый") SetFillColor(0, 255, 0);
        if (colorNow == "Желтый") SetFillColor(255, 255, 0);

    }
    static void PlayerMove()
    {
        if (GetKeyDown(Keyboard.Key.C) == true) playerAnswer = "Синий"; //С - синий
        if (GetKeyDown(Keyboard.Key.P) == true) playerAnswer = "Зеленый"; //З - зеленый
        if (GetKeyDown(Keyboard.Key.R) == true) playerAnswer = "Красный"; //К - красный
        if (GetKeyDown(Keyboard.Key.SemiColon) == true) playerAnswer = "Желтый"; //Ж - желтйы
    }
    static void Main(string[] args)
    {

        SetFont("comic.ttf");
        InitWindow(800, 600, "Brain-teaser");

        InitColorName();
        InitColor();

        while (true)
        {
            DispatchEvents();

            PlayerMove();

            //Проверка на проигрыш
            if (playerAnswer != "" && playerAnswer != colorNow)
            {
                PlaySound(crachSound, 5);

                if (playerRecord <= playerScore)
                    playerRecord = playerScore;

                playerAnswer = "";
                playerScore = 0;
                InitColorName();
                InitColor();
            }

            //Проверка на выигрыш
            if (playerAnswer == colorNow)
            {
                PlaySound(sound, 5);

                playerScore++;
                playerAnswer = "";
                InitColorName();
                InitColor();
            }

            ClearWindow();

            SetFillColor(255, 255, 255);
            DrawText(10, 0, "Укажите правильный цвет надписи.", 24);
            DrawText(10, 35, "Клавиши:", 24);
            DrawText(10, 60, "Синий - С", 24);
            DrawText(10, 85, "Желтый - Ж", 24);
            DrawText(10, 110, "Зеленый - З", 24);
            DrawText(10, 135, "Красный - К", 24);

            DrawText(350, 350, $"Счет: {playerScore.ToString()}", 24);

            DrawText(10, 550, $"Рекорд: {playerRecord.ToString()}", 24);

            SetColorText();
            DrawText(350, 300, nameNow, 30);

            DisplayWindow();

            Delay(1);
        }
    }
}
