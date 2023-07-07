using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public static DataBase Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public static PlayerData[] player_lists;

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

    public class EnemySprite
    {
        public Dictionary<int, Sprite> _sprites = new Dictionary<int, Sprite>();

        public Sprite Get(int i)
        {
            int index = i - 1;
            if (!_sprites.ContainsKey(index))
            {
                string path = $"Image/Sprite/Enemies/enemy ({index})";
                Sprite sprite = Resources.Load<Sprite>(path);
                if (sprite == null)
                    Debug.LogError($"No sprite from: {path}");
                _sprites[index] = sprite;
            }
            return _sprites[index];
        }
    }
    public readonly static EnemySprite enemySprite = new EnemySprite();
}
