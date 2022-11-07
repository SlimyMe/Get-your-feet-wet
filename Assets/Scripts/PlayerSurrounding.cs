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

    private Player _player {
        get {
            if( _p == null ) {
                _p = GetComponent<PlayerController>().Player;
                _p.RegisterSurroundingChange(UpdateSprite);
            }
            return _p;
        }
    }
    private Player _p;

    public void CheckSurrounding() {
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
        if( color == Land ) {
            _player.Surrounding = Surrounding.Land;
        } else if( color == Water ) {
            _player.Surrounding = Surrounding.Water;
        } else if( color == WaterDeep ) {
            _player.Surrounding = Surrounding.WaterDeep;
        } else if( color == WaterOcean ) {
            _player.Surrounding = Surrounding.WaterOcean;
        } else {
            _player.Surrounding = Surrounding.Unknown;
        }
    }

    public void UpdateSprite(Surrounding surr) {
        switch( surr ) {
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
