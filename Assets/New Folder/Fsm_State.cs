using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum FSM_PLAYER_STATE
{
	DIE,
	IDLE,
	MOVE,
	REVIVE
}
public enum FSM_UI_STATE
{
	MAIN,
	OPTION,
	SHOP,
	SELECT_USER
}

public enum FSM_GAME_STATE
{
	START,
	PLAY,
	OPTION,
	SELEC_REWARD
}

public enum FSM_PLAYER_EQUIP
{
	RIFLE,
	HANDGUN,
	GRENADE,
	HAND,
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