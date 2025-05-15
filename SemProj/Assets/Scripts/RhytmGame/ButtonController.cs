using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ButtonController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Sprite defaultSprite;
    [SerializeField] private Sprite pressedSprite;

    [SerializeField] private KeyCode keyToPress;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        defaultSprite = _spriteRenderer.sprite;
    }

    private void Update()
    {
        OnKeyPressed();
    }

    private void OnKeyPressed()
    {
        if (pressedSprite != null)
        {
            if (Input.GetKeyDown(keyToPress))
            {
                _spriteRenderer.sprite = pressedSprite;
            }
            if (Input.GetKeyUp(keyToPress))
            {
                _spriteRenderer.sprite = defaultSprite;
            }
        }
    }
}
