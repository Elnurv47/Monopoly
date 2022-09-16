using UnityEngine;

public class Player : Character
{
    public int LandIndex { get => _land.Index; }

    private Land _land;
    public Land Land { get => _land; set => _land = value; }

    [SerializeField] private int _index;
}
