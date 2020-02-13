using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ImagesManager))]
public class WManagers : MonoBehaviour
{
    public static ImagesManager Images { get; private set; }

    private List<WeatherIGameManager> _startSequece;

    private void Awake()
    {
        Images = GetComponent<ImagesManager>();

        _startSequece = new List<WeatherIGameManager>();
        _startSequece.Add(Images);

        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers()
    {
        NetworkService network = new NetworkService();

        foreach (WeatherIGameManager manager in _startSequece)
        {
            manager.StartUp(network);
        }

        yield return null;

        int numModules = _startSequece.Count;
        int numReady = 0;

        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;


            foreach (WeatherIGameManager manager in _startSequece)
            {
                if (manager.status == WeatherManagerStatus.Started)
                {
                    numReady++;
                }
                if (numReady > lastReady)
                {
                    print("Progress: " + numReady + "/" + numModules);
                    yield return null;
                }
            }
        }
        print("All weather managers started up");
    }
}
