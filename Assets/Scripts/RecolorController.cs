using System.Collections;
using UnityEngine;

public class RecolorController : MonoBehaviour
{
   [SerializeField] private float _delayBetweenRepainting = 0.2f;
   [SerializeField] private ColorsProvider _colorsProvider;
   
   private Cube[,] _arrayCubes;
   public void Initialize(Cube[,] arrayCubes)
   {
      _arrayCubes = arrayCubes;
   }

   public void Recoloring()
   {
      StartCoroutine(RecoloringCoroutine());
   }

   private IEnumerator RecoloringCoroutine()
   {
      var randomColor = _colorsProvider.GetColor();
      for (var i = 0; i < _arrayCubes.GetLength(0); i++)
      {
         for (var j = 0; j < _arrayCubes.GetLength(1); j++)
         {
            _arrayCubes[i,j].Initialize(randomColor);
            yield return new WaitForSeconds(_delayBetweenRepainting);
         }
      }
   }
   
}
