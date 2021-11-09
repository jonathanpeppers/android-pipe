package com.microsoft.android.pipe;

import java.lang.*;
import android.widget.*;

public class DotNetPipe {
	public static int TEXTVIEW_TEXT = 1;

	public static void Send (Object[] message) {
		for (int i = 0; i < message.length; i += 3) {
			if ((int)message[i] == TEXTVIEW_TEXT) {
				((TextView)message[i + 1]).setText((String)message[i + 2]);
			}
		}
	}
}