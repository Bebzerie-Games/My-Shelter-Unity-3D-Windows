using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

namespace MyShelterWin64.AI {
    [CreateAssetMenu(menuName = "My Shelter/AI States/New Wander State")]
    public class WanderStateAction : AIState {

        public override bool OnStateEnter(NPC npc) {
            return base.OnStateEnter(npc);
        }

        public override bool OnStateExecuting(NPC npc) {
            if (!npc.Agent.hasPath) {
                return npc.AgentSetDestination(GetRandomPoint(npc, npc.Agent.transform, radius: 50));
            }

            return false;
        }

        public void UpdateWander(NPC npc) {
           if (npc.Agent.hasPath) {
                npc.Agent.ResetPath();
           }
        }

        public override bool OnStateExit(NPC npc) {
            UpdateWander(npc);
            return base.OnStateExit(npc);
        }
        
        bool RandomPoint(Vector3 center, float range, out Vector3 result) {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;

            if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, 1.0f, NavMesh.AllAreas)) {
                result = hit.position;
                return true;
            }

            result = Vector3.zero;

            return false;
        }

        Vector3 GetRandomPoint(NPC npc, Transform point = null, float radius = 0) {

            if (RandomPoint(point == null ? npc.Agent.transform.position : point.position, radius == 0 ? 50 : radius, out Vector3 _point)) {
                return _point;
            }

            return point == null ? Vector3.zero : point.position;
        }
    }
}