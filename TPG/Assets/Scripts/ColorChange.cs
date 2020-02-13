using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private void Operate()
    {
        iTween.ColorTo(gameObject, iTween.Hash("r", Random.Range(0f,1f), "g", Random.Range(0f, 1f), "b", Random.Range(0f, 1f), "time", 0.5f));
    }
}
