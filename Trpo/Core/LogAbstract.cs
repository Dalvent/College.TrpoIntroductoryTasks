using System.Collections.Generic;

namespace Trpo_task_1.Core
{
    public abstract class LogAbstract
    {
        protected List<string> log = new List<string>();
        public abstract void _write();
        public abstract void _log(string str);
    }
}