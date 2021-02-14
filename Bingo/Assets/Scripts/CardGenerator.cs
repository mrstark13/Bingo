using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGenerator : MonoBehaviour
{
    [SerializeField] private Text[] poleText; // Отображение ячеек поля
    List<int> poleFreeNumbers = new List<int>();

    public void Generate()
    {
        for (int i = 0; i < 100; i++)
        {
            poleFreeNumbers.Add(i);
            Main.unitFreeList.Add(new Main.unitFree());
        }

        for (int i = 0; i < 100; i++)
        {
            int rnd = Random.Range(0, poleFreeNumbers.Count);
            Main.valuePole[i] = poleFreeNumbers[rnd]; // Присваиваем полю рандомное свободное значение
            Main.unitFreeList[i].valueUnitNumber = poleFreeNumbers[rnd]; // Дублируем для листа свободных ячеек
            poleFreeNumbers.RemoveAt(rnd);

            if (i < poleText.Length)
            {
                poleText[i].text = Main.valuePole[i].ToString(); // Отображаем значения ячеек поля
            }

            Color newCol;
            switch (i % 5) // Определяем позицию ячейки поля на карточке
            {
                case 0:
                    if (ColorUtility.TryParseHtmlString("#5364FF", out newCol))
                        Main.unitFreeList[i].valueUnitColor = newCol;
                    Main.unitFreeList[i].valueUnitSymbol = "B";
                    break;
                case 1:
                    if (ColorUtility.TryParseHtmlString("#EA53FF", out newCol))
                        Main.unitFreeList[i].valueUnitColor = newCol;
                    Main.unitFreeList[i].valueUnitSymbol = "I";
                    break;
                case 2:
                    if (ColorUtility.TryParseHtmlString("#9953FF", out newCol))
                        Main.unitFreeList[i].valueUnitColor = newCol;
                    Main.unitFreeList[i].valueUnitSymbol = "N";
                    break;
                case 3:
                    if (ColorUtility.TryParseHtmlString("#53FF6F", out newCol))
                        Main.unitFreeList[i].valueUnitColor = newCol;
                    Main.unitFreeList[i].valueUnitSymbol = "G";
                    break;
                case 4:
                    if (ColorUtility.TryParseHtmlString("#FFF153", out newCol))
                        Main.unitFreeList[i].valueUnitColor = newCol;
                    Main.unitFreeList[i].valueUnitSymbol = "O";
                    break;
            }
        }
    }
}
