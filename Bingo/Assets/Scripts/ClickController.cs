using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickController : MonoBehaviour
{
    public BingoController bingoContr;
    public Main main;
    public Button poleButt; // Поле кнопка
    public int buttNumber; // Номер ячейки поля
    void Start()
    {
        poleButt = this.GetComponent<Button>();
        poleButt.onClick.AddListener(ButtonClick);

    }
    void OnDisable()
    {
        poleButt.onClick.RemoveAllListeners();
    }

    void ButtonClick()
    {
        if ((Timer.valueTimer > 0) && (Main.valuePole[buttNumber] != -1)) // Проверка ощего времени и было ли зачеркнуто поле
        {
            
            if (main.CheckNumber(buttNumber)) // Проверка совпадения ячейки поля с одной из выпавших ячеек
            {
                poleButt.image.color = Color.gray;
                bingoContr.CheckBingo();
                main.boostContr.valueBoostScore = 5;
            }
        }
        else
        {
            poleButt.onClick.RemoveAllListeners();
        }
    }
}
