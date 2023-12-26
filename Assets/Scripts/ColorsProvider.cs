using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class ColorsProvider
{
     public Color GetColor()
     {
          var color = Random.ColorHSV();
          return color;
     }
}
