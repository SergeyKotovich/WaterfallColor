using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _repaintingTime = 0.5f;
    [SerializeField] private MeshRenderer _meshRenderer;
    private Color _randomColor;
    private Color _currentColor;

    public void Initialize(Color randomColor)
    {
        _randomColor = randomColor;
        _currentColor = _meshRenderer.material.color;
        Recoloring();
    }

    private void Recoloring()
    {
        StartCoroutine(RecoloringCoroutine());
    }

    private IEnumerator RecoloringCoroutine()
    {
        var currentTime = 0f;
        while (currentTime<_repaintingTime)
        {
            var currentColor = Color.Lerp(_currentColor, _randomColor, currentTime / _repaintingTime);
            currentTime += Time.deltaTime;
            _meshRenderer.material.color = currentColor;
            yield return null;
        }
        
    }
}
