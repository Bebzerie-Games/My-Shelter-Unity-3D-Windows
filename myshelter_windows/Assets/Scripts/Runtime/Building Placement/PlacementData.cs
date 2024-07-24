using System.Collections.Generic;
using UnityEngine;

namespace MyShelterWin64.Game {
    public class PlacementData {
        public HashSet<Vector3Int> ReservedPositions;

        public int ID {
            get; private set;
        }

        public int PlacedObjectIndex {
            get; private set;
        }
        public PlacementData(HashSet<Vector3Int> reservedPositions, int id, int placedObjectIndex) {
            ReservedPositions = reservedPositions;
            ID = id;
            PlacedObjectIndex = placedObjectIndex;
        }
    }
}