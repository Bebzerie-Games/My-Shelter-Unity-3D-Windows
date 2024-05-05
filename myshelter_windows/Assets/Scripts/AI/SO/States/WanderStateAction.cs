using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

namespace MyShelterWin64.AI {
    [CreateAssetMenu(menuName = "My Shelter/AI States/New Wander State")]
    public class WanderStateAction : AIState {

        Vector3 _walkpoint = Vector3.zero;
        public override bool OnStateEnter(NPC npc) {
            return base.OnStateEnter(npc);
        }

        public override bool OnStateExecuting(NPC npc) {

            if (!npc.Agent.hasPath) {
                npc.Agent.SetDestination(GetRandomPoint(npc, npc.Agent.transform, radius:20));
            }

            return true;
        }

        public override bool OnStateExit(NPC npc) {
            return base.OnStateExit(npc);
        }
        
        bool RandomPoint(Vector3 center, float range, out Vector3 result) {
            for (int i = 0; i < 30; i++) {
                Vector3 randomPoint = center + Random.insideUnitSphere * range;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) {
                    result = hit.position;
                    return true;
                }
            }

            result = Vector3.zero;

            return false;
        }

        Vector3 GetRandomPoint(NPC npc, Transform point = null, float radius = 0) {
            Vector3 _point;

            if (RandomPoint(point == null ? npc.Agent.transform.position : point.position, radius == 0 ? 20 : radius, out _point)) {
                return _point;
            }

            return point == null ? Vector3.zero : point.position;
        }
    }
}