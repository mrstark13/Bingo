using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BingoController : MonoBehaviour
{
    public GameObject winObj;
    public ScoreController scoreContr;
    public Button bingoButt;
    static int bingoMult;
    public int valueBingoScore
    {
        get { return bingoMult; }
        set
        {
            bingoMult = value;
        }
    }

    void Start()
    {
        valueBingoScore = 0;
        bingoButt.onClick.AddListener(BINGO);
        bingoButt.enabled = false;
    }
    void OnDisable()
    {
        bingoButt.onClick.RemoveAllListeners();
    }

    public void CheckBingo()
    {
        int bingoX = 1,
            bingoY = 1,
            bingoDiag_R = 1, // Бинго по диагонали (справа налево)
            bingoDiag_L = 1, // Бинго по диагонали (слева направо)
            bingoFive = 1, // Бинго по 4 углам
            bingoX_All = 0, // Колл-во бинго по вертикали
            bingoY_All = 0; // Колл-во бинго по горизонтали

        if ((Main.valuePole[0] != -1) || (Main.valuePole[4] != -1) || (Main.valuePole[12] != -1) 
            || (Main.valuePole[20] != -1) || (Main.valuePole[24] != -1)) // Проверка по 4 углам
        {
            bingoFive = 0;
        }

        for (int i = 0; i < 5; i++)
        {
            if (Main.valuePole[i + i * 5] != -1) // Проверка по диагонали (Справа)
            {
                bingoDiag_R = 0;
            }
            if (Main.valuePole[4 - i + 5 * i] != -1) // Проверка по диагонали (Слева)
            {
                bingoDiag_L = 0;
            }

            bingoX = 1;
            bingoY = 1;
            for (int y = 0; y < 5; y++) //  Проверка по вертикали и горизонтали
            {
                if (Main.valuePole[i+y*5] != -1)
                {
                    bingoX = 0;
                }
                if (Main.valuePole[i*5 + y] != -1)
                {
                    bingoY = 0;
                }
            }
            bingoX_All += bingoX;
            bingoY_All += bingoY;
        }
        valueBingoScore = (bingoX_All + bingoY_All + bingoDiag_R + bingoDiag_L + bingoFive) * 500;

        if (valueBingoScore > 0)
        {
            bingoButt.enabled = true;
            bingoButt.image.color = Color.yellow;
        }
    }

    void BINGO()
    {
        if (Timer.valueTimer > 0)
        {
            scoreContr.valueScore += valueBingoScore;
            winObj.SetActive(true);
        }
    }
}
