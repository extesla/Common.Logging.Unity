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
using Xunit;
using Common.Logging;
using Common.Logging.Unity;

namespace Common.Logging.Unity.Test
{
	public class UnityLoggerTest
	{

		[Fact]
		public void TestIsDebugEnabled()
		{
			var logger = new UnityLogger("TestLogger", LogLevel.Debug);
			Assert.True(logger.IsDebugEnabled);

			logger = new UnityLogger("TestLogger", LogLevel.Off);
			Assert.False(logger.IsDebugEnabled);
		}

		[Fact]
		public void TestIsErrorEnabled()
		{
			var logger = new UnityLogger("TestLogger", LogLevel.Error);
			Assert.True(logger.IsErrorEnabled);

			logger = new UnityLogger("TestLogger", LogLevel.Off);
			Assert.False(logger.IsErrorEnabled);
		}

		[Fact]
		public void TestIsFatalEnabled()
		{
			var logger = new UnityLogger("TestLogger", LogLevel.Fatal);
			Assert.True(logger.IsFatalEnabled);

			logger = new UnityLogger("TestLogger", LogLevel.Off);
			Assert.False(logger.IsFatalEnabled);
		}

		[Fact]
		public void TestIsInfoEnabled()
		{
			var logger = new UnityLogger("TestLogger", LogLevel.Info);
			Assert.True(logger.IsInfoEnabled);

			logger = new UnityLogger("TestLogger", LogLevel.Off);
			Assert.False(logger.IsInfoEnabled);
		}

		[Fact]
		public void TestIsTraceEnabled()
		{
			var logger = new UnityLogger("TestLogger", LogLevel.Trace);
			Assert.True(logger.IsTraceEnabled);

			logger = new UnityLogger("TestLogger", LogLevel.Off);
			Assert.False(logger.IsTraceEnabled);
		}

		[Fact]
		public void TestIsWarnEnabled()
		{
			var logger = new UnityLogger("TestLogger", LogLevel.Warn);
			Assert.True(logger.IsWarnEnabled);

			logger = new UnityLogger("TestLogger", LogLevel.Off);
			Assert.False(logger.IsWarnEnabled);
		}
	}
}

