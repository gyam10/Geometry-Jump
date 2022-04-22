using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundscript : MonoBehaviour
{
    [SerializeField]
    private Vector2 parallaxEffectMultiplier;
    [SerializeField]
    private bool infiniteHorizontal;
    [SerializeField]
    private bool infiniteVertical;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitySizex;
    private float textureUnitySizey;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitySizex = texture.width / sprite.pixelsPerUnit;
        textureUnitySizey = texture.height / sprite.pixelsPerUnit;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;
        if (infiniteHorizontal)
        {
            if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitySizex)
            {
                float offsetPositionx = (cameraTransform.position.x - transform.position.x) % textureUnitySizex;
                transform.position = new Vector3(cameraTransform.position.x + offsetPositionx, transform.position.y);
            }
        }
        if (infiniteVertical)
        {
            if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitySizey)
            {
                float offsetPositiony = (cameraTransform.position.y - transform.position.y) % textureUnitySizey;
                transform.position = new Vector3(transform.position.x, cameraTransform.position.y + offsetPositiony);
            }
        }
    }
}
