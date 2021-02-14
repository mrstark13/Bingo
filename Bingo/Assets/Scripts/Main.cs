using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public CardGenerator cardGen;
    public LotoController lotoContr;
    public ScoreController scoreContr;
    public BoostController boostContr;

    private static int[] pole = new int[100]; //Карточное поле (значения)

    public class unitFree //Ячейки и их параметры
    {
        private Color unitColor;
        private string unitSymbol;
        private int unitNumber;

        public Color valueUnitColor
        {
            get { return unitColor; }
            set
            {
                unitColor = value;
            }
        }
        public string valueUnitSymbol
        {
            get { return unitSymbol; }
            set
            {
                unitSymbol = value;
            }
        }
        public int valueUnitNumber
        {
            get { return unitNumber; }
            set
            {
                unitNumber = value;
            }
        }
    }
    public static List<unitFree> unitFreeList = new List<unitFree>(); //Лист не использованных ячеек

    public static int[] valuePole
    {
        get { return pole; }
        set
        {
            pole = value;
        }
    }

    void Start()
    {
        unitFreeList.Clear();
        cardGen.Generate();
    }

    public bool CheckNumber(int n) // Проверка нажатого поля на совпадение с выпавшими ячейками
    {
        for (int i = 4; i >= 0; i--)
        {
            if (valuePole[n] == lotoContr.unit[i].unitNumber)
            {
                if (i == 4) // Совпадение с последней выпавшей
                {
                    scoreContr.valueScore += 200;
                    boostContr.valueBoostScoreMult += 1;
                    boostContr.valueTimeBoostMult = 4;
                } else // Совпадение с остальными
                {
                    scoreContr.valueScore += 100;
                    boostContr.valueBoostScoreMult = 1;
                }
                valuePole[n] = -1;
                return true;
            } else if (i == 0) // Совпадений не было
            {
                scoreContr.valueScore -= 100;
                boostContr.valueBoostScoreMult = 1;
                return false;
            }
        }
        return false;
    }
}
