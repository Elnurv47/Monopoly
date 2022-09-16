using UnityEngine;

public class Land : MonoBehaviour
{
    public Vector3 Position { get => transform.position; }

    private Land _nextLand;
    public Land NextLand { get => _nextLand; set => _nextLand = value; }

    private int _index;
    public int Index { get => _index; set => _index = value; }
}
