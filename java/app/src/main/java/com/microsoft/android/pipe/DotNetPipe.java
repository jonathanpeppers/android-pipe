package com.microsoft.android.pipe;

import java.lang.*;

import android.graphics.Typeface;
import android.text.TextUtils;
import android.widget.*;

public class DotNetPipe {
	public final static int TEXTVIEW_TEXT = 1;
	public final static int TEXTVIEW_TYPEFACE = 2;
	public final static int TEXTVIEW_TEXT_COLOR = 3;
	public final static int TEXTVIEW_TEXT_SIZE = 4;
	public final static int TEXTVIEW_LETTER_SPACING = 5;
	public final static int TEXTVIEW_TEXT_ALIGNMENT = 6;
	public final static int TEXTVIEW_GRAVITY = 7;
	public final static int TEXTVIEW_SINGLE_LINE = 8;
	public final static int TEXTVIEW_MAX_LINES = 9;
	public final static int TEXTVIEW_ELLIPSIZE = 10;
	public final static int TEXTVIEW_PADDING = 11;
	public final static int TEXTVIEW_PAINT_FLAGS = 12;
	public final static int TEXTVIEW_LINE_SPACING = 13;
	public final static int TEXTVIEW_LAYOUT_DIRECTION = 14;
	public final static int TEXTVIEW_TEXT_DIRECTION = 15;

	public static void Send (TextView view, Object[] message) {
		Send (view, message, message.length);
	}

	public static void Send (TextView view, Object[] message, int length) {
		int messageId;
		for (int i = 0; i < length;) {
			messageId = (int)message[i];
			if (messageId == TEXTVIEW_TEXT) {
				view.setText((String)message[i + 1]);
				i += 2;
			} else if (messageId == TEXTVIEW_TYPEFACE) {
				view.setTypeface((Typeface) message[i + 1]);
				i += 2;
			} else if (messageId == TEXTVIEW_TEXT_COLOR) {
				view.setTextColor((int) message[i + 1]);
				i += 2;
			} else if (messageId == TEXTVIEW_TEXT_SIZE) {
				view.setTextSize((int) message[i + 1], (float) message[i + 2]);
				i += 3;
			} else if (messageId == TEXTVIEW_LETTER_SPACING) {
				view.setLetterSpacing((float) message[i + 1]);
				i += 2;
			} else if (messageId == TEXTVIEW_TEXT_ALIGNMENT) {
				view.setTextAlignment((int) message[i + 1]);
				i += 2;
			} else if (messageId == TEXTVIEW_GRAVITY) {
				view.setGravity((int) message[i + 1]);
				i += 2;
			} else if (messageId == TEXTVIEW_SINGLE_LINE) {
				view.setSingleLine ((boolean) message[i + 1]);
				i += 2;
			} else if (messageId == TEXTVIEW_MAX_LINES) {
				view.setMaxLines ((int) message[i + 1]);
				i += 2;
			} else if (messageId == TEXTVIEW_ELLIPSIZE) {
				view.setEllipsize ((TextUtils.TruncateAt) message[i + 1]);
				i += 2;
			} else if (messageId == TEXTVIEW_PADDING) {
				view.setPadding ((int) message[i + 1], (int) message[i + 2], (int) message[i + 3], (int) message[i + 4]);
				i += 5;
			} else if (messageId == TEXTVIEW_PAINT_FLAGS) {
				view.setPaintFlags ((int) message[i + 1]);
				i += 2;
			} else if (messageId == TEXTVIEW_LINE_SPACING) {
				view.setLineSpacing((float) message[i + 1], (float) message[i + 2]);
				i += 3;
			} else if (messageId == TEXTVIEW_LAYOUT_DIRECTION) {
				view.setLayoutDirection((int) message[i + 1]);
				i += 2;
			} else if (messageId == TEXTVIEW_TEXT_DIRECTION) {
				view.setTextDirection((int) message[i + 1]);
				i += 2;
			} else {
				// Assume unknown messages of size 2
				i += 2;
			}
		}
	}
}