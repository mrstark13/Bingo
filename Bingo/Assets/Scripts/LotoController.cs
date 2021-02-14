using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LotoController : MonoBehaviour
{
    public Text timeToDouble;
    [Serializable]
    public class Unit // Ячейка и её параметры
    {
        public Image unitImage;
        public int unitNumber;
        public Text unitSymbol;
        public Text unitNumberText;
    }
     [SerializeField] public Unit[] unit; // Массив ячеек


    float t = 3; // Таймер генерации
    void Update()
    {
        if (Timer.valueTimer > 0) // Проверка общего времени
        {
            LotoGenerator();
        }
        else
        {
            this.enabled = false;
        }
    }

    void LotoGenerator()
    {
        if (t <= 0) // Проверка таймера генерации
        {
            int unitListCount = Main.unitFreeList.Count;
            if (unitListCount > 0) // Проверка есть ли невыпавшие ячейки
            {
                int rnd = UnityEngine.Random.Range(0, unitListCount);
                for (int i = 0; i < 4; i++) // Сдвиг ячеек
                {
                    unit[i].unitImage.color = unit[i + 1].unitImage.color;
                    unit[i].unitNumber = unit[i + 1].unitNumber;
                    unit[i].unitSymbol.text = unit[i + 1].unitSymbol.text;
                    unit[i].unitNumberText.text = unit[i + 1].unitNumberText.text;
                }
                // Генерация новой ячейки
                unit[4].unitImage.color = Main.unitFreeList[rnd].valueUnitColor;
                unit[4].unitNumber = Main.unitFreeList[rnd].valueUnitNumber;
                unit[4].unitSymbol.text = Main.unitFreeList[rnd].valueUnitSymbol;
                unit[4].unitNumberText.text = unit[4].unitNumber.ToString();

                Main.unitFreeList.RemoveAt(rnd); // Удаляем выпавшую ячейку из свободных
            }
            t = 2; // Обновляем таймер генерации
        }
        else // Обновляем и выводим таймер генерации
        {
            t -= Time.deltaTime;
            timeToDouble.text = Math.Round(t, 1).ToString();
        }
    }
}
