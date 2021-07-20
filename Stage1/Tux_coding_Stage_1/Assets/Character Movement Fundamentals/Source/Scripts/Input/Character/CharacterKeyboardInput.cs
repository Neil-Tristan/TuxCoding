﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMF
{
	//This character movement input class is an example of how to get input from a keyboard to control the character;
    public class CharacterKeyboardInput : CharacterInput
    {
		public string horizontalInputAxis = "Horizontal";
		public string verticalInputAxis = "Vertical";
		public KeyCode jumpKey = KeyCode.Space;
		public FixedButton Button;
		public FixedJoystick rightJoyStick;

		//If this is enabled, Unity's internal input smoothing is bypassed;
		public bool useRawInput = true;

        public override float GetHorizontalMovementInput()
		{
			if(useRawInput)
				return rightJoyStick.Direction.x;
			else
				return rightJoyStick.Direction.x;
		}

		public override float GetVerticalMovementInput()
		{
			if(useRawInput)
				return rightJoyStick.Direction.y;
			else
				return rightJoyStick.Direction.y;
		}

		public override bool IsJumpKeyPressed()
		{
			return Button.Pressed;
		}

		
    }
}
