using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSurrounding:MonoBehaviour
{
    public SpriteRenderer LevelLayout;
    public Color Land;
    public Color Water;
    public Color WaterDeep;
    public Color WaterOcean;
    public float SizeMlt;
    public SpriteMask WaterMask;
    public Sprite WaterSprite;
    public Sprite DeepSprite;
    public Sprite OceanSprite;

    public Surrounding Current { get { return _current; } }

    private Surrounding _current;

    public bool CheckSurrounding() {
        Texture2D t = LevelLayout.sprite.texture;
        var pos = new Vector2Int((int)(transform.position.x * SizeMlt), (int)((transform.position.y + 0.1) * SizeMlt));
        var color = t.GetPixel(pos.x, pos.y);
        Debug.Log("Position: " + pos.x + " " + pos.y + " color: " + (
            color == Land ? "Land" :
            color == Water ? "Water" :
            color == WaterDeep ? "WaterDeep" :
            color == WaterOcean ? "WaterOcean" :
            "Unknown")
            );
        Surrounding result;
        if( color == Land ) {
            result = Surrounding.Land;
        } else if( color == Water ) {
            result = Surrounding.Water;
        } else if( color == WaterDeep ) {
            result = Surrounding.WaterDeep;
        } else if( color == WaterOcean ) {
            result = Surrounding.WaterOcean;
        } else {
            result = Surrounding.Unknown;
        }
        if( result == _current ) {
            return false;
        } else {
            _current = result;
            UpdateSprite();
            return true;
        }
    }

    public void UpdateSprite() {
        switch( _current ) {
        case Surrounding.Land:
            WaterMask.sprite = null;
            break;
        case Surrounding.Water:
            WaterMask.sprite = WaterSprite;
            break;
        case Surrounding.WaterDeep:
            WaterMask.sprite = DeepSprite;
            break;
        case Surrounding.WaterOcean:
            WaterMask.sprite = OceanSprite;
            break;
       
        default:
            break;
        }
    }
}
public enum Surrounding
{
    Land, Water, WaterDeep, WaterOcean, Unknown
}
