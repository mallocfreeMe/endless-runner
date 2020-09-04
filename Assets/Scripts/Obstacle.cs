using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour, IRecycle
{
    public Sprite[] sprites;
    public Vector2 collideOffset = Vector2.zero;
    
    public void Restart()
    {
        var renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[Random.Range(0, sprites.Length)];

        var collider = GetComponent<BoxCollider2D>();
        var size = renderer.bounds.size;
        size.y += collideOffset.y;

        collider.size = size;
        collider.offset = new Vector2(-collideOffset.x, collider.size.y / 2- collideOffset.y);

    }

    public void Shutdonw()
    {
        
    }
}