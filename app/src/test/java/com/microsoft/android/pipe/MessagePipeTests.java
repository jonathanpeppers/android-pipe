package com.microsoft.android.pipe;

import org.junit.Test;

import static org.junit.Assert.*;

import android.widget.TextView;

import org.junit.runner.RunWith;
import org.mockito.Mock;
import static org.mockito.Mockito.verify;
import org.mockito.junit.MockitoJUnitRunner;

@RunWith(MockitoJUnitRunner.class)
public class MessagePipeTests {

	@Mock
	TextView textView;

	@Test
	public void canSendEmpty() {
		MessagePipe.Send(new Object[0]);
	}

	@Test
	public void canSendTextView_Text() {
		MessagePipe.Send(new Object[] {
				MessagePipe.TEXTVIEW_TEXT,
				textView,
				"foo"
		});

		verify(textView).setText("foo");
	}
}