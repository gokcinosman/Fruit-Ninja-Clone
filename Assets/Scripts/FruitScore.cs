using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFruitScore
{
    int AddScore(int score);
    int GetScore();
    void ResetScore();

}
