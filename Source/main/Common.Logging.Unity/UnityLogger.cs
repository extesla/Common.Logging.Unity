// Copyright (C) 2014 Extesla, LLC.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
using System;
using Common.Logging.Factory;
using FormatMessageCallback = System.Action<Common.Logging.FormatMessageHandler>;

namespace Common.Logging.Unity
{
	public class UnityLogger : AbstractLogger
	{
		#region Fields
		/// <summary>
		/// The name of the logger.
		/// </summary>
		private string name;

		/// <summary>
		/// The logging level.
		/// </summary>
		private LogLevel level = LogLevel.Debug;
		#endregion

		#region Properties
		/// <summary>
		/// Gets a value indicating whether this instance has debug logging
		/// enabled.
		/// </summary>
		/// <value><c>true</c> if this instance has debug level logging enabled;
		/// otherwise, <c>false</c>.</value>
		public override bool IsDebugEnabled
		{
			get { return LogLevel.Debug >= level; }
		}

		/// <summary>
		/// Gets a value indicating whether this instance has error logging
		/// enabled.
		/// </summary>
		/// <value><c>true</c> if this instance has error level logging enabled;
		/// otherwise, <c>false</c>.</value>
		public override bool IsErrorEnabled
		{
			get { return LogLevel.Error >= level; }
		}

		/// <summary>
		/// Gets a value indicating whether this instance has fatal logging
		/// enabled.
		/// </summary>
		/// <value><c>true</c> if this instance has fatal level logging enabled;
		/// otherwise, <c>false</c>.</value>
		public override bool IsFatalEnabled
		{
			get { return LogLevel.Fatal >= level; }
		}

		/// <summary>
		/// Gets a value indicating whether this instance has info logging
		/// enabled.
		/// </summary>
		/// <value><c>true</c> if this instance has info level logging enabled;
		/// otherwise, <c>false</c>.</value>
		public override bool IsInfoEnabled
		{
			get { return LogLevel.Info >= level; }
		}

		/// <summary>
		/// Gets a value indicating whether this instance has trace logging
		/// enabled.
		/// </summary>
		/// <value><c>true</c> if this instance has trace level logging enabled;
		/// otherwise, <c>false</c>.</value>
		public override bool IsTraceEnabled
		{
			get { return LogLevel.Trace >= level; }
		}

		/// <summary>
		/// Gets a value indicating whether this instance has warn logging
		/// enabled.
		/// </summary>
		/// <value><c>true</c> if this instance has warn level logging enabled;
		/// otherwise, <c>false</c>.</value>
		public override bool IsWarnEnabled
		{
			get { return LogLevel.Warn >= level; }
		}
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="Common.Logging.Unity.UnityLogger"/> class.
		/// </summary>
		/// <param name="name">Name.</param>
		public UnityLogger(string name) : this(name, LogLevel.Debug)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Common.Logging.Unity.UnityLogger"/> class.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="logLevel">Log level.</param>
		public UnityLogger(string name, LogLevel logLevel)
		{
			this.name = name;
			this.level = logLevel;
		}

		/// <summary>
		/// Actually sends the message to the underlying log system.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Writes the message (and exception if not <c>null</c>) to the
		/// Unity engine log.
		/// </para>
		/// </remarks>
		/// <param key="level">the level of this log event.</param>
		/// <param key="message">the message to log</param>
		/// <param key="exception">the exception to log (may be null)</param>
		protected override void WriteInternal(LogLevel level, object message, Exception exception)
		{
			var msg = exception != null ? string.Format("{0}: {1}", message, exception.Message) : string.Format("{0}", message);

			if (LogLevel.Warn == level)
			{
				UnityEngine.Debug.LogWarning(msg);
			}
			else if (LogLevel.Error == level)
			{
				UnityEngine.Debug.LogError(msg);
			}
			else
			{
				UnityEngine.Debug.Log(msg);
			}

			// **
			// If the exception is not null, we should log the actual exception
			// using the UnityEngine's logging capability. [SWQ]
			if (exception != null)
			{
				UnityEngine.Debug.LogException(exception);
			}
		}
	}
}

