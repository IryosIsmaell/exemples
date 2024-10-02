namespace Ark.Domain.Helpers
{
    public class ResponseError : ResponseBase
    {
        public ResponseError(int status, object error)
        {
            this.status = status;
            this.date = DateTime.Now;
            this.traceId = Guid.NewGuid();
            this.errors = error;
            switch (status)
            {
                case 400:
                    this.title = "Opa! algo deu errado";
                    this.message = "O servidor não vai processar a requisição por um erro nas informações enviadas pelo cliente";
                    break;
                case 403:
                    this.title = "Acesso negado";
                    this.message = "Não foi possível concluir a requisição.";
                    break;
                case 404:
                    this.title = "Bem, isso não é legal";
                    this.message = "Não foi possível encontrar uma resposta para recurso solicitado.";
                    break;
                case 405:
                    this.title = "Não permitido";
                    this.message = "O método utilizado pelo cliente é inteligível pelo servidor, mas não pode ser utilizado para o recurso solicitado.";
                    break;
                case 422:
                    this.title = "Campo(s) inválido(s)";
                    this.message = "Não foi possível processar as informações";
                    break;
                default:
                    this.title = "Não catalogada";
                    this.message = "Não catalogada";
                    break;
            }
        }
        public object errors { get; set; }
    }
}
