using UnityEngine;

public class SpriteSwitcher : MonoBehaviour
{
    public Transform mainCharacter;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;

    public float distanceFromMain = 4f;


    void Update()
    {
        if (mainCharacter == null || spriteRenderer == null)
        {
            Debug.LogWarning("Main character or SpriteRenderer not assigned to SpriteSwitcher!");
            return;
        }

        float distance = mainCharacter.position.x - transform.position.x;

        if (distance > 0)
        {
            if (distance > 4) { SetSprite(sprite1);}
            else { SetSprite(sprite2); }
            
        }
        else if (distance < 0)
        {
            if (distance < -4) { SetMirroredSprite(sprite2); }
            else { SetMirroredSprite(sprite1); }
        }

    }

    void SetSprite(Sprite sprite)
    {
        // Set the sprite on the single SpriteRenderer
        spriteRenderer.sprite = sprite;
    }

    void SetMirroredSprite(Sprite original)
    {
        // Set the mirrored version of the sprite on the single SpriteRenderer
        spriteRenderer.sprite = MirroredSprite(original);
    }

    Sprite MirroredSprite(Sprite original)
    {
        // Create a mirrored version of the sprite
        Texture2D tex = new Texture2D(original.texture.width, original.texture.height, original.texture.format, false);
        Color[] pixels = original.texture.GetPixels();

        // Mirror the pixels horizontally
        for (int y = 0; y < original.texture.height; y++)
        {
            for (int x = 0; x < original.texture.width / 2; x++)
            {
                int mirrorX = original.texture.width - x - 1;
                Color temp = pixels[y * original.texture.width + x];
                pixels[y * original.texture.width + x] = pixels[y * original.texture.width + mirrorX];
                pixels[y * original.texture.width + mirrorX] = temp;
            }
        }

        tex.SetPixels(pixels);
        tex.Apply();

        Sprite mirroredSprite = Sprite.Create(tex, original.rect, new Vector2(0.5f, 0.5f), original.pixelsPerUnit);
        return mirroredSprite;
    }
}