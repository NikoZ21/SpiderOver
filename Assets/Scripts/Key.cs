using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    [SerializeField] Image keyImage;
    CapsuleCollider2D capsuleCollider;

    private void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if (capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            keyImage.color = Color.white;
            Destroy(gameObject);
        }
    }
}