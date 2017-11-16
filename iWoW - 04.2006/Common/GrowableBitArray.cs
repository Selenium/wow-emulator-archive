using System;
using System.Collections;
namespace WoWDaemon.Common
{
	/// <summary>
	/// Summary description for GrowableBitArray.
	/// </summary>
	public class GrowableBitArray
	{
		BitArray m_bitArray;
		int m_currentBits;
		int m_increment;
		public GrowableBitArray(int increment)
		{
			if((increment % 32) != 0)
				increment += 32-(increment%32);
			m_currentBits = increment;
			m_increment = increment;
			m_bitArray = new BitArray(increment);
		}

		public void SetBit(int index, bool value)
		{
			if(index >= m_currentBits)
			{
				m_currentBits = index+m_increment;
				if((m_currentBits % 32) != 0)
					m_currentBits += 32-(m_currentBits%32);
				BitArray tmp = new BitArray(m_currentBits);
				tmp.Or(m_bitArray);
				m_bitArray = tmp;
			}
			m_bitArray.Set(index, value);
		}

		public bool GetBit(int ndx)
		{
			if(ndx >= m_bitArray.Count)
				return false;
			return m_bitArray.Get(ndx);
		}

		public bool this[int index]
		{
			get { return GetBit(index);}
			set { SetBit(index, value);}
		}

		public int Count
		{
			get { return m_currentBits;}
		}
	}
}
