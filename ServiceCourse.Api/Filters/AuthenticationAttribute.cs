using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ServiceCourse.Api.Util;

namespace ServiceCourse.Api.Filters
{
    public class AuthenticationAttribute: ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string authorizationHeader = context.HttpContext.Request.Headers["Authorization"];
            if (!string.IsNullOrWhiteSpace(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                string token = authorizationHeader.Substring("Bearer ".Length);

                var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var validationUrl = $"{configuration["URLIdentityServer"]}/valid-token";

                var httpClient = new HttpClient();

                // Fazer a chamada HEAD
                var request = new HttpRequestMessage(HttpMethod.Head, validationUrl);
                request.Headers.Add("Authorization", $"Bearer {token}");
                try
                {
                    var response = await httpClient.SendAsync(request);

                    // Verificar o código de status da resposta
                    if (response.IsSuccessStatusCode)
                    {
                        await next(); // Continuar com a execução do próximo filtro ou ação
                        return;
                    }
                }
                catch { }
            }

            var result = new ServiceResult<HttpClient>();

            result.SetError("Não autorizado");

            context.Result = new UnauthorizedObjectResult(result);
        }

        //public async Task <dynamic> login()
        //{
        //    var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        //    var baseUrl = configuration["URLIdentityServer:BaseUrl"];
        //    var loginEndpoint = configuration["URLIdentityServer:LoginEndpoint"];
        //    var userName = configuration["URLIdentityServer:UserName"];
        //    var password = configuration["URLIdentityServer:Password"];
        //    var requestData = new { Username = userName, Password = password };
        //    var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
        //    var httpClient = new HttpClient();
        //    var response =  await httpClient.PostAsync($"{baseUrl}{loginEndpoint}", content);


        //    if (response.IsSuccessStatusCode)
        //    {
        //        var responseContent = response.Content.ReadAsStringAsync().Result;


        //        var contentResult = JsonConvert.DeserializeObject<dynamic>(responseContent);

        //        if (contentResult.Result != null)
        //        {
        //            return contentResult.Result;
        //        }
        //    }
        //    return null;
        //}
    }
}
