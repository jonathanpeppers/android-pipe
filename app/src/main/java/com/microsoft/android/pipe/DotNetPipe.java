package com.microsoft.android.pipe;

import java.lang.*;

import android.graphics.Typeface;
import android.widget.*;

public class DotNetPipe {
	public final static int TEXTVIEW_TEXT = 1;
	public final static int TEXTVIEW_TYPEFACE = 2;
	public final static int TEXTVIEW_TEXT_COLOR = 3;
	public final static int TEXTVIEW_TEXT_SIZE = 4;
	public final static int TEXTVIEW_LETTER_SPACING = 5;
	public final static int TEXTVIEW_TEXT_ALIGNMENT = 6;

	public static void Send (Object[] message) {
		int messageId;
		for (int i = 0; i < message.length;) {
			messageId = (int)message[i];
			if (messageId == TEXTVIEW_TEXT) {
				getTextView(message, i).setText((String)message[i + 2]);
				i += 3;
			} else if (messageId == TEXTVIEW_TYPEFACE) {
				getTextView(message, i).setTypeface((Typeface) message[i + 2]);
				i += 3;
			} else if (messageId == TEXTVIEW_TEXT_COLOR) {
				getTextView(message, i).setTextColor((int) message[i + 2]);
				i += 3;
			} else if (messageId== TEXTVIEW_TEXT_SIZE) {
				getTextView(message, i).setTextSize((int) message[i + 2], (float) message[i + 3]);
				i += 4;
			} else if (messageId== TEXTVIEW_LETTER_SPACING) {
				getTextView(message, i).setLetterSpacing((float) message[i + 2]);
				i += 3;
			} else if (messageId== TEXTVIEW_TEXT_ALIGNMENT) {
				getTextView(message, i).setTextAlignment((int) message[i + 2]);
				i += 3;
			} else {
				// Assume unknown messages of size 3
				i += 3;
			}
		}
	}

	private static TextView getTextView(Object[] message, int i)
	{
		return ((TextView)message[i + 1]);
	}
}