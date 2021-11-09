package com.microsoft.android.pipe;

import org.junit.Test;

import android.graphics.Color;
import android.graphics.Typeface;
import android.text.TextUtils;
import android.view.Gravity;
import android.view.View;
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
				DotNetPipe.TEXTVIEW_TEXT_SIZE,
				textView,
				22,
				2.5f
		});

		verify(textView).setTextSize(22, 2.5f);
	}

	@Test
	public void canSendTextView_TextColor() {
		DotNetPipe.Send(new Object[] {
				DotNetPipe.TEXTVIEW_TEXT_COLOR,
				textView,
				Color.BLUE,
		});

		verify(textView).setTextColor(Color.BLUE);
	}

	@Test
	public void canSendTextView_LetterSpacing() {
		DotNetPipe.Send(new Object[] {
				DotNetPipe.TEXTVIEW_LETTER_SPACING,
				textView,
				99.5f,
		});

		verify(textView).setLetterSpacing(99.5f);
	}

	@Test
	public void canSendTextView_TextAlignment() {
		DotNetPipe.Send(new Object[] {
				DotNetPipe.TEXTVIEW_TEXT_ALIGNMENT,
				textView,
				View.TEXT_ALIGNMENT_CENTER,
		});

		verify(textView).setTextAlignment(View.TEXT_ALIGNMENT_CENTER);
	}

	@Test
	public void canSendTextView_Gravity() {
		DotNetPipe.Send(new Object[] {
				DotNetPipe.TEXTVIEW_GRAVITY,
				textView,
				Gravity.CENTER,
		});

		verify(textView).setGravity(Gravity.CENTER);
	}

	@Test
	public void canSendTextView_SingleLine() {
		DotNetPipe.Send(new Object[] {
				DotNetPipe.TEXTVIEW_SINGLE_LINE,
				textView,
				true,
		});

		verify(textView).setSingleLine(true);
	}

	@Test
	public void canSendTextView_MaxLines() {
		DotNetPipe.Send(new Object[] {
				DotNetPipe.TEXTVIEW_MAX_LINES,
				textView,
				2222,
		});

		verify(textView).setMaxLines(2222);
	}

	@Test
	public void canSendTextView_Ellipsize() {
		DotNetPipe.Send(new Object[] {
				DotNetPipe.TEXTVIEW_ELLIPSIZE,
				textView,
				TextUtils.TruncateAt.MIDDLE,
		});

		verify(textView).setEllipsize(TextUtils.TruncateAt.MIDDLE);
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

				DotNetPipe.TEXTVIEW_TEXT_SIZE,
				textView,
				22,
				2.5f,

				DotNetPipe.TEXTVIEW_TEXT_COLOR,
				textView,
				Color.BLUE,

				DotNetPipe.TEXTVIEW_LETTER_SPACING,
				textView,
				99.5f,

				DotNetPipe.TEXTVIEW_TEXT_ALIGNMENT,
				textView,
				View.TEXT_ALIGNMENT_CENTER,

				DotNetPipe.TEXTVIEW_GRAVITY,
				textView,
				Gravity.CENTER,

				DotNetPipe.TEXTVIEW_SINGLE_LINE,
				textView,
				true,

				DotNetPipe.TEXTVIEW_MAX_LINES,
				textView,
				2222,

				DotNetPipe.TEXTVIEW_ELLIPSIZE,
				textView,
				TextUtils.TruncateAt.MIDDLE,
		});

		verify(textView).setText("foo");
		verify(textView).setTypeface(typeface);
		verify(textView).setTextSize(22, 2.5f);
		verify(textView).setTextColor(Color.BLUE);
		verify(textView).setLetterSpacing(99.5f);
		verify(textView).setTextAlignment(View.TEXT_ALIGNMENT_CENTER);
		verify(textView).setGravity(Gravity.CENTER);
		verify(textView).setSingleLine(true);
		verify(textView).setMaxLines(2222);
		verify(textView).setEllipsize(TextUtils.TruncateAt.MIDDLE);
	}
}