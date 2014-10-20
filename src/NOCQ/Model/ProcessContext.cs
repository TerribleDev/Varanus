using System;
using System.Dynamic;

namespace NOCQ.Model
{
    public class ProcessContext
    {
        public Alert Alert { get; private set;}
        public ExpandoObject SessionData {get; private set;}
        public ProcessContext(Alert alert, ExpandoObject data)
        {
            Alert = alert;
            SessionData = data;
        }
    }
}

