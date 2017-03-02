using System;
using System.Threading;
using System.Collections.Generic;

namespace Monte
{
	public class RandomAgent : MCTSMaster
	{
		public RandomAgent(){}

		protected override void mainAlgorithm(AIState initalState)
		{
			List<AIState> children = initalState.generateChildren();

			int index = randGen.Next(children.Count);
			next = children.Count > 0 ? children[index] : null;
			done = true;
		}

		protected override void rollout(AIState initalState){}
	}
}