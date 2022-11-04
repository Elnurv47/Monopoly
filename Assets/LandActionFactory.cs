using UnityEngine;

public class LandActionFactory : MonoBehaviour
{
    public static LandActionFactory Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private PropertyLandAction _propertyLandAction;

    public PropertyLandAction GetPropertyLandAction()
    {
        return _propertyLandAction;
    }
}
