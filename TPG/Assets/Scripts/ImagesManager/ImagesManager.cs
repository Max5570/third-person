using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagesManager : MonoBehaviour, WeatherIGameManager
{
    public WeatherManagerStatus status { get; private set; }

    private NetworkService _network;
    private Texture2D _webImage;

    [Obsolete]
    public void StartUp(NetworkService service)
    {
        print("Images manager starting...");

        _network = service;
        status = WeatherManagerStatus.Started;
    }
    public void GetWebImage(Action<Texture2D> callback)
    {
        if (_webImage == null)
        {
            StartCoroutine(_network.DownloadImage((Texture2D image) =>
            {
                _webImage = image;
                callback(_webImage);
            }));
        }
        else
        {
            callback(_webImage);
        }
    }
}