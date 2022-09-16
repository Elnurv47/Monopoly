using System;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private Land[] _lands;

    private void Start()
    {
        for (int i = 0; i < _lands.Length - 1; i++)
        {
            Land land = _lands[i];
            land.NextLand = _lands[i + 1];
            land.Index = i;
        }

        _lands[_lands.Length - 1].NextLand = _lands[0];
    }

    public Land GetLandAt(int index)
    {
        return _lands[index];
    }
}
