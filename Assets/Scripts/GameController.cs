using System;
using JetBrains.Annotations;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private CubesSpawner _cubesSpawner;
    [SerializeField] private RecolorController _recolorController;
    
    private void Awake()
    {
        _cubesSpawner.SpawnCubes();
        _cubesSpawner.OnCubesSpawned += _recolorController.Initialize;
    }

    [UsedImplicitly]
    public void StartRecoloring()
    {
        _recolorController.Recoloring();
    }

    private void OnDestroy()
    {
        _cubesSpawner.OnCubesSpawned -= _recolorController.Initialize; 
    }
}
