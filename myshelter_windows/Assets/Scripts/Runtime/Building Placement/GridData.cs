using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyShelterWin64.Game {
    public class GridData {
        readonly Dictionary<Vector3Int, PlacementData> PlacedObjects = new();

        public void AddObjectAt(Vector3Int gridPosition,
                            Vector2Int objectSize,
                            int ID,
                            int placedObjectIndex) {
            HashSet<Vector3Int> positionToOccupy = CalculatePositions(gridPosition, objectSize);
            PlacementData data = new PlacementData(positionToOccupy, ID, placedObjectIndex);
            foreach (var pos in positionToOccupy) {
                if (!PlacedObjects.TryGetValue(pos, out _)) {
                    PlacedObjects[pos] = data;
                }
            }
        }

        private HashSet<Vector3Int> CalculatePositions(Vector3Int gridPosition, Vector2Int objectSize) {
            HashSet<Vector3Int> returnVal = new();

            for (int x = 0; x < objectSize.x; x++) {
                for (int y = 0; y < objectSize.y; y++) {
                    returnVal.Add(gridPosition + new Vector3Int(x, 0, y));
                }
            }
            return returnVal;
        }

        public bool CanPlaceObjectAt(Vector3Int gridPosition, Vector2Int objectSize) {
            HashSet<Vector3Int> positionToOccupy = CalculatePositions(gridPosition, objectSize);

            foreach (var pos in positionToOccupy) {
                if (PlacedObjects.TryGetValue(pos, out _))
                    return false;
            }
            return true;
        }
    }
}