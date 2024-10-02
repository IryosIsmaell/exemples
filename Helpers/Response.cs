namespace Ark.Domain.Helpers
{
    public class Response<T> : ResponseBase
    {
        public Response(int status, T data)
        {
            this.status = status;
            this.date = DateTime.Now;
            this.traceId = Guid.NewGuid();
            this.data = data;
            switch (status)
            {
                case 200:
                    this.title = "Sucesso";
                    this.message = "Requisição foi bem sucedida";
                    break;
                case 201:
                    this.title = "Sucesso";
                    this.message = "A requisição foi completamente processada pelo servidor";
                    break;
                case 202:
                    this.title = "Sucesso";
                    this.message = "A requisição foi recebida pelo servidor, mas ainda não foi completamente processada";
                    break;
                case 204:
                    this.title = "Sucesso";
                    this.message = "O servidor não possui conteúdo que possa ser adicionado a resposta";
                    break;
                default:
                    this.title = "Não catalogada";
                    this.message = "Não catalogada";
                    break;
            }
        }
        public T data { get; set; }
    }
}
