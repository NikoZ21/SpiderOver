using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    //serialized variables
    [SerializeField] Image keyImage;

    //cached variables
    private CapsuleCollider2D _capsuleCollider;


    private void Start()
    {
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        PickUpKey();
    }

    private void PickUpKey()
    {
        if (_capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            keyImage.color = Color.white;
            Destroy(gameObject);
        }
    }
}