using Microsoft.AspNetCore.Http;
using System;

namespace fp_web_aula_1
{
    public class LogerApi : ILogerApi
    {
        private Guid guid;

        public LogerApi()
        {
            guid = Guid.NewGuid();
        }
        public void Log(HttpContext context, long totalTime)
        {
            //
        }
    }
}
