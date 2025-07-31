using UnityEngine;
using UnityEngine.Tilemaps;

namespace Soleria.World
{
    public class TilemapInitializer : MonoBehaviour
    {
        public TilemapGroundManager groundManager;
        private Tilemap tilemap;

        public void Initialize(TilemapGroundManager groundManager)
        {
            this.groundManager = groundManager;

            // Create Grid
            GameObject gridGO = new GameObject("Grid");
            gridGO.transform.position = new Vector3(0f, -5f, 0f);
            Grid grid = gridGO.AddComponent<Grid>();
            grid.cellSize = new Vector3(1, 1, 0);

            // Create Tilemap as child
            GameObject tilemapGO = new GameObject("GroundTilemap");
            tilemapGO.transform.SetParent(gridGO.transform);
            tilemapGO.transform.localPosition = Vector3.zero;

            tilemap = tilemapGO.AddComponent<Tilemap>();
            TilemapRenderer renderer = tilemapGO.AddComponent<TilemapRenderer>();
            renderer.sortOrder = TilemapRenderer.SortOrder.TopLeft;

            TilemapCollider2D collider = tilemapGO.AddComponent<TilemapCollider2D>();
            CompositeCollider2D composite = tilemapGO.AddComponent<CompositeCollider2D>();
            Rigidbody2D rb = tilemapGO.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;
            collider.compositeOperation = Collider2D.CompositeOperation.Merge;

            GenerateGroundLine();
        }

        public void GenerateGroundLine()
        {
            for (int x = -groundManager.groundLength / 2; x < groundManager.groundLength / 2; x++)
            {
                tilemap.SetTile(new Vector3Int(x, groundManager.groundY, 0), groundManager.groundTile);
            }

            Debug.Log("Ground line generated.");
        }
    }
}
