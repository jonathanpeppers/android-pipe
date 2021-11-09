package com.microsoft.android.pipe;

import org.junit.Test;

import static org.junit.Assert.*;

import android.graphics.Color;
import android.graphics.Typeface;
import android.widget.TextView;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import static org.mockito.Mockito.verify;
import org.mockito.junit.MockitoJUnitRunner;

@RunWith(MockitoJUnitRunner.class)
public class DotNetPipeTests {

	@Mock
	TextView textView;

	@Mock
	Typeface typeface;

	@Test
	public void canSendEmpty() {
		DotNetPipe.Send(new Object[0]);
	}

	@Test
	public void canSendTextView_Text() {
		DotNetPipe.Send(new Object[] {
				DotNetPipe.TEXTVIEW_TEXT,
				textView,
				"foo"
		});

		verify(textView).setText("foo");
	}

	@Test
	public void canSendTextView_Typeface() {
		DotNetPipe.Send(new Object[] {
				DotNetPipe.TEXTVIEW_TYPEFACE,
				textView,
				typeface
		});

		verify(textView).setTypeface(typeface);
	}

	@Test
	public void canSendTextView_TextSize() {
		DotNetPipe.Send(new Object[] {
				DotNetPipe.TEXTVIEW_TEXTSIZE,
				textView,
				22,
				2.5f
		});

		verify(textView).setTextSize(22, 2.5f);
	}

	@Test
	public void canSendTextView_TextColor() {
		DotNetPipe.Send(new Object[] {
				DotNetPipe.TEXTVIEW_TEXTCOLOR,
				textView,
				Color.BLUE,
		});

		verify(textView).setTextColor(Color.BLUE);
	}

	@Test
	public void canSendTextView_EveryProperty() {
		DotNetPipe.Send(new Object[] {
				DotNetPipe.TEXTVIEW_TEXT,
				textView,
				"foo",

				DotNetPipe.TEXTVIEW_TYPEFACE,
				textView,
				typeface,

				DotNetPipe.TEXTVIEW_TEXTSIZE,
				textView,
				22,
				2.5f,

				DotNetPipe.TEXTVIEW_TEXTCOLOR,
				textView,
				Color.BLUE,
		});

		verify(textView).setText("foo");
		verify(textView).setTypeface(typeface);
		verify(textView).setTextSize(22, 2.5f);
		verify(textView).setTextColor(Color.BLUE);
	}
}