using Microsoft.AspNetCore.Http;

namespace fp_web_aula_1
{
    public interface ILogerApi
    {
        void Log(HttpContext context, long totalTime);
    }
}
