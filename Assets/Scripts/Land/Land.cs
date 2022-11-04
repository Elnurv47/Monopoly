using System.Collections.Generic;
using UnityEngine;

public abstract class Land : MonoBehaviour
{
    public Vector3 Position { get => transform.position; }

    private Land _nextLand;
    public Land NextLand { get => _nextLand; set => _nextLand = value; }

    private int _index;
    public int Index { get => _index; set => _index = value; }

    private Player _owner;
    public Player Owner { get => _owner; set => _owner = value; }

    public virtual void InvokeOnLanded(Player landedPlayer)
    {
        Debug.Log(landedPlayer.name + " landed on Land" + _index);
    }
}
