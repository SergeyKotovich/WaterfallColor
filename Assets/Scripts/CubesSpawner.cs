using System;
using System.Collections;
using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private float _delayBetweenSpawn = 0.04f;
    [SerializeField] private Grid _grid;
    public Action<Cube[,]> OnCubesSpawned;

    private int _sideSize = 20;
    private Cube[,] _arrayCubes;
    public void SpawnCubes()
    {
        StartCoroutine(SpawnCubesCoroutine());
    }

    private IEnumerator SpawnCubesCoroutine()
    {
        _arrayCubes = new Cube[_sideSize, _sideSize];
        for (var i = 0; i < _arrayCubes.GetLength(0); i++)
        {
            for (var j = 0; j < _arrayCubes.GetLength(1); j++)
            {
                var cube = Instantiate(_cubePrefab);
                cube.transform.position = _grid.CellToWorld(new Vector3Int(j,-i,0));
                _arrayCubes[i, j] = cube;
                OnCubesSpawned?.Invoke(_arrayCubes);
                yield return new WaitForSeconds(_delayBetweenSpawn);
            }
        }
    }
}
