using MagicianTrainee.Spells;
using UnityEngine;

public class DummyBehaviour : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] public Rigidbody[] _rigidbodies;

    private bool isChanged;
    private static readonly int Color1 = Shader.PropertyToID("_Color");
    private Color _standartColor;

    private void Awake()
    {
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = true;
        }
        _standartColor = _skinnedMeshRenderer.material.GetColor(Shader.PropertyToID("_Color"));
    }

    public void SetSphereController(BasicSpellController sphereController)
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeColorOfDummy();
        }
    }

    private void ChangeColorOfDummy()
    {
        if (!isChanged)
        {
            isChanged = true;
            _skinnedMeshRenderer.material.SetColor(Color1, Color.green);
            return;
        }
        _skinnedMeshRenderer.material.color = _standartColor;
        isChanged = false;
    }

    public void MakePhysical()
    {
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = false;
        }
    }
}
