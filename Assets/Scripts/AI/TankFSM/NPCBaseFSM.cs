﻿using UnityEngine;

public class NPCBaseFSM : StateMachineBehaviour {
  
  public GameObject NPC;
  public UnityEngine.AI.NavMeshAgent agent;
  public GameObject opponent;
  public float accuracy = 3.0f;

  public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
  {
     NPC = animator.gameObject;
     opponent = NPC.GetComponent<TankAI>().FindClosestPlayer();
     agent = NPC.GetComponent<UnityEngine.AI.NavMeshAgent>();
  }
}
