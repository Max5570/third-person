using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WeatherIGameManager
{
        WeatherManagerStatus status { get; }

    void StartUp(NetworkService service);

}
