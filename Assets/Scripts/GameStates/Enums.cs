﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Action  {

	MSG_MOUSE_DOWN_IMAGE,
	MSG_MOUSE_UP_IMAGE,
	MSG_DRAG_BEGIN_IMAGE,
	MSG_DRAGGING_IMAGE,
	MSG_DRAG_END_IMAGE,
	MSG_MOUSE_LEAVES_IMAGE,
	MSG_MOUSE_DOWN_TABLE,
	MSG_MOUSE_UP_TABLE,
	MSG_MOUSE_IMAGE_SLIDER_EVENT,
	MSG_MOUSE_TABLE_EVENT,
	MSG_MOUSE_CANVAS_DOWN,
	MSG_MOUSE_CANVAS_STAY,
	MSG_MOUSE_CANVAS_UP,
	MSG_MOUSE_CUE_BALL_CANVAS_UP,
	MSG_MOUSE_CUE_BALL_CANVAS_DOWN,
	MSG_MOUSE_INSIDE_REGION,
	MSG_MOUSE_OUTSIDE_REGION,
	MSG_MOUSE_DOWN_CANVAS,
	MSG_MOUSE_UP_CANVAS,
	NONE
}