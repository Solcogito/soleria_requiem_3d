using UnityEngine;
using UnityEngine.Tilemaps;

namespace Soleria.World
{
    public class TilemapGroundManager : MonoBehaviour
    {
        public GameTile groundTile;
        public int groundLength = 20;
        public int groundY = -2;

        private Tilemap tilemap;
        public TilemapInitializer tilemapInitializer;

        public void Initialize()
        { 
            GameObject initializerGO = new GameObject("TilemapInit");
            tilemapInitializer = initializerGO.AddComponent<TilemapInitializer>();

            InjectGroundManager(tilemapInitializer);
            tilemapInitializer.Initialize(this);
            tilemapInitializer.GenerateGroundLine();
        }

        private void InjectGroundManager(TilemapInitializer initializer)
        {
            if (initializer == null)
            {
                Debug.LogError("TilemapInitializer is null!");
                return;
            }
            initializer.groundManager = this;
            Debug.Log("Ground Manager injected into TilemapInitializer.");


        }
    }
}
