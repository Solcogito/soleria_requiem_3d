using UnityEngine;
using UnityEngine.Tilemaps;

namespace Soleria.World 
{ 
    
    [CreateAssetMenu(fileName = "NewGameTile", menuName = "Tiles/GameTile")]
    
    public class GameTile : Tile
    {
        [SerializeField] private bool isWalkable = true;
        [SerializeField] private int movementCost = 1;

        public bool IsWalkable => isWalkable;
        public int MovementCost => movementCost;
    }
}
