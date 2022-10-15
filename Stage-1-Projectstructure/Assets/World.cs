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

    void Update()
    {

    }

    void spawn(Transform prefab, int n)
    {

        for (int i = 0; i < n; i++)
        {
            Instantiate(prefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
        }
    }

    public List<Agent> getNeigh(Agent agent, float radius)
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
