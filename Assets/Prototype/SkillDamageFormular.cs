using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDamageFormular : MonoBehaviour
{
    public class PlayerSprite
    {
        public Dictionary<int, Sprite> _sprites = new Dictionary<int, Sprite>();

        public Sprite Get(int i)
        {
            int index = i - 1;
            if (!_sprites.ContainsKey(index))
            {
                string path = $"Image/Sprite/Characters/character ({index})";
                Sprite sprite = Resources.Load<Sprite>(path);
                if (sprite == null)
                    Debug.LogError($"No sprite from: {path}");
                _sprites[index] = sprite;
            }
            return _sprites[index];
        }
    }
    public readonly static PlayerSprite playerSprite = new PlayerSprite();
}
