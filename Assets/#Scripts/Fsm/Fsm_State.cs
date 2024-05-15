using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public enum FSM_GAME_STATE
{
	START,
	READY,
	OPTION,
	RESULT
}



[System.Serializable]
public abstract class FsmState<TFsm_Type>
{


	private TFsm_Type m_stateType;


	public FsmState(TFsm_Type _stateIdx)
	{
		m_stateType = _stateIdx;
	}

	public TFsm_Type getStateType
	{
		get
		{
			return m_stateType;
		}
	}

	#region - virtaul 
	public virtual void Enter()
	{

	}
	public virtual void Loop()
	{

	}
	public virtual void End()
	{

	}

	#endregion
}