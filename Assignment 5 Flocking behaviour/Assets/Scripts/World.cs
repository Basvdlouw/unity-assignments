using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class World : MonoBehaviour
{

    public float bound = 100;
    public Transform agentPrefab;

    public int nAgents;

    public List<Agent> agents;


    void Start()
    {
        agents = new List<Agent>();
        spawn(agentPrefab, nAgents);
        agents.AddRange(FindObjectsOfType<Agent>());
    }


    void spawn(Transform prefab, int n)
    {

        for (int i = 0; i < n; i++)
        {
            Instantiate(prefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
        }
    }

    public List<Predator> GetPredatorsInRadius(Vector3 agentPosition, float distance) {
        GameObject[] predators = GameObject.FindGameObjectsWithTag("Predator");
        List<Predator> predatorsInRadius = new List<Predator>();
        foreach(GameObject predator in predators) {
            if(Vector3.Distance(agentPosition, predator.transform.position) <= distance) {
                predatorsInRadius.Add(predator.GetComponent<Predator>());
            }
        }
        return predatorsInRadius;
    }
    public List<Agent> GetNeigh(Agent agent, float radius)
    {
        // neighbours of agent inside radiu
        List<Agent> r = new List<Agent>();
        foreach (var otherAgent in agents)
        {
            if (otherAgent == agent)
            {
                continue;
            }
            if (Vector3.Distance(agent.x, otherAgent.x) <= radius)
            {
                r.Add(otherAgent);
            }
        }
        return r;
    }
}
