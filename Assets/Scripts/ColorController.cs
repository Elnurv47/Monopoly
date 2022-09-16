using UnityEngine;

public class ColorController : MonoBehaviour
{
    private Renderer _renderer;

    [SerializeField] private Color _color;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = _color;
    }
}
