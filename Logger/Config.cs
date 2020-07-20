using System;

namespace Logger
{
    class Config
    { 
        public string FilePath { get; set; }

        public bool InfoEnabled { get; set; } = true;

        public bool DebugEnabled { get; set; } = true;

        public bool WarnEnabled { get; set; } = true;

        public bool ErrorEnabled { get; set; } = true;

        public bool FatalEnabled { get; set; } = true;

        public bool TraceEnabled { get; set; } = true;

        public bool OffEnabled { get; set; } = false;


    }
}
