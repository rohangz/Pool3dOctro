using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class DragEnded : EventArgs
{
	public bool value = false;
	public Action action;
	public DragEnded(bool v,Action action)
	{
		value = v;
		this.action = action;
	}
}




