using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostController : MonoBehaviour
{
    public Button boostButt;
    public Text boostScoreText;
    static int boostScore;
    static int boostScoreMult; // Множитель очков

    public int valueBoostScore
    {
        get { return boostScore; }
        set
        {
            boostScore += value * valueBoostScoreMult;
            if (boostScore >= 100)
            {
                boostButt.enabled = true;
                boostButt.image.color = Color.green;
                boostScore = 0;
            }
            boostScoreText.text = boostScore.ToString();
        }
    }
    public int valueBoostScoreMult
    {
        get { return boostScoreMult; }
        set
        {
            boostScoreMult = value;
        }
    }

    static float timeBoostMult;
    public float valueTimeBoostMult
    {
        get { return timeBoostMult; }
        set
        {
            timeBoostMult = value;
        }
    }
    void Start()
    {
        boostButt.onClick.AddListener(BoostTimer);
    }

    void Update()
    {
        if (valueTimeBoostMult > 0)
        {
            valueTimeBoostMult -= Time.deltaTime;
        }
        else
        {
            valueBoostScoreMult = 1;
        }
    }

    void OnDisable()
    {
        boostButt.onClick.RemoveAllListeners();
    }

    void BoostTimer()
    {
        Timer.valueTimer += 30;
        boostButt.enabled = false;
        boostButt.image.color = Color.white;
    }
}
