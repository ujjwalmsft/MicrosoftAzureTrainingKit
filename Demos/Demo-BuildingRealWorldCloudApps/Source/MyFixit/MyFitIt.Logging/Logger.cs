﻿namespace MyFixIt.Logging
{
    using System;
    using System.Diagnostics;

    public class Logger : ILogger
    {
        // Warning - trace information within the application
        public void Information(string message)
        {
            Trace.TraceInformation(message);
        }

        public void Information(string fmt, params object[] vars)
        {
            Trace.TraceInformation(fmt, vars);
        }

        public void Information(Exception exception, string fmt, params object[] vars)
        {
            var msg = string.Format(fmt, vars);
            Trace.TraceInformation(string.Format(fmt, vars) + ";Exception Details={0}", exception.ToString());
        }

        // Warning - trace warnings within the application
        public void Warning(string message)
        {
            Trace.TraceWarning(message);
        }

        public void Warning(string fmt, params object[] vars)
        {
            Trace.TraceWarning(fmt, vars);
        }

        public void Warning(Exception exception, string fmt, params object[] vars)
        {
            var msg = string.Format(fmt, vars);
            Trace.TraceWarning(string.Format(fmt, vars) + ";Exception Details={0}", exception.ToString());
        }

        // Error - trace fatal errors within the application
        public void Error(string message)
        {
            Trace.TraceError(message);
        }

        public void Error(string fmt, params object[] vars)
        {
            Trace.TraceError(fmt, vars);
        }

        public void Error(Exception exception, string fmt, params object[] vars)
        {
            var msg = string.Format(fmt, vars);
            Trace.TraceError(string.Format(fmt, vars) + ";Exception Details={0}", exception.ToString());
        }

        // TraceAPI - trace inter-service calls (including latency)
        public void TraceApi(string componentName, string method, TimeSpan timespan)
        {
            this.TraceApi(componentName, method, timespan, string.Empty);
        }

        public void TraceApi(string componentName, string method, TimeSpan timespan, string fmt, params object[] vars)
        {
            this.TraceApi(componentName, method, timespan, string.Format(fmt, vars));
        }

        public void TraceApi(string componentName, string method, TimeSpan timespan, string properties)
        {
            string message = string.Concat("component:", componentName, ";method:", method, ";timespan:", timespan.ToString(), ";properties:", properties);
            Trace.TraceInformation(message);
        }
    }
}