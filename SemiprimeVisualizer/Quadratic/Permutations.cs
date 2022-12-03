using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SemiprimeVisualizer
{
	public class PermutationSet
	{
		private bool iterationComplete;
		private List<Element> Elements;
		private IEnumerable<int[]> cache;

		public PermutationSet(List<List<int>> permutationArrayList)
		{
			cache = null;
			iterationComplete = false;
			Elements = new List<Element>();
			List<List<int>> unitList = permutationArrayList;
			unitList.Reverse();

			Element temp = null;
			Element lastUnit = null;
			foreach (List<int> unit in unitList)
			{
				temp = null;
				// If first value
				if (Elements.Count < 1 && lastUnit == null)
				{
					temp = new Element(unit, () => iterationComplete = true);
					Elements.Add(temp);
					lastUnit = temp;
				}
				else
				{
					temp = new Element(unit, lastUnit.Permute);
					Elements.Insert(0, temp);
					lastUnit = temp;
				}
			}
		}

		public IEnumerable<int[]> GetPermutations()
		{
			if (cache == null)
			{
				cache = getPermutedEnumerable();
			}
			return cache;
		}

		private IEnumerable<int[]> getPermutedEnumerable()
		{
			if (Elements != null && Elements.Count > 0)
			{
				Reset();
				yield return Elements.Select(pu => pu.CurrentValue).ToArray();

				while (!iterationComplete)
				{
					this.Increment();
					yield return Elements.Select(pu => pu.CurrentValue).ToArray();
				}
			}
			yield break;
		}

		private void Reset()
		{
			if (iterationComplete)
			{
				if (Elements != null && Elements.Count > 0)
				{
					Elements.ForEach(u => u.Reset());
				}
				cache = null;
				iterationComplete = false;				
			}			
		}

		private void Increment()
		{
			if (Elements != null && Elements.Count > 0 && !iterationComplete)
			{
				Elements.First().Permute();
			}
		}

		public override string ToString()
		{
			return (Elements == null || Elements.Count < 1) ? string.Empty : string.Join(" ", Elements.Select(pu => pu.ToString()));			
		}
	}

	internal class Element
    {
		public int CurrentValue { get { return states[currentIndex]; } }

		private List<int> states;
		private Action rolloverAction;
		private int currentIndex;
		private int maximumIndex;
		
		public Element(List<int> arrayOfPossibleStates, Action onRolloverAction)
		{
			this.currentIndex = 0;			
			this.states = arrayOfPossibleStates;
			this.rolloverAction = onRolloverAction;
			this.maximumIndex = states.Count;
		}

		public void Permute()
		{
			if (currentIndex == maximumIndex-1)
			{
				currentIndex = 0;
				rolloverAction.Invoke();
			}
			else
			{
				currentIndex++;
			}
		}

		public void Reset()
		{
			currentIndex = 0;
		}

		public override string ToString()
		{
			return CurrentValue.ToString();
		}
    }
}
